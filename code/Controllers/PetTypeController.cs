using Microsoft.AspNetCore.Mvc;
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
    public class PetTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PetTypeController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<PetType> objList = _db.PetType;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            PetTypeVM petTypeVM = new PetTypeVM()
            {
                PetType = new PetType(),

            };
            if (id == null)
            {
                //this is for create
                return View(petTypeVM);
            }
            else
            {
                petTypeVM.PetType = _db.PetType.Find(id);
                if (petTypeVM.PetType == null)
                    return NotFound();
                return View(petTypeVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PetTypeVM petTypeVM)
        {
            if (ModelState.IsValid)
            {
                var objFromDb = _db.PetType.AsNoTracking().FirstOrDefault(u => u.PetTypeID == petTypeVM.PetType.PetTypeID);
                if (objFromDb == null)
                {
                    //Creating
                    _db.PetType.Add(petTypeVM.PetType);
                }
                //else
                //{
                    //Updating
                    //var objFromDb = _db.PetType.AsNoTracking().FirstOrDefault(u => u.PetTypeID == petTypeVM.PetType.PetTypeID);

                //    _db.PetType.Update(petTypeVM.PetType);
                //}

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - DELETE
        public IActionResult Delete(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            PetType petType = _db.PetType.FirstOrDefault(u => u.PetTypeID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (petType == null)
            {
                return NotFound();
            }
            return View(petType);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string? id)
        {
            var obj = _db.PetType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.PetType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
