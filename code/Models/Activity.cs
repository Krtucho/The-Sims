using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set;}

        
        public string Name { get; set; }

        public string Description { get; set; }

        
    }
}
