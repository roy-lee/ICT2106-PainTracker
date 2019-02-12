using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Image
    {
        [Key]
        public int KeyID { get; set; }

        
        public int ImgID { get; set; }
               
        public byte[] MedImage { get; set; }
    }
}
