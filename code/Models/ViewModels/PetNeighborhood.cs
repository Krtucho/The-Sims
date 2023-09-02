using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class PetNeighborhood
    {
        public string Neighborhood { get; set; }
        public Dictionary<string, int> PetTypeAmount { get; set; }
    }
}
