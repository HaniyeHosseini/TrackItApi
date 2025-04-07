using Microsoft.AspNetCore.Mvc;
using PersianDate.Standard;
using System.Globalization;
using System.Net;
using TrackApi.Application.DTOs.Goal;
using TrackApi.Application.Services.Goals;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("ByGoalId/{goalId}")]
        public async Task<IActionResult> GetGoal(long goalId)
        {
            var goal = await _goalService.GetGoal(goalId);
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.OK));

        }
        [HttpGet("ByPlanId/{planId}")]
        public async Task<IActionResult> GetGoals(long planId)
        {
            var goals = await _goalService.GetGoalsByPlanId(planId);
            return Ok(OperationResult<IList<OutputGoalDto>>.Success(goals, HttpStatusCode.OK));

        }
        [HttpGet]
        public async Task<IActionResult> GetGoals([FromQuery]string? startDate , [FromQuery] string? endDate)
        {
            var goals = await _goalService.GetGoalsByDateFilter(startDate?.ToEn(),endDate?.ToEn());
            return Ok(OperationResult<IList<OutputGoalDto>>.Success(goals, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> InsertGoalToPlan(InputCreationGoalDto goalDto)
        {
            var goal = await _goalService.Insert(goalDto);
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.Created));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateGoal(InputUpdateGoalDto goalDto)
        {
            var goal = await _goalService.UpdateGoal(goalDto);
            return Ok(OperationResult<OutputGoalDto>.Success(goal, HttpStatusCode.OK));

        }
        [HttpDelete("{goalId}")]
        public async Task<IActionResult> RemoveGoal(long goalId)
        {
            var result =await _goalService.RemoveGoal(goalId);
            return Ok(OperationResult<bool>.Success(result, HttpStatusCode.OK));

        }
    }
}
