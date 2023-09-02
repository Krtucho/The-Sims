using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class NeighborhoodVM
    {
        public Neighborhood Neighborhood { get; set; }

        public IEnumerable<SelectListItem> WorldSelectList { get; set; }
        public IEnumerable<SelectListItem> SkillSelectList { get; set; }

    }
}
