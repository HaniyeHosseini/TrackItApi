using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Jobs;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Job : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel  Prioritylevel { get; set; }
        public Status Status { get; set; }
        public long GoalId { get; set; }
        public Goal Goal { get; set; }
        public long? ParentJobId { get; set; }
        public Job? ParentJob { get; set; }
        public Collection<Job> ChildJobs { get; set; }
        public Job(string title, string description, DateTime startDate, DateTime endDate, PriorityLevel prioritylevel, long goalId, long? parentJobId)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Prioritylevel = prioritylevel;
            GoalId = goalId;
            ParentJobId = parentJobId;
        }
    }
}
