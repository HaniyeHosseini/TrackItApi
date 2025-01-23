using Mapster;
using TrackApi.Application.Goals.Contracts;
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
        private readonly IGoalService  _goalService;
        private readonly IPlanValidationService _planValidationService;
        public PlanService(IPlanRepository planRepository, IGoalService goalService, IPlanValidationService planValidationService)
        {
            _planRepository = planRepository;
            _goalService = goalService;
            _planValidationService = planValidationService;
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
            var duplicateResult = await _planValidationService.IsPlanDuplicate(plan);
            if (duplicateResult)
            {
                /// exception handling
            }
            var entity = new Plan(plan.PlanType, plan.StartDate, plan.EndDate, plan.ParentPlanId, plan.Description);
            var goals = plan.Goals;
            await _planRepository.AddAsync(entity);
            await _goalService.BulkInsert(goals);
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
            var duplicateResult = await _planValidationService.IsPlanDuplicate(plan);
            if (duplicateResult)
            {
                /// exception handling
            }
            var entity = plan.Adapt<Plan>();
            entity.LastUpdate = DateTime.Now;
            await _planRepository.UpdateAsync(entity);
            operationResult.Succed();
            return operationResult;
        }
    }
}
