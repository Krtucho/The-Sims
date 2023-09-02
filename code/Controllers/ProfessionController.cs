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
    public class ProfessionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProfessionController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Profession> objList = _db.Profession;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            ProfessionVM professionVM = new ProfessionVM()
            {
                Profession = new Profession(),
                Profession_Skill = new Profession_Skill(),
                SkillSelectList = _db.Skill.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.SkillID.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(professionVM);
            }
            else
            {
                professionVM.Profession = _db.Profession.Find(id);
                if (professionVM.Profession == null)
                    return NotFound();
                return View(professionVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProfessionVM professionVM)
        {
            if (ModelState.IsValid)
            {
                if (professionVM.Profession.ProfessionID == 0)
                {
                    //Creating
                    _db.Profession.Add(professionVM.Profession);

                    _db.SaveChanges();
                    professionVM.Profession_Skill.ProfessionID = professionVM.Profession.ProfessionID;
                    _db.Profession_Skill.Add(professionVM.Profession_Skill);

                }
                else
                {
                    _db.Profession.Update(professionVM.Profession);
                    _db.SaveChanges();

                    //Updating
                    var objFromDb = _db.Profession.AsNoTracking().FirstOrDefault(u => u.ProfessionID == professionVM.Profession.ProfessionID);

                    professionVM.Profession_Skill.ProfessionID = professionVM.Profession.ProfessionID;
                    _db.Profession_Skill.Update(professionVM.Profession_Skill);
                    
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
            Profession profession = _db.Profession.FirstOrDefault(u => u.ProfessionID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (profession == null)
            {
                return NotFound();
            }
            return View(profession);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Profession.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Profession.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        

        public IActionResult SimsProfession(int? id) //recibo el id de la profession
        {
             
            IEnumerable <Sim_Profession>simprofession = _db.Sim_Profession.Where(s => s.ProfessionID == id).OrderByDescending(s => s.Level).Take(10);//Todos los sims con esa profession ordenados por el level de mayor a menor y solo 10
            IEnumerable<Sim> sims = new List<Sim>();
            foreach (var item in simprofession)
            {
                sims = _db.Sim.Where(s => s.SimID == item.SimID);

            }
            return View(sims);
        }


    }
}
