using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Profession_Skill
    {
        [Key]
        public int ProfessionID { get; set; }
        [ForeignKey("ProfessionID")]
        public virtual Profession Profession { get; set; }

        public int SkillID { get; set; }
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }

       // [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int ScoreLevel { get; set; }
    
    }
}
