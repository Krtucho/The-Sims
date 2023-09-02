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
    public class PetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PetController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Pet> objList = _db.Pet;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            PetVM petVM = new PetVM()
            {
                Pet = new Pet(),
                PetTypeSelectList = _db.PetType.Select(i => new SelectListItem
                {
                    Text = i.PetTypeID,
                    Value = i.PetTypeID
                }),
                HomeSelectList = _db.Home.Select(i => new SelectListItem
                {
                    Text = i.HomeID.ToString(),
                    Value = i.HomeID.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(petVM);
            }
            else
            {
                petVM.Pet = _db.Pet.Find(id);
                if (petVM.Pet == null)
                    return NotFound();
                return View(petVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PetVM petVM)
        {
            if (ModelState.IsValid)
            {
                if (petVM.Pet.PetID == 0)
                {
                    //Creating
                    _db.Pet.Add(petVM.Pet);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Pet.AsNoTracking().FirstOrDefault(u => u.PetID == petVM.Pet.PetID);

                    _db.Pet.Update(petVM.Pet);
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
            Pet pet = _db.Pet.FirstOrDefault(u => u.PetID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Pet.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Pet.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
