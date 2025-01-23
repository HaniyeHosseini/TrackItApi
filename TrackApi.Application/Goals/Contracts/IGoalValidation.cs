using TrackApi.Application.Goals.Dtos;

namespace TrackApi.Application.Goals.Contracts
{
    public interface IGoalValidationService
    {
        Task<bool> IsTargetDateValid(BaseGoalDto goal);
    }
}
