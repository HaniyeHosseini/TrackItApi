using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Plans.Dtos;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackItApi.Common;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Plans.Implements
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
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
            await _planRepository.AddAsync(entity);
            operationResult.Succed();
            return operationResult;
        }

        public async Task<OperationResult> Remove(long planId)
        {
            var operationResult = new OperationResult();
            await _planRepository.DeleteAsync(planId);
            operationResult.Succed();
            return operationResult;
        }

        public async Task<OperationResult> Update(UpdatePlanDto plan)
        {
            var operationResult = new OperationResult();
            var entity = plan.Adapt<Plan>();
          await  _planRepository.UpdateAsync(entity);
            operationResult.Succed();
            return operationResult;
        }
    }
}
