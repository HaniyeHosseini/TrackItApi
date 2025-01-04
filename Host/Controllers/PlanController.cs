using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Plans.Dtos;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public async Task<IList<PlanViewDto>> GetAllPlans()
        {
            var plans = await _planService.GetAllPlansWithGoals();
            return plans;
        }
        [HttpGet("{planId}")]
        public async Task<PlanViewDto?> GetPlanById(long planId)
        {
            var plan = await _planService.GetPlanWithGoalsByPlanId(planId);
            return plan;
        }
        [HttpPost]
        public async Task<OperationResult> InsertPlanWithGoals(CreationPlanDto creationPlanDto)
        {
           var result = await _planService.Insert(creationPlanDto);
            return result;
        }
        [HttpPut]
        public async Task<OperationResult> UpdatePlanWithGoals(UpdatePlanDto updatePlanDto)
        {
           var result = await _planService.Update(updatePlanDto);
            return result;
        }
        [HttpDelete]
        public async Task<OperationResult> DeletePlanById(long planId)
        {
          var result = await  _planService.Remove(planId);
            return result;
        }
    }
}
