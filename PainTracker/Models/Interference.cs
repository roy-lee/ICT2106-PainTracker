using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
    public class Interference
    {
       
        public int Id { get; set; }
        public string description { get; set; }
        public int severity { get; set; }
        public int duration { get; set; }

        [ForeignKey("PainEntry")]
        public int painEntryId { get; set; }

       

    }
}
