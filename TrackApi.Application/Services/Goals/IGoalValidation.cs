using TrackApi.Application.DTOs.Goal;

namespace TrackApi.Application.Services.Goals
{
    public interface IGoalValidationService
    {
        Task<bool> IsTargetDateValid(BaseGoalDto goal);
    }
}
