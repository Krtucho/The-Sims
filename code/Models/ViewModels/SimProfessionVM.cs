using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class SimProfessionVM
    {
        public Sim Sim { get; set; }
        public Profession Profession { get; set; }
        public Sim_Profession Sim_Profession { get; set; }
        public int Level { get; set; }
        public IEnumerable<SelectListItem> ProfessionSelectList { get; set; }
    }
}
