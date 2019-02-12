using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PainTracker.Data.FollowUp
{
    // Stub class for testing FollowUp
    public class PainDairyStub
    {
        [Key]
        public int PainDairyId { get; set; }
        public List<FollowUpDTO> FollowUpDTO { get; set; }

    }
}
