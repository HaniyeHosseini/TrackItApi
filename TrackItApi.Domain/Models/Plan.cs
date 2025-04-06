using System.Collections.ObjectModel;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Plan : BaseModel
    {
        public PlanType PlanType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? ParentPlanId { get; set; }
        public string? Description { get; set; }

        public Plan(PlanType planType, DateTime startDate, DateTime endDate, long? parentPlanId, string? description )
        {
            PlanType = planType;
            StartDate = startDate;
            EndDate = endDate;
            ParentPlanId = parentPlanId;
            Description = description;
        }
    }
}
