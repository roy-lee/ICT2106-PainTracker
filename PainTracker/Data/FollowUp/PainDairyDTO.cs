using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Data.FollowUp
{
    // Stub class
    public class PainDairyDTO
    {
        [Key]
        public int PainDairyId { get; set; }
        public List<FollowUpDTO> FollowUpDTO { get; set; }

    }
}
