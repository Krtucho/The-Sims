using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class SimVM
    {
        public Sim Sim { get; set; }
        public IEnumerable<SelectListItem> GenderSelectList { get; set; }
        public IEnumerable<SelectListItem> LifeStageSelectList { get; set; }
        public IEnumerable<SelectListItem> HomeSelectList { get; set; }
    }
}
