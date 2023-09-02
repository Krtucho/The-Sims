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
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ActivityController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Activity> objList = _db.Activity;
            return View(objList);
        }
        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {
            ActivityVM activityVM = new ActivityVM()
            {
                Activity = new Activity(),
                ActivityImprovesSkill = new ActivityImprovesSkill(),
                Activity_RSkill = new Activity_RSkill(),
                SkillSelectList = _db.Skill.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.SkillID.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(activityVM);
            }
            else
            {
                activityVM.Activity = _db.Activity.Find(id);
                if (activityVM.Activity == null)
                    return NotFound();
                return View(activityVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ActivityVM activityVM)
        {
            if (ModelState.IsValid)
            {
                //Skill skill = _db.Skill.Find(activityVM.ActivityImprovesSkill.SkillID);
                //ActivityImprovesSkill ais = new ActivityImprovesSkill()
                //{
                //    Skill = skill,
                //    SkillID = activityVM.ActivityImprovesSkill.SkillID,
                //    ActivityID = activityVM.Activity.ActivityID,
                //    Activity = activityVM.Activity
                //};

                //skill = _db.Skill.Find(activityVM.Activity_RSkill.SkillID);
                //Activity_RSkill ars = new Activity_RSkill()
                //{
                //    Skill = skill,
                //    SkillID = activityVM.Activity_RSkill.SkillID,
                //    ActivityID = activityVM.Activity.ActivityID,
                //    Activity = activityVM.Activity,
                //    RequieredPoints = activityVM.Activity_RSkill.RequieredPoints
                //};

                if (activityVM.Activity.ActivityID == 0)
                {
                    //Creating
                    _db.Activity.Add(activityVM.Activity);

                    if (activityVM.ActivityImprovesSkill.SkillID > 0)
                    {
                        var aisFromDB = _db.ActivityImprovesSkill.AsNoTracking().FirstOrDefault(u => u.ActivityID == activityVM.Activity.ActivityID && u.SkillID == activityVM.ActivityImprovesSkill.SkillID);
                        if (aisFromDB == null)
                        {
                            activityVM.ActivityImprovesSkill.ActivityID = activityVM.Activity.ActivityID;
                            activityVM.ActivityImprovesSkill.Activity = activityVM.Activity;
                            _db.ActivityImprovesSkill.Add(activityVM.ActivityImprovesSkill);
                        }
                    }


                    if (activityVM.Activity_RSkill.SkillID > 0)
                    {
                        var arsFromDB = _db.Activity_RSkills.AsNoTracking().FirstOrDefault(u => u.ActivityID == activityVM.Activity.ActivityID && u.SkillID == activityVM.Activity_RSkill.SkillID);
                        if (arsFromDB == null)
                        {
                            activityVM.Activity_RSkill.ActivityID = activityVM.Activity.ActivityID;
                            activityVM.Activity_RSkill.Activity = activityVM.Activity;
                            _db.Activity_RSkills.Add(activityVM.Activity_RSkill);
                        }
                        else
                        {
                            arsFromDB.RequieredPoints = activityVM.Activity_RSkill.RequieredPoints;
                            _db.Activity_RSkills.Update(arsFromDB);
                        }
                    }

                }
                else
                {
                    //Updating
                    var objFromDb = _db.Activity.AsNoTracking().FirstOrDefault(u => u.ActivityID == activityVM.Activity.ActivityID);

                    _db.Activity.Update(activityVM.Activity);

                    if (activityVM.ActivityImprovesSkill.SkillID > 0)
                    {
                        var aisFromDB = _db.ActivityImprovesSkill.AsNoTracking().FirstOrDefault(u => u.ActivityID == activityVM.Activity.ActivityID && u.SkillID == activityVM.ActivityImprovesSkill.SkillID);
                        if (aisFromDB == null)
                        {
                            activityVM.ActivityImprovesSkill.ActivityID = activityVM.Activity.ActivityID;
                            activityVM.ActivityImprovesSkill.Activity = activityVM.Activity;
                            _db.ActivityImprovesSkill.Add(activityVM.ActivityImprovesSkill);
                        }
                    }


                    if (activityVM.Activity_RSkill.SkillID > 0)
                    {
                        var arsFromDB = _db.Activity_RSkills.AsNoTracking().FirstOrDefault(u => u.ActivityID == activityVM.Activity.ActivityID && u.SkillID == activityVM.Activity_RSkill.SkillID);
                        if (arsFromDB == null)
                        {
                            activityVM.Activity_RSkill.ActivityID = activityVM.Activity.ActivityID;
                            activityVM.Activity_RSkill.Activity = activityVM.Activity;
                            _db.Activity_RSkills.Add(activityVM.Activity_RSkill);
                        }
                        else
                        {
                            arsFromDB.RequieredPoints = activityVM.Activity_RSkill.RequieredPoints;
                            _db.Activity_RSkills.Update(arsFromDB);
                        }
                    }
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
            Activity activity = _db.Activity.FirstOrDefault(u => u.ActivityID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Activity.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Activity.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
