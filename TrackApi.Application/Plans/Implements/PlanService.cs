using Mapster;
using TrackApi.Application.DTOs.Plan;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Infrastructure.Repositories.Plans;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Plans.Implements
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IPlanValidationService _planValidationService;
        private readonly IGoalService _goalService;
        public PlanService(IPlanRepository planRepository, IPlanValidationService planValidationService, IGoalService goalService)
        {
            _planRepository = planRepository;
            _planValidationService = planValidationService;
            _goalService = goalService;
        }

        public async Task<IList<OutputPlanDto>> GetAllPlans()
        {
            var plans = await _planRepository.GetAllPlansWithGoals();
            var planViews = plans.Adapt<IList<OutputPlanDto>>();
            return planViews;
        }

        public async Task<OutputPlanDto?> GetPlanByPlanId(long planId)
        {
            var plan = await _planRepository.GetPlanByPlanId(planId) ?? throw new RecordNotFoundException();
            var goals = await _goalService.GetGoalsByPlanId(planId);
            var planView = plan.Adapt<OutputPlanDto>();
            planView.Goals = goals;
            return planView;
        }

        public async Task<OutputPlanDto> Insert(InputCreationPlanDto plan)
        {
            var duplicateResult = await _planValidationService.IsPlanDuplicate(plan);
            if (duplicateResult)
            {
                throw new DuplicateException();
            }
            var entity = new Plan(plan.PlanType, plan.StartDate, plan.EndDate, plan.ParentPlanId.HasValue ? plan.ParentPlanId.Value : null, plan.Description);
            await _planRepository.AddAsync(entity);
            var planDto = entity.Adapt<OutputPlanDto>();
            return planDto;
        }

        public async Task<bool> Remove(long planId)
        {
            var entity = await _planRepository.GetByIdAsync(planId);
            if(entity == null) throw new RecordNotFoundException();
            await _planRepository.RemovePlanWithGoals(planId);
            return true;

        }

        public async Task<OutputPlanDto> Update(InputUpdatePlanDto plan)
        {
            var entity = await _planRepository.GetByIdAsync(plan.Id) ?? throw new RecordNotFoundException();
            var duplicateResult = await _planValidationService.IsPlanDuplicate(plan);
            if (duplicateResult)
            {
                throw new DuplicateException();
            }
            entity.PlanType = plan.PlanType;
            entity.StartDate = plan.StartDate;
            entity.EndDate = plan.EndDate;
            entity.ParentPlanId = plan.ParentPlanId;
            entity.LastUpdate = DateTime.Now;
            entity.Description = plan.Description;
            await _planRepository.UpdateAsync(entity);
            var planDto = entity.Adapt<OutputPlanDto>();
            return planDto;
        }
    }
}
