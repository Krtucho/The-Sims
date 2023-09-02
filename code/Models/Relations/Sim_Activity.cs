using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Sim_Activity
    {
        [Key, Column(Order = 0)]
        public int SimID { get; set; }
        [ForeignKey("SimID")]

        public virtual Sim Sim { get; set; }

        [Key, Column(Order = 1)]
        public int ActivityID { get; set; }
        [ForeignKey("ActivityID")]

        public virtual Activity Activity { get; set; }

        public string LastDate { get; set; }
    }
}
