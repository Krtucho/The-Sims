using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Activity_RSkill
    {
        [Key]
        public int ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public virtual Activity Activity { get; set; }

        public int SkillID { get; set; } //Habilidad requerida
        [ForeignKey("SkillID")]
        public virtual Skill Skill { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int RequieredPoints { get; set; }
    }
}