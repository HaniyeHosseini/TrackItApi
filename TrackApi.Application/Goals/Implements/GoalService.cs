using Mapster;
using System.Numerics;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Application.Goals.Dtos;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackItApi.Common;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Goals.Implements
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private IGoalValidationService _goalValidationService;
        public GoalService(IGoalRepository goalRepository, IGoalValidationService goalValidationService)
        {
            _goalRepository = goalRepository;
            _goalValidationService = goalValidationService;
        }
        public async Task<GoalViewDto> GetGoal(long goalId)
        {
            var goalEntity = await _goalRepository.GetByIdAsync(goalId);
            var goal = goalEntity.Adapt<GoalViewDto>();
            return goal;
        }

        public async Task<IList<GoalViewDto>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate)
        {
            var goals = await _goalRepository.FindAsync(x => x.Plan.StartDate.Date >= startDate && x.Plan.EndDate <= endDate);
            return goals.Adapt<IList<GoalViewDto>>();
        }

        public async Task<IList<GoalViewDto>> GetGoalsByPlanId(long planId)
        {
            var goals = await _goalRepository.FindAsync(x => x.PlanId == planId);
            return goals.Adapt<IList<GoalViewDto>>();
        }

        public async Task<OperationResult> Insert(CreationGoalDto goal)
        {
            var operationResult = new OperationResult();
            var validdateResult = await _goalValidationService.IsTargetDateValid(goal);
            if (validdateResult)
            {
                /// exception handling
            }
            var goalEntity = new Goal(goal.Title, goal.Description, goal.TargetDate, goal.PlanId);
            await _goalRepository.AddAsync(goalEntity);
            operationResult.Succed();
            return operationResult;
        }
        public async Task<OperationResult> BulkInsert(IList<CreationGoalDto> goals)
        {
            var operationResult = new OperationResult();
            var goalEntities = new List<Goal>(goals.Count());
            foreach (var goal in goals)
            {
                var validdateResult = await _goalValidationService.IsTargetDateValid(goal);
                if (validdateResult)
                {
                    /// exception handling
                }
                var goalEntity = new Goal(goal.Title, goal.Description, goal.TargetDate, goal.PlanId);
                goalEntities.Add(goalEntity);
            }
            await _goalRepository.AddRangeAsync(goalEntities);
            operationResult.Succed();
            return operationResult;
        }
        public async Task<OperationResult> RemoveGoal(long goalId)
        {
            var operationResult = new OperationResult();
            await _goalRepository.RemoveAsync(goalId);
            operationResult.Succed();
            return operationResult;
        }

        public async Task<OperationResult> UpdateGoal(UpdateGoalDto goal)
        {
            var operationResult = new OperationResult();
            var validdateResult = await _goalValidationService.IsTargetDateValid(goal);
            if (validdateResult)
            {
                /// exception handling
            }
            var goalEntity = goal.Adapt<Goal>();
            goalEntity.LastUpdate = DateTime.Now;
            await _goalRepository.UpdateAsync(goalEntity);
            operationResult.Succed();
            return operationResult;
        }
    }
}
