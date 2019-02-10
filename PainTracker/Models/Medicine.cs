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
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Frequency { get; set; }
        public int Dosage { get; set; }
        public String Image { get; set; }
    }
}
