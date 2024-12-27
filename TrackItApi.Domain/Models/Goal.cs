using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Goal : BaseModel
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
        public Status Status { get; set; }
        public long PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public Goal(string title, string? description, DateTime targetDate, long planId)
        {
            Title = title;
            Description = description;
            TargetDate = targetDate;
            PlanId = planId;
        }
    }
}
