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
    public class SimsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SimsController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Sim> objList = _db.Sim;
            return View(objList);
        }
        //GET - UPSERT
        //public IActionResult Upsert()
        //{
        //    //IEnumerable<Sim> objList = _db.Sim;
        //    return View();
        //}
        public IActionResult Upsert(int? id)
        {
            //IEnumerable<SelectListItem> GenderDropDown = _db.Gender.Select(i => new SelectListItem
            //{
            //    Text = i.GenderID,
            //    Value = i.GenderID
            //});
            //ViewBag.GenderDropDown = GenderDropDown;

            //IEnumerable<SelectListItem> LifeStageDropDown = _db.LifeStage.Select(i => new SelectListItem
            //{
            //    Text = i.LifeStageID,
            //    Value = i.LifeStageID
            //});
            //ViewBag.LifeStageDropDown = LifeStageDropDown;

            //Sim sim = new Sim();
            //if (id == null)
            //{
            //    return View(sim);
            //}
            //else
            //{
            //    sim = _db.Sim.Find(id);
            //    if(sim == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(sim);

            //}
            SimVM simVM = new SimVM()
            {
                Sim = new Sim(),
                GenderSelectList = _db.Gender.Select(i => new SelectListItem
                {
                    Text = i.GenderID,
                    Value = i.GenderID
                }),
                LifeStageSelectList = _db.LifeStage.Select(i => new SelectListItem
                {
                    Text = i.LifeStageID,
                    Value = i.LifeStageID
                }),
                HomeSelectList = _db.Home.Select(i => new SelectListItem
                {
                    Text = i.HomeID.ToString() + i.Description,
                    Value = i.HomeID.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(simVM);
            }
            else
            {
                simVM.Sim = _db.Sim.Find(id);
                if (simVM.Sim == null)
                    return NotFound();
                return View(simVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SimVM simVM)
        {
            if (ModelState.IsValid)
            {
                if (simVM.Sim.SimID == 0)
                {
                    //Creating
                    _db.Sim.Add(simVM.Sim);
                }
                else
                {
                    //Updating
                    var objFromDb = _db.Sim.AsNoTracking().FirstOrDefault(u => u.SimID == simVM.Sim.SimID);

                    _db.Sim.Update(simVM.Sim);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        ////POST - UPSERT
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(ProductVM productVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        string webRootPath = _webHostEnvironment.WebRootPath;

        //        if (productVM.Product.Id == 0)
        //        {
        //            //Creating
        //            string upload = webRootPath + WC.ImagePath;
        //            string fileName = Guid.NewGuid().ToString();
        //            string extension = Path.GetExtension(files[0].FileName);

        //            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
        //            {
        //                files[0].CopyTo(fileStream);
        //            }

        //            productVM.Product.Image = fileName + extension;

        //            _db.Product.Add(productVM.Product);
        //        }
        //        else
        //        {
        //            //updating
        //            var objFromDb = _db.Sim/*.AsNoTracking()*/.FirstOrDefault(u => u.Id == productVM.Product.Id);

        //            if (files.Count > 0)
        //            {
        //                string upload = webRootPath + WC.ImagePath;
        //                string fileName = Guid.NewGuid().ToString();
        //                string extension = Path.GetExtension(files[0].FileName);

        //                var oldFile = Path.Combine(upload, objFromDb.Image);

        //                if (System.IO.File.Exists(oldFile))
        //                {
        //                    System.IO.File.Delete(oldFile);
        //                }

        //                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
        //                {
        //                    files[0].CopyTo(fileStream);
        //                }

        //                productVM.Product.Image = fileName + extension;
        //            }
        //            else
        //            {
        //                productVM.Product.Image = objFromDb.Image;
        //            }
        //            _db.Product.Update(productVM.Product);
        //        }


        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    productVM.CategorySelectList = _db.Category.Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    });
        //    productVM.ApplicationTypeSelectList = _db.ApplicationType.Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    });
        //    return View(productVM);

        //}
        //POST - UPSERT
        //    public IActionResult Upsert(Sim obj)
        //{
        //    _db.Sim.Add(obj);
        //    _db.SaveChanges();
        //    //IEnumerable<Sim> objList = _db.Sim;
        //    return RedirectToAction("Index");
        //}

        ////GET - UPSERT
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(int? id)
        //{
        //    SimVM simVM = new SimVM()
        //    {
        //        Sim = new Sim(),
        //        GenderSelectList = _db.Gender.Select(i => new SelectListItem
        //        {
        //            Text = i.GenderID,
        //            Value = i.GenderID
        //        })
        //    };
        //    if(id == null)
        //    {
        //        //this is for create
        //        return View(simVM);
        //    }
        //    else
        //    {
        //        simVM.Sim = _db.Sim.Find(id);
        //        if (simVM.Sim == null)
        //            return NotFound();
        //        return View(simVM);
        //    }
        //}

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Sim sim = _db.Sim./*Include(u => u.GenderID).Include(u => u.LifeStageID).Include(u => u.HomeID)*/FirstOrDefault(u => u.SimID == id);
            //var obj = _db.Sim.Find(id);
            //if (obj == null)
            if (sim == null)
            {
                return NotFound();
            }
            return View(sim);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Sim.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Sim.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Profile
        public IActionResult Profile(int? id)
        {
            SimProfileVM simProfileVM = new SimProfileVM()
            {
                Sim = new Sim()
            };
            if (id == null)
            {
                //this is for create
                return View(simProfileVM);
            }
            else
            {
                simProfileVM.Sim = _db.Sim.Find(id);
                if (simProfileVM.Sim == null)
                    return NotFound();
                return View(simProfileVM);
            }
        }

        public IActionResult SimProfession(int? id)
        {
            SimProfessionVM simProfessionVM = new SimProfessionVM()
            {
                Sim = new Sim(),
                Level = 0,
                ProfessionSelectList = _db.Profession.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ProfessionID.ToString()
                }),
            };
            //ViewBag.ActualLevel = (x => simProfessionVM.Sim_Profession.
            if (id == null)
            {
                //this is for create
                return View(simProfessionVM);
            }
            else
            {
                simProfessionVM.Sim_Profession = _db.Sim_Profession.Find(id);
                simProfessionVM.Sim = _db.Sim.Find(id);
                if (simProfessionVM.Sim == null)
                    return NotFound();
                if (simProfessionVM.Sim_Profession == null)
                    return View(simProfessionVM);//NotFound();
                else
                {
                    simProfessionVM.Profession = _db.Profession.Find(simProfessionVM.Sim_Profession.ProfessionID);
                    simProfessionVM.Level = simProfessionVM.Sim_Profession.Level;
                }
                return View(simProfessionVM);
            }
        }

        [HttpPost]
        public IActionResult SimProfession(SimProfessionVM simProfessionVM)
        {
            //if (ModelState.IsValid)
            //{
            int profId = simProfessionVM.Sim_Profession.ProfessionID;
            simProfessionVM.Sim_Profession = _db.Sim_Profession.Find(simProfessionVM.Sim.SimID);
            if (simProfessionVM.Sim_Profession == null || simProfessionVM.Sim_Profession.SimID == 0)
            {
                //Creating
                simProfessionVM.Sim_Profession.SimID = simProfessionVM.Sim.SimID;

                simProfessionVM.Sim = _db.Sim.Find(simProfessionVM.Sim.SimID);
                simProfessionVM.Sim_Profession.ProfessionID = profId;
                simProfessionVM.Profession = _db.Profession.Find(simProfessionVM.Sim_Profession.ProfessionID);

                simProfessionVM.Sim_Profession.Level = 0;//simProfessionVM.Sim_Profession.Level;
                
                _db.Sim_Profession.Add(simProfessionVM.Sim_Profession);
                //return RedirectToAction("Index");
            }
            else
            {
                //Updating
                //var objFromDb = _db.Sim_Profession.AsNoTracking().FirstOrDefault(u => u.SimID == simProfessionVM.Sim_Profession.SimID);
                simProfessionVM.Sim_Profession.SimID = simProfessionVM.Sim.SimID;
                if (simProfessionVM.Sim_Profession.ProfessionID != profId)
                    simProfessionVM.Sim_Profession.Level = 0;
                simProfessionVM.Sim_Profession.ProfessionID = profId;
                _db.Sim_Profession.Update(simProfessionVM.Sim_Profession);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View();
        }
        public IActionResult Work(int? id)
        {
            SimProfessionVM simProfessionVM = new SimProfessionVM()
            {
                Sim = new Sim(),
                Level = 0,
                ProfessionSelectList = _db.Profession.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ProfessionID.ToString()
                }),
            };
            //ViewBag.ActualLevel = (x => simProfessionVM.Sim_Profession.
            if (id == null)
            {
                //this is for create
                return View(simProfessionVM);
            }
            else
            {
                simProfessionVM.Sim_Profession = _db.Sim_Profession.Find(id);
                simProfessionVM.Sim = _db.Sim.Find(id);
                if (simProfessionVM.Sim == null)
                    return NotFound();
                if (simProfessionVM.Sim_Profession == null)
                    return View(simProfessionVM);//NotFound();
                else
                {
                    simProfessionVM.Profession = _db.Profession.Find(simProfessionVM.Sim_Profession.ProfessionID);
                    simProfessionVM.Level = simProfessionVM.Sim_Profession.Level;
                }
                return View(simProfessionVM);
            }
        }


            [HttpPost]
        public IActionResult Work(SimProfessionVM simProfessionVM)
        {
            int id = simProfessionVM.Sim.SimID;
            Sim_Profession sim_Profession = _db.Sim_Profession.Find(id);
            if(sim_Profession == null)
            {
                return RedirectToAction("Index");
            }
            Profession profession = _db.Profession.Find(sim_Profession.ProfessionID);
            if(profession == null)
            { return RedirectToAction("Index"); }

            Profession_Skill profession_skill = _db.Profession_Skill.Find(profession.ProfessionID);
            if(profession_skill == null)
            { return RedirectToAction("Index"); }

            Sim_Skill sim_Skill = _db.Sim_Skill.FirstOrDefault(s => s.SkillID == profession_skill.SkillID && s.SimID == id);

            int points = 1;

            //Neighborhood neighborhood = _db.Neighborhood.FirstOrDefault(s => s.SkillID == profession_skill.SkillID && s.SimID == id);

            //using(var db = new)

            int level = 0;

            if (sim_Skill == null)
            {
                sim_Skill = new Sim_Skill()
                {
                    SimID = sim_Profession.SimID,
                    SkillID = profession_skill.SkillID,
                    Score = 0 + points
                };
                _db.Sim_Skill.Add(sim_Skill);

                Profession_Skill profession_Skill = _db.Profession_Skill.Find(sim_Profession.ProfessionID);
                if (profession_Skill != null)
                {
                    int requiredPoints = profession_Skill.ScoreLevel;
                    level = points % requiredPoints;
                }
                
            }
            else
            {

                sim_Skill.Score += points;

                Profession_Skill profession_Skill = _db.Profession_Skill.Find(sim_Profession.ProfessionID);
                if (profession_Skill != null)
                {
                    int requiredPoints = profession_Skill.ScoreLevel;
                    level = sim_Skill.Score % requiredPoints;
                }


                _db.Sim_Skill.Update(sim_Skill);
            }

            sim_Profession.Level = level;
            _db.Sim_Profession.Update(sim_Profession);

            Sim sim = _db.Sim.Find(id);
            sim.Balance += profession.BasicSalary * level;
            _db.Sim.Update(sim);

            _db.SaveChanges();

            ViewBag.Profession = profession;
            return RedirectToAction("Index");
        }

        public ViewResult SimSkill(int? id)
        {
            SimSkillVM simSkillVM = new SimSkillVM
            {
                Sim = _db.Sim.FirstOrDefault(s => s.SimID == id),
                SkillPoints = new List<SkillPoints>()
            };
            IEnumerable<Sim_Skill> tempSimSkills = _db.Sim_Skill.Where(s => s.SimID == id);

            foreach (Sim_Skill skills in tempSimSkills)
                simSkillVM.SkillPoints.Add(new SkillPoints
                {
                    Skill = _db.Skill.FirstOrDefault(s => s.SkillID == skills.SkillID),
                    Points = skills.Score
                });
            return View(simSkillVM);
        }

        public IActionResult SimActivity(int? id)
        {
            Sim_ActivityVM sim_ActivityVM = new Sim_ActivityVM()
            {
                Sim = new Sim(),
                Sim_Activity = new Sim_Activity(),
                ActivitySelectList = null
                //_db.Activity.Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.ActivityID.ToString()
                //}),
            };

            List<int> sim_Skill = _db.Sim_Skill.Where(x => x.SimID == id).Select(y => y.SkillID).ToList();


            IEnumerable<Activity_RSkill> ars = _db.Activity_RSkills.Where(x => sim_Skill.Contains(x.SkillID));

            Dictionary<int, Sim_Skill> keyValuePairs = _db.Sim_Skill.Where(x => sim_Skill.Contains(x.SkillID) && x.SimID == id).ToDictionary(y => y.SkillID);


            if(ars !=  null)
                ars = ars.Where(y => y.RequieredPoints <= keyValuePairs[y.SkillID].Score);

            List<int> actID = ars.Select(z => z.ActivityID).ToList();


            sim_ActivityVM.ActivitySelectList = _db.Activity.Where(x => actID.Contains(x.ActivityID)).
                                                                Select(y => new SelectListItem
                                                                {
                                                                    Text = y.Name,
                                                                    Value = y.ActivityID.ToString()
                                                                });

            //ViewBag.ActualLevel = (x => simProfessionVM.Sim_Profession.
            if (id == null)
            {
                //this is for create
                return View(sim_ActivityVM);
            }
            else
            {
                //sim_ActivityVM.Sim_Activity = _db.Sim_Activity.Find(id);
                sim_ActivityVM.Sim = _db.Sim.Find(id);
                if (sim_ActivityVM.Sim == null)
                    return NotFound();
                //if (sim_ActivityVM.Sim_Activity == null)
                    //return View(sim_ActivityVM);//NotFound();
                //else
                //{
                //    sim_ActivityVM.Profession = _db.Profession.Find(simProfessionVM.Sim_Profession.ProfessionID);
                //    simProfessionVM.Level = simProfessionVM.Sim_Profession.Level;
                //}
                return View(sim_ActivityVM);
            }
        }

        [HttpPost]
        public IActionResult SimActivity(Sim_ActivityVM sim_ActivityVM)
        {

            int id = sim_ActivityVM.Sim.SimID;

            int actID = sim_ActivityVM.Sim_Activity.ActivityID;
            //sim_ActivityVM.Sim_Activity = _db.Sim_Activity.Find(sim_ActivityVM.Sim_Activity.ActivityID);

            //if (sim_ActivityVM.Sim_Activity == null)
            //{
            //    return RedirectToAction("Index");
            //}

            if (id == 0 || actID == 0)
                return NotFound();

            Sim sim = _db.Sim.Find(id);
            if (sim == null)
                return NotFound();

            Sim_Activity sim_Activity = _db.Sim_Activity.FirstOrDefault(s => s.SimID == id && s.ActivityID == actID);
            int skill = 0, pointsToAdd = 0;
            ActivityImprovesSkill ais = _db.ActivityImprovesSkill.FirstOrDefault(x => x.ActivityID == actID);

            if (ais != null)
            {
                skill = ais.SkillID;
                pointsToAdd = _db.Neighborhood.Find(
                                    _db.Home.Find(
                                        _db.Sim.Find(id).HomeID).NeighborhoodID).SkillID == skill ? 2 : 1;

            }
            else
            {
                pointsToAdd = 1;
            }

            Sim_Skill sim_skill = null;
            if (skill > 0)
                sim_skill = _db.Sim_Skill.FirstOrDefault(x => x.SimID == id && x.SkillID == skill);

            if(sim_skill == null)
            {
                if (skill > 0)
                {
                    sim_skill = new Sim_Skill()
                    {
                        SimID = id,
                        SkillID = skill,
                        Score = pointsToAdd
                    };
                    _db.Sim_Skill.Add(sim_skill);
                }
            }
            else
            {
                if (skill > 0)
                {
                    sim_skill.Score += pointsToAdd;
                    _db.Sim_Skill.Update(sim_skill);
                }
            }

            if (sim_Activity == null)
            {
                sim_Activity = new Sim_Activity()
                {
                    SimID = id,
                    ActivityID = actID,
                    LastDate = DateTime.Now.ToString()
                };
                _db.Sim_Activity.Add(sim_Activity);
            }
            else
            {
                sim_Activity.LastDate = DateTime.Now.ToString();
                _db.Sim_Activity.Update(sim_Activity);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SimPet(int? id)
        {
            Sim sim = _db.Sim.Find(id);
            int SimHomeID = sim.HomeID;
            //int neighborhood = sim.Home.NeighborhoodID;

            //IQueryable<IGrouping<string, Pet>> popularPets = _db.Pet.GroupBy(i => i.PetTypeID);
            //IQueryable<Neighborhood> petsTemp =_db.Home.Join<Home, Neighborhood, int, Neighborhood>(_db.Neighborhood, x => x.NeighborhoodID, y=> y.NeighborhoodID);

            var innerJoinQuery =
                from home in _db.Home
                join neigh in _db.Neighborhood on home.NeighborhoodID equals neigh.NeighborhoodID
                join pet in _db.Pet on home.HomeID equals pet.HomeID
                select new { Home = home.NeighborhoodID, Neighborhood = neigh.Name, Pet = pet.Name, PetType = pet.PetTypeID };

            Dictionary<string, PetNeighborhood> petTypeAmount = new Dictionary<string, PetNeighborhood>();

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine("{0, -10}{1, -20}{2} ", item.Home, item.Neighborhood, item.Pet);
                if (petTypeAmount.ContainsKey(item.Neighborhood))
                {
                    if (petTypeAmount[item.Neighborhood].PetTypeAmount.ContainsKey(item.PetType))
                        petTypeAmount[item.Neighborhood].PetTypeAmount[item.PetType]++;
                    else
                        petTypeAmount[item.Neighborhood].PetTypeAmount.Add(item.PetType, 1);
                }
                else
                {
                    petTypeAmount.Add(item.Neighborhood,
                        new PetNeighborhood()
                        {
                            Neighborhood = item.Neighborhood,
                            PetTypeAmount = new Dictionary<string, int>(),
                        });
                    petTypeAmount[item.Neighborhood].PetTypeAmount.Add(item.PetType, 1);
                }
            }

            //         Neigh, PetType
            List<Tuple<string, string, int>> neighPetTypeTemp = new List<Tuple<string, string, int>>();

            foreach (var item in petTypeAmount)
            {
                Tuple<string, string, int> maxAmount = new Tuple<string, string, int>(item.Key,"", 0);
                foreach (var petType in item.Value.PetTypeAmount)
                    if (maxAmount.Item2== "" && maxAmount.Item3== 0 || petType.Value > maxAmount.Item3 )
                        maxAmount = new Tuple<string, string, int>(item.Key, petType.Key, petType.Value);
                neighPetTypeTemp.Add(maxAmount);
            }

            ViewBag.PetTypeAmount = neighPetTypeTemp;

            IEnumerable<Pet> pets = _db.Pet.Where(s => s.HomeID == SimHomeID);

            return View(pets);
        }

        public IActionResult SimNeighborhood(int? id)
        {
            int simhomeid = _db.Sim.Find(id).HomeID;
            int neiborhoodID = _db.Home.Find(simhomeid).NeighborhoodID;
            int skillpotenciedforneiborhood = _db.Neighborhood.Find(neiborhoodID).SkillID;
            string skillname = _db.Skill.Find(skillpotenciedforneiborhood).Name;
            Skill skill = null;
            foreach (var s in _db.Sim_Skill)
            {
                if (s.SimID == id && s.SkillID == skillpotenciedforneiborhood)
                {
                    skill = new Skill();
                    skill.SkillID = skillpotenciedforneiborhood;
                    skill.Name = skillname;
                }
            }

            return View(skill);
        }

        public IActionResult TravelerIndex(int? id)
        {
            IEnumerable<Traveler> objList = _db.Traveler.Where(x => x.SimID == id);
            ViewBag.SimID = id;

            ViewBag.World = _db.World.ToDictionary(y => y.WorldID);

            int worldHomeSim = _db.Neighborhood.Find(
                               _db.Home.Find(
                                   _db.Sim.Find(
                                       id).HomeID).NeighborhoodID).WorldID;//_db.Home.Where(x => x.HomeID == _db.Sim.Find(id).HomeID).Where(y => _db.World.Find(y.NeighborhoodID))
            int worldID;

            ViewBag.IsTraveling = IsTraveling(id, worldHomeSim, out worldID);

            return View(objList);
        }

        private bool IsTraveling(int? simID, int worldHomeSim, out int worldID)
        {
            IEnumerable<Traveler> temp = _db.Traveler.Where(x => x.SimID == simID);
            List<Tuple<int, int, DateTime>> ordered = new List<Tuple<int, int, DateTime>>();
            foreach (var item in temp)
            {
                DateTime result;
                if (DateTime.TryParse(item.DateID, out result))
                {
                    ordered.Add(new Tuple<int, int, DateTime>(item.SimID, item.WorldID, result));
                }
            }
                
            ordered = ordered.OrderByDescending(x => x.Item3).ToList();
            worldID = 0;
            if (ordered.Count() == 0)
                return false;
            worldID = ordered.First().Item2;
            return worldID != worldHomeSim;
        }
        //GET - UPSERT
        public IActionResult TravelerUpsert(int? id)
        {
            

            int worldHomeSim = _db.Neighborhood.Find(
                                _db.Home.Find(
                                    _db.Sim.Find(
                                        id).HomeID).NeighborhoodID).WorldID;//_db.Home.Where(x => x.HomeID == _db.Sim.Find(id).HomeID).Where(y => _db.World.Find(y.NeighborhoodID))
            int worldID;

            TravelerVM travelerVM = new TravelerVM()
            {
                Sim = new Sim(),
                Traveler = new Traveler(),
                WorldSelectList = _db.World.Where(x => x.WorldID != worldHomeSim).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.WorldID.ToString()
                }),
            };

            

            if (ViewBag.IsTraveling = IsTraveling(id, worldHomeSim, out worldID))
                travelerVM.WorldSelectList = _db.World.Where(x => x.WorldID != worldID).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.WorldID.ToString()
                });
            if (id == null)
            {
                //this is for create
                return View(travelerVM);
            }
            else
            {
                travelerVM.Sim = _db.Sim.Find(id);
                if (travelerVM.Sim == null)
                    return NotFound();
                return View(travelerVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TravelerUpsert(TravelerVM travelerVM)
        {
            if (ModelState.IsValid)
            {
                if (travelerVM.Traveler.WorldID == 0)
                {
                    return RedirectToAction("Index");
                    //Creating
                    //_db.Profession.Add(travelerVM.Profession);
                }
                else
                {
                    //Updating
                    //var objFromDb = _db.Profession.AsNoTracking().FirstOrDefault(u => u.ProfessionID == professionVM.Profession.ProfessionID);
                    travelerVM.Traveler.SimID = travelerVM.Sim.SimID;
                    travelerVM.Traveler.DateID = DateTime.Now.ToString();
                    travelerVM.Traveler.World = _db.World.Find(travelerVM.Traveler.WorldID);
                    Date date = new Date() { DateID = travelerVM.Traveler.DateID };
                    travelerVM.Traveler.Date = date;

                    _db.Date.Add(date);
                    _db.Traveler.Add(travelerVM.Traveler);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        ////GET - DELETE
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Profession profession = _db.Profession.FirstOrDefault(u => u.ProfessionID == id);
        //    //var obj = _db.Sim.Find(id);
        //    //if (obj == null)
        //    if (profession == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(profession);
        //}

        ////POST - DELETE
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(int? id)
        //{
        //    var obj = _db.Profession.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Profession.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult MissionIndex(int? id)
        {
            IEnumerable<Traveler_Mission_Date> objList = _db.Traveler_Mission_Date.Where(x => x.SimID == id);
            ViewBag.SimID = id;

            ViewBag.World = _db.World.ToDictionary(y => y.WorldID);
            ViewBag.MissionWorld = _db.Mission.ToDictionary(x => x.MissionID);

            Dictionary<int, Mission> mission = _db.Mission.ToDictionary(x => x.MissionID);// .Traveler_Mission_Date.ToDictionary(y => y.SimID == id);

            // Calculando la cantidad de misiones que se han repetido y si ha salido victorioso en alguna
            ViewBag.Mission = mission;
            int worldHomeSim = _db.Neighborhood.Find(
                               _db.Home.Find(
                                   _db.Sim.Find(
                                       id).HomeID).NeighborhoodID).WorldID;//_db.Home.Where(x => x.HomeID == _db.Sim.Find(id).HomeID).Where(y => _db.World.Find(y.NeighborhoodID))
            int worldID;

            ViewBag.IsTraveling = IsTraveling(id, worldHomeSim, out worldID);

            ViewBag.actualWord = _db.World.Find(worldID == 0 ? worldHomeSim : worldID).Name;
            Dictionary<int, int> rep = new Dictionary<int, int>();
            foreach (var item in objList)
            {
                if (!rep.ContainsKey(item.MissionID))
                    rep.Add(item.MissionID, 0);
                 rep[item.MissionID]++;
            }
            bool repeated = false;
            foreach (var item in rep)
            {
                if (item.Value >= 2)
                {
                    repeated = true;
                    break;
                }
            }
            bool won = false;
            if(repeated)
            {
                won = objList.Where(x => rep.ContainsKey(x.MissionID) && rep[x.MissionID] >= 2 && x.Result == "Completed").Count() >= 1;
            }

            ViewBag.Repeated = repeated && won;

            // Calculando promedio de simoleones gastados por este viajero
            ViewBag.total = 0;
            ViewBag.total = objList.Sum(x => mission[x.MissionID].Cost) / ((objList.Count() > 0)? objList.Count(): 1);

            return View(objList);
        }
        //GET - UPSERT
        public IActionResult MissionUpsert(int? id)
        {


            int worldHomeSim = _db.Neighborhood.Find(
                                _db.Home.Find(
                                    _db.Sim.Find(
                                        id).HomeID).NeighborhoodID).WorldID;//_db.Home.Where(x => x.HomeID == _db.Sim.Find(id).HomeID).Where(y => _db.World.Find(y.NeighborhoodID))
            int worldID;

            //TravelerVM travelerVM = new TravelerVM()
            //{
            //    Sim = new Sim(),
            //    Traveler = new Traveler(),
            //    WorldSelectList = _db.World.Where(x => x.WorldID != worldHomeSim).Select(i => new SelectListItem
            //    {
            //        Text = i.Name,
            //        Value = i.WorldID.ToString()
            //    }),
            //};

            Traveler_MissionVM traveler_MissionVM = new Traveler_MissionVM()
            {
                Sim = new Sim(),
                Traveler_Mission_Date = new Traveler_Mission_Date(),
                MissionSelectList = new List<SelectListItem>()
            };

            if (ViewBag.IsTraveling = IsTraveling(id, worldHomeSim, out worldID))
            {
                traveler_MissionVM.Sim = _db.Sim.Find(id);
                traveler_MissionVM.Traveler_Mission_Date.Sim = traveler_MissionVM.Sim;

                Dictionary<int,Mission_Requieres_Skill> mrs = _db.Mission_Requieres_Skills.ToDictionary(x => x.MissionID);
                IDictionary<int, Sim_Skill> sim_skill = _db.Sim_Skill.Where(x => x.SimID == id).ToDictionary(y => y.SkillID);

                List<Mission> missionList = _db.Mission.Where(x => (x.WorldID == worldID)).ToList();

                if (missionList.Count > 0)
                    missionList = missionList.Where(x => (x.Cost <= traveler_MissionVM.Sim.Balance)).ToList();
                        
                if(missionList.Count > 0)
                   missionList = missionList.Where(x => mrs.ContainsKey(x.MissionID)).ToList();

                if (missionList.Count > 0)
                    missionList = missionList.Where(x => sim_skill.ContainsKey(mrs[x.MissionID].SkillID)).ToList();

                if (missionList.Count > 0)
                    missionList = missionList.Where(x => mrs[x.MissionID].RequieredPoint <= sim_skill[mrs[x.MissionID].SkillID].Score).ToList();

                /*traveler_MissionVM.MissionSelectList = _db.Mission.Where(x => (x.WorldID == worldID) &&
                                                            (x.Cost <= traveler_MissionVM.Sim.Balance) &&
                                                            mrs.ContainsKey(x.MissionID) &&
                                                            sim_skill.ContainsKey(mrs[x.MissionID].SkillID)); &&
                                                            (mrs[x.MissionID].RequieredPoint <= sim_skill[mrs[x.MissionID].SkillID].Score)
                                                            )*/
                traveler_MissionVM.MissionSelectList = missionList
                    .Select(i => new SelectListItem
                {
                    Text = i.MissionID.ToString(),
                    Value = i.MissionID.ToString()
                });


            }
            if (id == null)
            {
                //this is for create
                return View(traveler_MissionVM);
            }
            else
            {
                //traveler_MissionVM.Sim = _db.Sim.Find(id);
                if (traveler_MissionVM.Sim == null)
                    return NotFound();
                return View(traveler_MissionVM);
            }
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MissionUpsert(Traveler_MissionVM traveler_MissionVM)
        {
            if (ModelState.IsValid)
            {
                if (traveler_MissionVM.Traveler_Mission_Date.MissionID == 0)
                {
                    return RedirectToAction("Index");
                    //Creating
                    //_db.Profession.Add(travelerVM.Profession);
                }
                else
                {
                    //Updating
                    //var objFromDb = _db.Profession.AsNoTracking().FirstOrDefault(u => u.ProfessionID == professionVM.Profession.ProfessionID);
                    //traveler_MissionVM.Traveler.SimID = travelerVM.Sim.SimID;
                    traveler_MissionVM.Traveler_Mission_Date.DateID = DateTime.Now.ToString();
                    //traveler_MissionVM.Traveler.World = _db.World.Find(travelerVM.Traveler.WorldID);
                    Date date = new Date() { DateID = traveler_MissionVM.Traveler_Mission_Date.DateID };
                    traveler_MissionVM.Traveler_Mission_Date.Date = date;

                    Mission mission = _db.Mission.Find(traveler_MissionVM.Traveler_Mission_Date.MissionID);
                    traveler_MissionVM.Traveler_Mission_Date.SimID = traveler_MissionVM.Sim.SimID;
                    Sim sim = _db.Sim.Find(traveler_MissionVM.Sim.SimID);
                    sim.Balance -= mission.Cost;
                    _db.Sim.Update(sim);

                    traveler_MissionVM.Traveler_Mission_Date.Result = new Random().Next(1, 5) < 3 ? "Completed" : "Fail";
                    traveler_MissionVM.Traveler_Mission_Date.Mission = _db.Mission.Find(traveler_MissionVM.Traveler_Mission_Date.MissionID);

                    _db.Date.Add(date);
                    _db.Traveler_Mission_Date.Add(traveler_MissionVM.Traveler_Mission_Date);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}