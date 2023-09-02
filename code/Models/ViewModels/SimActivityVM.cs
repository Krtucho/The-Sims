using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class Sim_ActivityVM
    {
        public Sim Sim { get; set; }
        public Sim_Activity Sim_Activity {get; set; }
        public IEnumerable<SelectListItem> ActivitySelectList { get; set; }
    }
}
