using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PainTracker.Models.FollowUpModels.States;

namespace PainTracker.Models.FollowUpModels
{
    public class FollowUp
    {
        [Display(Name = "ID.")]
        public int FollowUpId { get; set; }
        public IFollowUpState State { get; set; }
        public ICollection<FollowUpQuestion> QuestionId { get; set; }
        public FollowUpQuestion FollowUpQuestion { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateGenerated { get; set; }
        [Display(Name = "Notified Patient?")]
        public bool NotifyPatientFlag { get; set; }
    }
}
