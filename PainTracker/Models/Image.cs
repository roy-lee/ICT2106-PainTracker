using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models
{
    public class Image
    {
        [Key]
        public int ImgID { get; set; }

        public String Img { get; set; }
    }
}
