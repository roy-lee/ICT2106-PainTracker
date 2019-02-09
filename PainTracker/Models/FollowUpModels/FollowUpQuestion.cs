using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PainTracker.Data.FollowUp;

namespace PainTracker.Models.FollowUpModels
{
    public class FollowUpQuestion
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }

        public int FollowUpRefId { get; set; }
        [ForeignKey("FollowUpRefId")]
        public FollowUpDTO FollowUpDto;
    }
}
