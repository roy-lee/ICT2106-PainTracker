using AutoMapper;
using PainTracker.Models.FollowUp;
using PainTracker.Models.FollowUpModels.States;

namespace PainTracker.Data.FollowUp
{
    // Actual class that handles the bidirectional mapping of FollowUp <-> FollowUpDTO
    public class FollowUpMapper : Profile
    {
        public FollowUpMapper()
        {
            // Custom Mapping for FollowUp -> FollowUpDTO, IFollowUpState to int FollowUp
            CreateMap<Models.FollowUpModels.FollowUp, FollowUpDTO>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => StateToInt(src.State)));

            // Custom Mapping for FollowUpDTO -> FollowUp, int FollowUp to IFollowUpState
            CreateMap<FollowUpDTO, Models.FollowUpModels.FollowUp>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => IntToState(src.State)));
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

        // Translates int to state to 
        private IFollowUpState IntToState(int state)
        {
            switch (state)
            {
                case 1:
                    return new PendingQuestionState();
                case 2:
                    return new PendingAnswerState();
                case 3:
                    return new PendingAdviceState();
                case 4:
                    return new CancelledState();
                case 5:
                    return new CompletedState();
                default:
                    return new CompletedState();
            }
        }
    }
}