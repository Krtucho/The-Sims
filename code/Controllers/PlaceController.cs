using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Relations;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PlaceController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Place> objList = _db.Place;
            ViewBag.ServicePlaces = _db.ServicePlace.ToDictionary(x => x.PlaceID);
            Dictionary<int, Place> places = objList.ToDictionary(x => x.PlaceID);
            ViewBag.Places = places;
            return View(objList.Where(x => !ViewBag.ServicePlaces.ContainsKey(x.PlaceID)));
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            PlaceVM placeVM = new PlaceVM()
            {
                ServicePlace = new ServicePlace(),
                Place= new Place(),
                NeighborhoodSelectList = _db.Neighborhood.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.NeighborhoodID.ToString()
                }),

            };
            if (id == null)
            {
                //this is for create
                return View(placeVM);
            }
            else
            {
                placeVM.Place = _db.Place.Find(id);
                ServicePlace servicePlace = _db.ServicePlace.Find(id);
                if(servicePlace != null)
                {
                    
                    placeVM.ServicePlace.PlaceID = servicePlace.PlaceID;
                    placeVM.ServicePlace.Place = _db.Place.Find(id);
                    return View(placeVM);
                }

                if (placeVM.Place == null)
                    return NotFound();
                return View(placeVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PlaceVM placeVM)
        {
            if (ModelState.IsValid)
            {
                if (placeVM.Place.PlaceID == 0)
                {
                    //Creating
                    if (placeVM.ServicePlace.Cost > 0)
                    {
                        placeVM.ServicePlace.PlaceID = placeVM.Place.PlaceID;
                        placeVM.ServicePlace.Place = placeVM.Place;
                        _db.ServicePlace.Add(placeVM.ServicePlace);
                    }
                    _db.Place.Add(placeVM.Place);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Place.AsNoTracking().FirstOrDefault(u => u.PlaceID == placeVM.Place.PlaceID);

                    if (placeVM.ServicePlace.Cost > 0)
                    {
                        int cost = placeVM.ServicePlace.Cost;
                        var servObjFromDb = _db.ServicePlace.AsNoTracking().FirstOrDefault(u => u.PlaceID == placeVM.Place.PlaceID);

                        if (servObjFromDb == null)
                        {
                            placeVM.ServicePlace.Place = placeVM.Place;
                            placeVM.ServicePlace.Cost = cost;
                            placeVM.ServicePlace.PlaceID = placeVM.Place.PlaceID;
                            _db.ServicePlace.Add(placeVM.ServicePlace);
                        }
                        else
                        {
                            placeVM.ServicePlace = servObjFromDb;
                            placeVM.ServicePlace.Place = placeVM.Place;
                            placeVM.ServicePlace.Cost = cost;
                            _db.ServicePlace.Update(placeVM.ServicePlace);
                        }
                    }
                    else
                    {
                        var servObjFromDb = _db.ServicePlace.AsNoTracking().FirstOrDefault(u => u.PlaceID == placeVM.Place.PlaceID);

                        if (servObjFromDb != null)
                        {
                            _db.ServicePlace.Remove(servObjFromDb);
                        }
                    }


                    _db.Place.Update(placeVM.Place);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Place place = _db.Place.FirstOrDefault(u => u.PlaceID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Place.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Place.Remove(obj);

            var servObj = _db.ServicePlace.Find(id);
            if (servObj != null)
                _db.ServicePlace.Remove(servObj);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
