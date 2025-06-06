using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersianDate.Standard;
using System.Globalization;
using System.Net;
using TrackApi.Application.Features.Goals.Commands;
using TrackApi.Application.Features.Goals.Dtos;
using TrackApi.Application.Features.Goals.Queries;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ByGoalId/{goalId}")]
        public async Task<IActionResult> GetGoal(long goalId)
        {
            var goal = await _mediator.Send(new GetGoalByIdQuery(goalId));
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.OK));
        }
        [HttpGet("ByPlanId/{planId}")]
        public async Task<IActionResult> GetGoals(long planId)
        {
            var goals = await _mediator.Send(new GetGoalsByPlanIdQuery(planId));
            return Ok(OperationResult<IList<OutputGoalDto>>.Success(goals, HttpStatusCode.OK));

        }
        [HttpGet]
        public async Task<IActionResult> GetGoals([FromQuery] string? startDate, [FromQuery] string? endDate)
        {
            var goals = await _mediator.Send(new GetGoalsByDateFilterQuery(startDate?.ToEn(), endDate?.ToEn()));
            return Ok(OperationResult<IList<OutputGoalDto>>.Success(goals, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> InsertGoalToPlan(InputCreationGoalDto goalDto)
        {
            var goal = await _mediator.Send(new CreateGoalCommand(goalDto));
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.Created));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGoal(InputUpdateGoalDto goalDto)
        {
            var goal = await _mediator.Send(new UpdateGoalCommand(goalDto));
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.OK));

        }
        [HttpDelete("{goalId}")]
        public async Task<IActionResult> RemoveGoal(long goalId)
        {
            await _mediator.Send(new DeleteGoalCommand(goalId));
            return Ok(OperationResult<bool>.Success(true, HttpStatusCode.OK));

        }
    }
}
