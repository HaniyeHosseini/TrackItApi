using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Goals.Dtos;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Plans.Dtos
{
    public class PlanViewDto:BasePlanDto
    {
        public long Id { get; set; }
      
        public IList<GoalViewDto> Goals { get; set; }
    }
}
