using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Sim_Skill
    {
        [Key, Column(Order = 0)]
        public int SimID { get; set; }
        [ForeignKey("SimID")]

        public virtual Sim Sim { get; set; }

        [Key, Column(Order = 1)]
        public int SkillID { get; set; }
        [ForeignKey("SkillID")]

        public virtual Skill Skill { get; set; }

        public int Score { get; set; }
    }
}
