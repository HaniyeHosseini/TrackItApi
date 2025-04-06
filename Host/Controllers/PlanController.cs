using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackApi.Application.DTOs.Plan;
using TrackApi.Application.Plans.Contracts;
using TrackApi.Application.Validators;
using TrackItApi.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _planService.GetAllPlans();
            return Ok(OperationResult<IList<OutputPlanDto>>.Success(plans, HttpStatusCode.OK));
        }
        [HttpGet("{planId}")]
        public async Task<IActionResult?> GetPlanById(long planId)
        {
            var plan = await _planService.GetPlanByPlanId(planId);
            return Ok(OperationResult<OutputPlanDto>.Success(plan, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InputCreationPlanDto creationPlanDto)
        {
            var data = await _planService.Insert(creationPlanDto);
            return Ok(OperationResult<OutputPlanDto>.Success(data, HttpStatusCode.Created));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InputUpdatePlanDto updatePlanDto)
        {
            var result = await _planService.Update(updatePlanDto);
            return Ok(OperationResult<OutputPlanDto>.Success(result, HttpStatusCode.OK));
        }
        [HttpDelete("{planId}")]
        public async Task<IActionResult> DeletePlanById(long planId)
        {
            var result = await _planService.Remove(planId);
            return Ok(OperationResult<bool>.Success(true, HttpStatusCode.OK));
        }
    }
}
