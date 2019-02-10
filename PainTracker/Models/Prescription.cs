using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Prescription
    {       
        [Key]
        public int PrescriptionID { get; set; }

        public int Frequency { get; set; }
        public int Dosage { get; set; }
    }
}
