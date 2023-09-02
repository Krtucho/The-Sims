using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class ActivityVM
    {
        public Activity Activity { get; set; }
        public Activity_RSkill Activity_RSkill { get; set; }
        public IEnumerable<SelectListItem> SkillSelectList { get; set; }
        public ActivityImprovesSkill ActivityImprovesSkill { get; set; }
    }
}
