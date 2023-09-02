using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Sim_Profession
    {
        [Key]
        public int SimID { get; set; }
        [ForeignKey("SimID")]
        public virtual Sim Sim { get; set; }
        public int ProfessionID { get; set; }
        [ForeignKey("ProfessionID")]
        public virtual Profession Profession { get; set; }

        public int Level { get; set; }
    }
}
