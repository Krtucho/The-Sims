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
    public class MissionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MissionController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Mission> objList = _db.Mission;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            MissionVM missionVM = new MissionVM()
            {
                Mission = new Mission(),
                WorldSelectList = _db.World.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.WorldID.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(missionVM);
            }
            else
            {
                missionVM.Mission = _db.Mission.Find(id);
                if (missionVM.Mission == null)
                    return NotFound();
                return View(missionVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MissionVM missionVM)
        {
            if (ModelState.IsValid)
            {
                if (missionVM.Mission.MissionID == 0)
                {
                    //Creating
                    _db.Mission.Add(missionVM.Mission);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Mission.AsNoTracking().FirstOrDefault(u => u.MissionID == missionVM.Mission.MissionID);

                    _db.Mission.Update(missionVM.Mission);
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

        public IActionResult MissionRSkillIndex()
        {
            IEnumerable<Mission_Requieres_Skill> objList = _db.Mission_Requieres_Skills;
            Dictionary<int, Mission> mission = _db.Mission.ToDictionary(x => x.MissionID);
            Dictionary<int, Skill> skill = _db.Skill.ToDictionary(x => x.SkillID);

            ViewBag.mission = mission;
            ViewBag.skill = skill;

            return View(objList);
        }

        //GET - UPSERT
        public IActionResult MissionRSkillUpsert(int? id)
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
        public IActionResult MissionRSkillUpsert(MissionRSkillVM missionRSkillVM)
        {
            if (ModelState.IsValid)
            {
                if (missionRSkillVM.Mission_Requieres_Skill.MissionID == 0)
                {
                    //Creating
                    _db.Mission_Requieres_Skills.Add(missionRSkillVM.Mission_Requieres_Skill);
                }
                else
                {
                    //Updating
                    //var objFromDb = _db.Mission.AsNoTracking().FirstOrDefault(u => u.MissionID == missionRSkillVM.Mission_Requieres_Skill.Mission.MissionID);

                    var objFromDB = _db.Mission_Requieres_Skills.FirstOrDefault(x => x.MissionID == missionRSkillVM.Mission_Requieres_Skill.MissionID && x.SkillID == missionRSkillVM.Mission_Requieres_Skill.SkillID);

                    if (objFromDB != null)
                    {
                        objFromDB.RequieredPoint = missionRSkillVM.Mission_Requieres_Skill.RequieredPoint;
                        _db.Mission_Requieres_Skills.Update(objFromDB);
                    }
                    else
                        _db.Mission_Requieres_Skills.Add(missionRSkillVM.Mission_Requieres_Skill);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
