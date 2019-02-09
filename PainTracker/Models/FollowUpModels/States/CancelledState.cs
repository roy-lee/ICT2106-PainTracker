using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainTracker.Models.FollowUpModels.States;

//TODO: Implement Methods
namespace PainTracker.Models.FollowUp
{
    public class CancelledState : IFollowUpState
    {
        public void AskQuestion()
        {
            throw new NotImplementedException();
        }

        public void AnswerQuestion()
        {
            throw new NotImplementedException();
        }

        public void GenerateAdvice()
        {
            throw new NotImplementedException();
        }

        public void CompleteFollowUp()
        {
            throw new NotImplementedException();
        }
    }
}