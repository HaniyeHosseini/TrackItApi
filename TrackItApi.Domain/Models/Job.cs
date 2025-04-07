using System.Collections.ObjectModel;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Job : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel  PriorityLevel { get; set; }
        public Status Status { get; set; }
        public long GoalId { get; set; }
        public long? ParentJobId { get; set; }
        public Job(string title, string description, DateTime startDate, DateTime endDate, PriorityLevel priorityLevel, long goalId, long? parentJobId)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            PriorityLevel = priorityLevel;
            GoalId = goalId;
            ParentJobId = parentJobId;
        }
    }
}
