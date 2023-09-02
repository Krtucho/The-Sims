using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class MissionRSkillVM
    {
        public Mission_Requieres_Skill Mission_Requieres_Skill { get; set; }
        public IEnumerable<SelectListItem> MissionSelectList { get; set; }
        public IEnumerable<SelectListItem> SkillSelectList { get; set; }
    }
}
