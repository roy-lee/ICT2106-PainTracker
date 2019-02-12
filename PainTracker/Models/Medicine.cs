using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Medicine
    {
        public DateTime date { get; set; }
        public string description { get; set; }
        public int consumerType { get; set; }
        double dosage { get; set; }
    }
}
