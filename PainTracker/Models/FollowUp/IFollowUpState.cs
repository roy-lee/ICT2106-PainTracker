using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTracker.Models.FollowUp
{
    public interface IFollowUpState
    {
        void AskQuestion();
        void AnswerQuestion();
        void GenerateAdvice();
        void CompleteFollowUp();
    }
}
