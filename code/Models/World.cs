using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class World
    {
        [Key]
        public int WorldID { get; set; }
       // [Required]
        public string Name { get; set; }
    }
}
