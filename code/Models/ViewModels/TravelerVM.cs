using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class TravelerVM
    {
        public Sim Sim { get; set; }
        public Traveler Traveler { get; set; }

        public IEnumerable<SelectListItem> WorldSelectList { get; set; }
    }
}
