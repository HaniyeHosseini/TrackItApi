using Microsoft.AspNetCore.Mvc;
using TrackApi.Application.Goals.Contracts;
using TrackApi.Application.Goals.Dtos;

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

        [HttpGet("{goalId}")]
        public async Task<GoalViewDto> GetGoal(long goalId)
        {
            return await _goalService.GetGoal(goalId);
        }
        [HttpGet]
        public async Task<IList<GoalViewDto>> GetGoal([FromQuery]DateTime? startDate , [FromQuery] DateTime? endDate)
        {
            var goals = await _goalService.GetGoalsByDateFilter(startDate,endDate);
            return goals;
        }
        [HttpPost]
        public async Task InsertGoalToPlan(CreationGoalDto goalDto)
        {
            await _goalService.BulkInsert(goalDto);
        }
        [HttpPut]
        public async Task UpdateGoal(UpdateGoalDto goalDto)
        {
            await _goalService.UpdateGoal(goalDto);
        }
        [HttpDelete]
        public async Task RemoveGoal(long goalId)
        {
            await _goalService.RemoveGoal(goalId);
        }
    }
}
