using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Home
    {
        [Key]
        public int HomeID { get; set; }
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Bathrooms  { get; set; }
       // [Required]
       // [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Rooms { get; set; }
        public string Description { get; set; }

        public int NeighborhoodID { get; set; }
        [ForeignKey("NeighborhoodID")]
        public virtual Neighborhood Neighborhood { get; set; }

    }
}
