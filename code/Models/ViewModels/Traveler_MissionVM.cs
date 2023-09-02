using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class Traveler_MissionVM
    {
        public Sim Sim { get; set; }
        //public Traveler Traveler { get; set; }
        public Traveler_Mission_Date Traveler_Mission_Date { get; set; }
        public IEnumerable<SelectListItem> MissionSelectList { get; set; }
    }
}
