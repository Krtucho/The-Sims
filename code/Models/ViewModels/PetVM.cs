using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class PetVM
    {
        public Pet Pet { get; set; }

        public IEnumerable<SelectListItem> PetTypeSelectList { get; set; }
        public IEnumerable<SelectListItem> HomeSelectList { get; set; }
    }
}
