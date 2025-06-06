using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersianDate.Standard;
using System.Net;
using TrackApi.Application.Features.Goals.Queries;
using TrackApi.Application.Features.Jobs.Commands;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackApi.Application.Features.Jobs.Queries;
using TrackItApi.Common;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ByJobId/{jobId}")]
        public async Task<IActionResult> GetJob(long jobId)
        {
            var job = await _mediator.Send(new GetJobByIdQuery(jobId));
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.OK));

        }
        [HttpGet("ByGoalId/{goalId}")]
        public async Task<IActionResult> GetJobs(long goalId)
        {
            var jobs = await _mediator.Send(new GetJobsByGoalIdQuery(goalId));
            return Ok(OperationResult<IList<OutputJobDto>>.Success(jobs, HttpStatusCode.OK));

        }
        [HttpGet]
        public async Task<IActionResult> GetJobs([FromQuery] string? startDate, [FromQuery] string? endDate)
        {
            var jobs = await _mediator.Send(new GetJobsByDateFilterQuery(startDate?.ToEn(), endDate?.ToEn()));
            return Ok(OperationResult<IList<OutputJobDto>>.Success(jobs, HttpStatusCode.OK));
        }
        [HttpPost]
        public async Task<IActionResult> InsertJobToGoal(InputCreationJobDto jobDto)
        {
            var job = await _mediator.Send(new CreateJobCommand(jobDto));
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.Created));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateJob(InputUpdateJobDto jobDto)
        {
            var job = await _mediator.Send(new UpdateJobCommand(jobDto));
            return Ok(OperationResult<OutputJobDto>.Success(job, HttpStatusCode.OK));
        }
        [HttpDelete("{jobId}")]
        public async Task<IActionResult> RemoveJob(long jobId)
        {
            var result = await _mediator.Send(new DeleteJobCommand(jobId));
            return Ok(OperationResult<bool>.Success(true, HttpStatusCode.OK));
        }
    }
}
