using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class ReminderModel
    {
        public int MedID { get; set; }


        public DateTime Timing { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public byte[] MedImage { get; set; }

    }
}
