using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.DTOs.Goal;
using TrackApi.Application.DTOs.Job;

namespace TrackApi.Application.Services.Jobs
{
    public interface IJobService
    {
        Task<OutputJobDto> Insert(InputCreationJobDto job);
        Task<OutputJobDto> Update(InputUpdateJobDto job);
        Task<bool> Remove(long jobId);
        Task<OutputJobDto> GetGoal(long jobId);
        Task<IList<OutputJobDto>> GetJobsByGoalId(long goalId);
        Task<IList<OutputJobDto>> GetJobsByDateFilter(DateTime? startDate, DateTime? endDate);
    }
}
