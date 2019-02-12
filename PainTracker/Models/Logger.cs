using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Logger
    {
        [Key]
        public int LogID { get; set; }
        public int MedID { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int DosageTaken { get; set; }
    }
}
