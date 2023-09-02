using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class SimSkillVM
    {
        public Sim Sim { get; set; }
        [Display(Name = "Skill Points")]
        public List<SkillPoints> SkillPoints { get; set; }
    }
}
