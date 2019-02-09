using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainTracker.Models.FollowUp;

// FollowUp Model 
namespace PainTracker.Models
{
    public class FollowUps
    {
        public int FollowUpId { get; set; }
        public IFollowUpState state { get; set; }
        public List<string> QuestionIdList { get; set; }
        public DateTime DateGenerated { get; set; }
        public bool NotifyPatientFlag { get; set; }
    }
}