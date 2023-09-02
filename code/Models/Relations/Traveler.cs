using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Relations
{
    public class Traveler
    {
        [Key, Column(Order = 0)]
        public int SimID { get; set; }
        [ForeignKey("SimID")]

        public virtual Sim Sim { get; set; }

        [Key, Column(Order = 1)]
        public int WorldID { get; set; }
        [ForeignKey("WorldID")]

        public virtual World World { get; set; }

        [Key, Column(Order = 2)]
        public string DateID { get; set; }
        [ForeignKey("DateID")]

        public virtual Date Date { get; set; }
    }
}
