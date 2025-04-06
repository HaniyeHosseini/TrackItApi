using Mapster;
using TrackApi.Application.DTOs.Goal;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Goals.Implements
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IPlanRepository _planRepository;
        public GoalService(IGoalRepository goalRepository, IPlanRepository planRepository)
        {
            _goalRepository = goalRepository;
            _planRepository = planRepository;
        }
        public async Task<OutputGoalDto> GetGoal(long goalId)
        {
            var goalEntity = await _goalRepository.GetByIdAsync(goalId);
            var goal = goalEntity.Adapt<OutputGoalDto>();
            return goal;
        }

        public async Task<IList<OutputGoalDto>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate)
        {
            var goals = await _goalRepository.GetGoalsByDateFilter(startDate,endDate);
            return goals.Adapt<IList<OutputGoalDto>>();
        }

        public async Task<IList<OutputGoalDto>> GetGoalsByPlanId(long planId)
        {
            var goals = await _goalRepository.FindAsync(x => x.PlanId == planId);
            return goals.Adapt<IList<OutputGoalDto>>();
        }

        public async Task<OutputGoalDto> Insert(InputCreationGoalDto goal)
        {
            var plan = await _planRepository.GetByIdAsync(goal.PlanId) ?? throw new RecordNotFoundException();
            if (goal.TargetDate > plan.EndDate) throw new CustomInvalidDataException(".تاریخ هدف باید کوچکتر از تاریخ پایان برنامه زمانی باشد");
            var goalEntity = new Goal(goal.Title, goal.Description, goal.TargetDate, goal.PlanId);
            await _goalRepository.AddAsync(goalEntity);
            var data = goalEntity.Adapt<OutputGoalDto>();
            return data;
        }
        public async Task< IEnumerable<OutputGoalDto>> BulkInsert(IList<InputCreationGoalDto> goals)
        {
            var goalEntities = new List<Goal>(goals.Count());
            var plan = await _planRepository.GetByIdAsync(goals.First().PlanId) ?? throw new RecordNotFoundException();
            foreach (var goal in goals)
            {
                if (goal.TargetDate > plan.EndDate) throw new CustomInvalidDataException(".تاریخ هدف باید کوچکتر از تاریخ پایان برنامه زمانی باشد");
                var goalEntity = new Goal(goal.Title, goal.Description, goal.TargetDate, goal.PlanId);
                goalEntities.Add(goalEntity);
            }
            await _goalRepository.AddRangeAsync(goalEntities);
            var data = goalEntities.Adapt<IEnumerable<OutputGoalDto>>();
            return data;
        }
        public async Task<bool> RemoveGoal(long goalId)
        {
            await _goalRepository.RemoveAsync(goalId);
            return true;
        }

        public async Task<OutputGoalDto> UpdateGoal(InputUpdateGoalDto goal)
        {
            var plan = await _planRepository.GetByIdAsync(goal.PlanId) ?? throw new RecordNotFoundException();
            if (goal.TargetDate > plan.EndDate) throw new CustomInvalidDataException(".تاریخ هدف باید کوچکتر از تاریخ پایان برنامه زمانی باشد");
            var goalEntity =await _goalRepository.GetByIdAsync(goal.Id);
            goalEntity.Description = goal.Description;
            goalEntity.TargetDate = goal.TargetDate;
            goalEntity.Title = goal.Title;
            goalEntity.PlanId = goal.PlanId;
            goalEntity.LastUpdate = DateTime.Now;
            await _goalRepository.UpdateAsync(goalEntity);
            var data = goalEntity.Adapt<OutputGoalDto>();
            return data;
        }
    }
}
