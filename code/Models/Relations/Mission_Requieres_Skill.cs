using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Mission_Requieres_Skill
    {
        [Key, Column(Order = 0)]
        public int MissionID { get; set; }
        [ForeignKey("MissionID")]

        public virtual Mission Mission { get; set; }

        [Key, Column(Order = 1)]
        public int SkillID { get; set; }
        [ForeignKey("SkillID")]

        public virtual Skill Skill { get; set; }

       // [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int RequieredPoint { get; set; }
    }
}
