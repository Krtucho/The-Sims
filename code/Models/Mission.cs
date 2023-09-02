using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Mission
    {
        [Key]
        public int MissionID { get; set; }
       
        public string Name { get; set; }
       // [Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Cost { get; set; }
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Reward { get; set; }
        public int WorldID { get; set; }
        [ForeignKey("WorldID")]
        public virtual World World { get; set; }

    }
}
