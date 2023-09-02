using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class ServicePlace
    {
        [Key]
        public int PlaceID { get; set; }
        [ForeignKey("PlaceID")]
        public virtual Place Place { get; set;}

       // [Range(1, int.MaxValue, ErrorMessage = " Must be greater than 0")]
        public int Cost { get; set; }
        
    }
}
