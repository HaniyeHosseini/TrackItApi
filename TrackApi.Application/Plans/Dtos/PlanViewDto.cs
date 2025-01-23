using TrackApi.Application.Goals.Dtos;

namespace TrackApi.Application.Plans.Dtos
{
    public class PlanViewDto:BasePlanDto
    {
        public long Id { get; set; }
      
        public IList<GoalViewDto> Goals { get; set; }
    }
}
