using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class MissionVM
    {
        public Mission Mission { get; set; }
        public IEnumerable<SelectListItem> WorldSelectList { get; set; }
    }
}
