﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
       // [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
