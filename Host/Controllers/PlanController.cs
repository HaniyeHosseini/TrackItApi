using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrackApi.Application.Features.Plans.Commands.Create;
using TrackApi.Application.Features.Plans.Commands.Delete;
using TrackApi.Application.Features.Plans.Commands.Update;
using TrackApi.Application.Features.Plans.Dtos;
using TrackApi.Application.Features.Plans.Queries;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : ControllerBase
    {
       private readonly IMediator _mediator;

        public PlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _mediator.Send(new GetAllPlansQuery());
            return Ok(OperationResult<IList<OutputPlanDto>>.Success(plans, HttpStatusCode.OK));
        }
        [HttpGet("{planId}")]
        public async Task<IActionResult?> GetPlanById(long planId)
        {
            var plan = await _mediator.Send(new GetPlanByIdQuery(planId));
            return Ok(OperationResult<OutputPlanDto>.Success(plan, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InputCreationPlanDto creationPlanDto)
        {
            var data = await _mediator.Send(new CreatePlanCommand(creationPlanDto));
            return Ok(OperationResult<OutputPlanDto>.Success(data, HttpStatusCode.Created));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InputUpdatePlanDto updatePlanDto)
        {
            var result = await _mediator.Send(new UpdatePlanCommand(updatePlanDto));
            return Ok(OperationResult<OutputPlanDto>.Success(result, HttpStatusCode.OK));
        }
        [HttpDelete("{planId}")]
        public async Task<IActionResult> DeletePlanById(long planId)
        {
            var result = await _mediator.Send(new DeletePlanCommand(planId));
            return Ok(OperationResult<bool>.Success(true, HttpStatusCode.OK));
        }
    }
}
