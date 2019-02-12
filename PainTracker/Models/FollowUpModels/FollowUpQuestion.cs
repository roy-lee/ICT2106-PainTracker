using System.ComponentModel.DataAnnotations;
using PainTracker.Data.FollowUp;

namespace PainTracker.Models.FollowUpModels
{
    public class FollowUpQuestion
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }

        // EF Core: Follow Up FK stored in FollowUpQuestion table
        public int? FollowUpId { get; set; }
        public FollowUpDTO FollowUpDto { get; set;}
    }
}
