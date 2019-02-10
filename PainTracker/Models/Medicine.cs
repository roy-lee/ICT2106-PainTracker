﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ExploreCalifornia.Models
{
    public class Medicine
    {
        [Key]
        public int MedID { get; set; }

        [Required]
        public String MedName { get; set; }

        [Required]
        public String MedType { get; set; }

        public String MedDescription { get; set; }
        
    }
}