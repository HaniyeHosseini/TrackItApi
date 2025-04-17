using Mapster;
using TrackApi.Application.DTOs.Job;
using TrackApi.Application.Exceptions;
using TrackApi.Infrastructure.Repositories.Jobs;
using TrackItApi.Domain.Enums;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<OutputJobDto> GetGoal(long jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);
            return job.Adapt<OutputJobDto>();
        }

        public async Task<IList<OutputJobDto>> GetJobsByDateFilter(DateTime? startDate, DateTime? endDate)
        {
            var jobs = await _jobRepository.GetJobsByDateFilter(startDate, endDate);
            return jobs.Adapt<IList<OutputJobDto>>();
        }

        public async Task<IList<OutputJobDto>> GetJobsByGoalId(long goalId)
        {
            var jobs = await _jobRepository.GetJobsByGoalId(goalId);
            return jobs.Adapt<List<OutputJobDto>>();
        }

        public async Task<OutputJobDto> Insert(InputCreationJobDto job)
        {
            var priorityLevel = (int)Enum.Parse(typeof(PriorityLevel), job.PriorityLevel);
            if (priorityLevel < 0) throw new CustomInvalidDataException("مقدار اولویت معتبر نمی باشد");
            var entityJob = new Job(job.Title, job.Description, job.StartDate, job.EndDate, (PriorityLevel)priorityLevel, job.GoalId, job.ParentJobId);
            await _jobRepository.AddAsync(entityJob);
            return entityJob.Adapt<OutputJobDto>();
        }

        public async Task<bool> Remove(long jobId)
        {
            var entity = await _jobRepository.GetByIdAsync(jobId);
            if (entity == null) throw new RecordNotFoundException();
            await _jobRepository.RemoveAsync(jobId);
            return true;
        }

        public async Task<OutputJobDto> Update(InputUpdateJobDto job)
        {
            var entity = await _jobRepository.GetByIdAsync(job.Id);
            var priorityLevel = (int)Enum.Parse(typeof(PriorityLevel), job.PriorityLevel);

            if (entity == null) throw new RecordNotFoundException();
            entity.Title = job.Title;
            entity.Description = job.Description;
            entity.StartDate = job.StartDate;
            entity.EndDate = job.EndDate;
            entity.GoalId = job.GoalId;
            entity.ParentJobId = job.ParentJobId;
            entity.LastUpdate = DateTime.Now;
            entity.PriorityLevel = (PriorityLevel)priorityLevel;
            await _jobRepository.UpdateAsync(entity);
            return entity.Adapt<OutputJobDto>();

        }
    }
}
