using AutoMapper;
using PainTracker.Models.FollowUpModels;
using PainTracker.Models.FollowUpModels.States;

namespace PainTracker.Data.FollowUp
{
    public class FollowUpMapper : Profile
    {

        public FollowUpMapper()
        {
            // custom mapping for IFollowUpState to int
            CreateMap<Models.FollowUpModels.FollowUp, FollowUpDTO>().ForMember(dest => dest.State, opt => opt.MapFrom(src => StateToInt(src.State)));
        }

        // Translates state to an int to be stored in DB.
        private int StateToInt(IFollowUpState state)
        {
            switch (state.GetType().Name)
            {
                case "PendingQuestionState":
                    return 1;
                case "PendingAnswerState":
                    return 2;
                case "PendingAdviceState":
                    return 3;
                case "CancelledState":
                    return 4;
                case "CompletedState":
                    return 5;
                default:
                    return -1;
            }
        }
    }
}