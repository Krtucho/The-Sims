using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Profession
    {
        [Key]
        public int ProfessionID { get; set; }
       // [Required]
        public string Name { get; set; }
       /// [Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int BasicSalary { get; set; }
      
    }
}
