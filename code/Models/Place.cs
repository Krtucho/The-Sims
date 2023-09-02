using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }
       // [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int NeighborhoodID { get; set; }
        [ForeignKey("NeighborhoodID")]
        public virtual Neighborhood Neighborhood { get; set; }
    }
}
