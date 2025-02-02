﻿using TrackApi.Application.Goals.Contracts;
using TrackApi.Application.Goals.Dtos;
using TrackApi.Infrastructure.Repositories.Plans;

namespace TrackApi.Application.Goals.Implements
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
