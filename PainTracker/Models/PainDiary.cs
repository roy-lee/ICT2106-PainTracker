using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class PainDiary
    {
        [Key]
        public int patientId { get; set; }
        public string patientName { get; set; }
        public virtual ICollection<PainEntry> painEntry { get; set; }
      
    }
}
