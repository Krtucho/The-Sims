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
    public class HomeSimController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeSimController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Home> objList = _db.Home;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            HomeSimVM homesimVM = new HomeSimVM()
            {
                Home = new Home(),
                NeighborhoodSelectList = _db.Neighborhood.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.NeighborhoodID.ToString()
                }),
                
            };
            if (id == null)
            {
                //this is for create
                return View(homesimVM);
            }
            else
            {
                homesimVM.Home = _db.Home.Find(id);
                if (homesimVM.Home == null)
                    return NotFound();
                return View(homesimVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(HomeSimVM homesimVM)
        {
            if (ModelState.IsValid)
            {
                if (homesimVM.Home.HomeID == 0)
                {
                    //Creating
                    _db.Home.Add(homesimVM.Home);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Home.AsNoTracking().FirstOrDefault(u => u.HomeID == homesimVM.Home.HomeID);

                    _db.Home.Update(homesimVM.Home);
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
            Home home = _db.Home.FirstOrDefault(u => u.HomeID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (home == null)
            {
                return NotFound();
            }
            return View(home);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Home.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Home.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
