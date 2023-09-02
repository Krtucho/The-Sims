using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class NeighborhoodController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NeighborhoodController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Neighborhood> objList = _db.Neighborhood;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            NeighborhoodVM neighborhoodVM = new NeighborhoodVM()
            {
                Neighborhood = new Neighborhood(),
                WorldSelectList = _db.World.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.WorldID.ToString()
                }),
                SkillSelectList = _db.Skill.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.SkillID.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(neighborhoodVM);
            }
            else
            {
                neighborhoodVM.Neighborhood = _db.Neighborhood.Find(id);
                if (neighborhoodVM.Neighborhood == null)
                    return NotFound();
                return View(neighborhoodVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(NeighborhoodVM neighborhoodVM)
        {
            if (ModelState.IsValid)
            {
                if (neighborhoodVM.Neighborhood.NeighborhoodID== 0)
                {
                    //Creating
                    _db.Neighborhood.Add(neighborhoodVM.Neighborhood);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Neighborhood.AsNoTracking().FirstOrDefault(u => u.NeighborhoodID == neighborhoodVM.Neighborhood.NeighborhoodID);

                    _db.Neighborhood.Update(neighborhoodVM.Neighborhood);
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
            Neighborhood neighborhood= _db.Neighborhood.FirstOrDefault(u => u.NeighborhoodID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (neighborhood == null)
            {
                return NotFound();
            }
            return View(neighborhood);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Neighborhood.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Neighborhood.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
