using TrackApi.Application.DTOs.Goal;
using TrackApi.Infrastructure.Repositories.Plans;

namespace TrackApi.Application.Services.Goals
{
    public class GoalValidationService : IGoalValidationService
    {
        private readonly IPlanRepository _planRepository;

        public GoalValidationService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> IsTargetDateValid(BaseGoalDto goal)
        {
            var plan = await _planRepository.GetByIdAsync(goal.PlanId);
            return goal.TargetDate.Date < plan.EndDate.Date;
        }
    }
}
