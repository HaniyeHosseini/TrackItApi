using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersianDate.Standard;
using System.Net;
using TrackApi.Application.DTOs.Job;
using TrackApi.Application.Services.Jobs;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet("ByJobId/{jobId}")]
        public async Task<IActionResult> GetJob(long jobId)
        {
            var job = await _jobService.GetJob(jobId);
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.OK));

        }
        [HttpGet("ByGoalId/{goalId}")]
        public async Task<IActionResult> GetJobs(long goalId)
        {
            var jobs = await _jobService.GetJobsByGoalId(goalId);
            return Ok(OperationResult<IList<OutputJobDto>>.Success(jobs, HttpStatusCode.OK));

        }
        [HttpGet]
        public async Task<IActionResult> GetJobs([FromQuery] string? startDate, [FromQuery] string? endDate)
        {
            var jobs = await _jobService.GetJobsByDateFilter(startDate?.ToEn(), endDate?.ToEn());
            return Ok(OperationResult<IList<OutputJobDto>>.Success(jobs, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> InsertJobToGoal(InputCreationJobDto jobDto)
        {
            var job = await _jobService.Insert(jobDto);
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.Created));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateJob(InputUpdateJobDto jobDto)
        {
            var job = await _jobService.Update(jobDto);
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.OK));

        }
        [HttpDelete("{jobId}")]
        public async Task<IActionResult> RemoveJob(long jobId)
        {
            var result = await _jobService.Remove(jobId);
            return Ok(OperationResult<bool>.Success(result, HttpStatusCode.OK));

        }
    }
}
