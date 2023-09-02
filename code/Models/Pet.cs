using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }
       // [Required]
        public string Name { get; set; }

        public string PetTypeID { get; set; }
        [ForeignKey("PetTypeID")]
        public virtual PetType PetType { get; set; }
        public int HomeID { get; set; }
        [ForeignKey("HomeID")]
        public virtual Home Home { get; set; }
    }
}
