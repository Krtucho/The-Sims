using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodID { get; set; }

       // [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int SkillID { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }

        public int WorldID { get; set; }
        [ForeignKey("WorldID")]
        public virtual World World { get; set; }
    }
}