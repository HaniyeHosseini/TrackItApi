using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Plans.Dtos;
using TrackApi.Infrastructure.Repositories.Goals;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackItApi.Common;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Plans.Implements
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IGoalRepository _goalRepository;
        public PlanService(IPlanRepository planRepository, IGoalRepository goalRepository)
        {
            _planRepository = planRepository;
            _goalRepository = goalRepository;
        }

        public async Task<IList<PlanViewDto>> GetAllPlansWithGoals()
        {
            var plans = await _planRepository.GetAllPlansWithGoals();
            var planViews = plans.Adapt<IList<PlanViewDto>>();
            return planViews;
        }

        public async Task<PlanViewDto?> GetPlanWithGoalsByPlanId(long planId)
        {
            var plan = await _planRepository.GetPlanWithGoalsByPlanId(planId);
            var planView = plan.Adapt<PlanViewDto>();
            return planView;
        }

        public async Task<OperationResult> Insert(CreationPlanDto plan)
        {
            var operationResult = new OperationResult();
            var entity = new Plan(plan.PlanType, plan.StartDate, plan.EndDate, plan.ParentPlanId, plan.Description);
            var goals = new List<Goal>(plan.Goals.Count);
            await _planRepository.AddAsync(entity);
            foreach (var goal in plan.Goals)
            {
                var goalEntity = new Goal(goal.Title, goal.Description, goal.TargetDate, entity.Id);
                goals.Add(goalEntity);
            }
            await _goalRepository.AddRangeAsync(goals);
            operationResult.Succed();
            return operationResult;
        }

        public async Task<OperationResult> Remove(long planId)
        {
            var operationResult = new OperationResult();
            await _planRepository.RemovePlanWithGoals(planId);
            operationResult.Succed();
            return operationResult;
        }

        public async Task<OperationResult> Update(UpdatePlanDto plan)
        {
            var operationResult = new OperationResult();
            var entity = plan.Adapt<Plan>();
            entity.LastUpdate = DateTime.Now;
            await _planRepository.UpdateAsync(entity);
            operationResult.Succed();
            return operationResult;
        }
    }
}
