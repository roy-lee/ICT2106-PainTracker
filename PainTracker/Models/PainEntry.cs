using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class PainEntry 
    {   [ForeignKey("PainDiary")]
        public int patientId { get; set; }
        [Key]
        public int painEntryId { get; set; }

        public DateTime date { get; set; }
        public int painIntensity { get; set; }
        public int painArea { get; set; }
        public int painDuration { get; set; }
        public int sleepTime { get; set; }
       

        public Interference Interference { get; set; }
        public Mood Mood { get; set; }
        public PainEntry()
        {
            //Instantiating new obj
            this.Interference = new Interference();
            this.Mood = new Mood();
        }
    }
}
