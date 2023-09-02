using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Relations;

namespace WebApplication1.Models.ViewModels
{
    public class PlaceVM
    {
        public ServicePlace ServicePlace { get; set; }
        public Place Place { get; set; }
        public IEnumerable<SelectListItem> NeighborhoodSelectList { get; set; }
    }
}
