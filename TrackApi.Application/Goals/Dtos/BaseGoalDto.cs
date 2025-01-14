using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackApi.Application.Goals.Dtos
{
    public class BaseGoalDto
    {
        public int PlanId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
