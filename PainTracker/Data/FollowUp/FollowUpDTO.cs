using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PainTracker.Models.FollowUpModels;

// FollowUp Model 
namespace PainTracker.Data.FollowUp
{
    public class FollowUpDTO
    {
        [Key]
        [Display(Name = "ID.")]
        public int FollowUpId { get; set; }
        public int State { get; set; }
        public ICollection<FollowUpQuestion> QuestionId { get; set; }
        public FollowUpQuestion FollowUpQuestion { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateGenerated { get; set; }
        [Display(Name = "Notified Patient?")]
        public bool NotifyPatientFlag { get; set; }
    }
}