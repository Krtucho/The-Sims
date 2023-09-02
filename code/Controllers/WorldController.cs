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
    public class WorldController : Controller
    {
        private readonly ApplicationDbContext _db;
        public WorldController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<World> objList = _db.World;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            WorldVM worldVM = new WorldVM()
            {
                World = new World(),

            };
            if (id == null)
            {
                //this is for create
                return View(worldVM);
            }
            else
            {
                worldVM.World = _db.World.Find(id);
                if (worldVM.World == null)
                    return NotFound();
                return View(worldVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(WorldVM worldVM)
        {
            if (ModelState.IsValid)
            {
                if (worldVM.World.WorldID == 0)
                {
                    //Creating
                    _db.World.Add(worldVM.World);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.World.AsNoTracking().FirstOrDefault(u => u.WorldID == worldVM.World.WorldID);

                    _db.World.Update(worldVM.World);
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
            World world = _db.World.FirstOrDefault(u => u.WorldID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (world == null)
            {
                return NotFound();
            }
            return View(world);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.World.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.World.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
