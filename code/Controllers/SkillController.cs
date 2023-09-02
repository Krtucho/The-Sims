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
    public class SkillController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SkillController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Skill> objList = _db.Skill;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            SkillVM skillVM = new SkillVM()
            {
                Skill = new Skill(),
               
            };
            if (id == null)
            {
                //this is for create
                return View(skillVM);
            }
            else
            {
                skillVM.Skill = _db.Skill.Find(id);
                if (skillVM.Skill == null)
                    return NotFound();
                return View(skillVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SkillVM skillVM)
        {
            if (ModelState.IsValid)
            {
                if (skillVM.Skill.SkillID == 0)
                {
                    //Creating
                    _db.Skill.Add(skillVM.Skill);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Skill.AsNoTracking().FirstOrDefault(u => u.SkillID == skillVM.Skill.SkillID);

                    _db.Skill.Update(skillVM.Skill);
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
            Skill skill = _db.Skill.FirstOrDefault(u => u.SkillID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Skill.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Skill.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
