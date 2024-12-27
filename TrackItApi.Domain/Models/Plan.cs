using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Jobs;
using TrackItApi.Domain.Enums;

namespace TrackItApi.Domain.Models
{
    public class Plan : BaseModel
    {
        public PlanType PlanType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? ParentPlanId { get; set; }
        public virtual Plan? ParentPlan { get; set; }
        public string? Description { get; set; }
        public Collection<Goal> Goals { get; set; }
        public Collection<Plan> ChildPlans { get; set; }

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
