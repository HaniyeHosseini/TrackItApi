using TrackApi.Application.DTOs.Goal;

namespace TrackApi.Application.Goals.Contracts
{
    public interface IGoalValidationService
    {
        Task<bool> IsTargetDateValid(BaseGoalDto goal);
    }
}
