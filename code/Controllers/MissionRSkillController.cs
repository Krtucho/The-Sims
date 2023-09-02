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
    public class MissionRSkillController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MissionRSkillController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Mission_Requieres_Skill> objList = _db.Mission_Requieres_Skills;
            Dictionary<int, Mission> mission = _db.Mission.ToDictionary(x => x.MissionID);
            Dictionary<int, Skill> skill = _db.Skill.ToDictionary(x => x.SkillID);
            
            ViewBag.mission = mission;
            ViewBag.skill = skill;
            
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            MissionRSkillVM missionVM = new MissionRSkillVM()
            {
                MissionSelectList = _db.Mission.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.MissionID.ToString()
                }),
                SkillSelectList = _db.Skill.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.SkillID.ToString()
                }),
                Mission_Requieres_Skill = new Mission_Requieres_Skill()
            };
            if (id == null)
            {
                //this is for create
                return View(missionVM);
            }
            else
            {
                missionVM.Mission_Requieres_Skill.Mission = _db.Mission.Find(id);
                if (missionVM.Mission_Requieres_Skill.Mission == null)
                    return NotFound();
                return View(missionVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MissionRSkillVM missionRSkillVM)
        {
            if (ModelState.IsValid)
            {
                if (missionRSkillVM.Mission_Requieres_Skill.Mission.MissionID == 0)
                {
                    //Creating
                    _db.Mission.Add(missionRSkillVM.Mission_Requieres_Skill.Mission);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Mission.AsNoTracking().FirstOrDefault(u => u.MissionID == missionRSkillVM.Mission_Requieres_Skill.Mission.MissionID);

                    _db.Mission.Update(missionRSkillVM.Mission_Requieres_Skill.Mission);
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
            Mission mission = _db.Mission.FirstOrDefault(u => u.MissionID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (mission == null)
            {
                return NotFound();
            }
            return View(mission);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Mission.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Mission.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
