using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Reminder
    {
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Dosage { get; set; }
        public String Img { get; set; }
    }
}
