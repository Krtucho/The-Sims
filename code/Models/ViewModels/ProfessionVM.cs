using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class ProfessionVM
    {
        public Profession Profession { get; set; }
        public Profession_Skill Profession_Skill { get; set; }
        public IEnumerable<SelectListItem> SkillSelectList { get; set; }
    }
}
