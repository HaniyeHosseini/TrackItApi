using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel  Prioritylevel { get; set; }
        public Status Status { get; set; }
        public long GoalId { get; set; }
        public Goal Goal { get; set; }
        public long? ParentTaskId { get; set; }
        public Task? ParentTask { get; set; }

        public Task(string title, string description, DateTime startDate, DateTime endDate, PriorityLevel prioritylevel, long goalId, long? parentTaskId)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Prioritylevel = prioritylevel;
            GoalId = goalId;
            ParentTaskId = parentTaskId;
        }
    }
}
