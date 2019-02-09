namespace PainTracker.Models.FollowUpModels.States
{
    public interface IFollowUpState
    {
        void AskQuestion();
        void AnswerQuestion();
        void GenerateAdvice();
        void CompleteFollowUp();
    }
}
