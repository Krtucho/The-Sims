using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sim
    {
        [Key]
        public int SimID { get; set; }
        //[Required]
        public string Name { get; set; }

        //[Required]
       // [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Balance { get; set; }
      //  [Required]
        public string LastName { get; set; }
       
        public int HomeID { get; set; }
        [ForeignKey("HomeID")]
        public virtual Home Home { get; set; }
      
        public string LifeStageID { get; set; }
        [ForeignKey("LifeStageID")]
        public virtual LifeStage LifeStage { get; set; }

        public string GenderID { get; set; }
        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }
    }
}
