using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Plans.Dtos
{
    public class BasePlanDto
    {
        public PlanType PlanType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? ParentPlanId { get; set; }
        public string? Description { get; set; }
    }
}
