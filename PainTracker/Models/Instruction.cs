using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Instruction
    {       
        [Key]
        public int InstructionID { get; set; }

        public int Frequency { get; set; }
        public int Dosage { get; set; }
    }
}
