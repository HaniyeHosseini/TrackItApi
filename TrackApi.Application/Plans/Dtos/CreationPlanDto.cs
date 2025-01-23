using TrackApi.Application.Goals.Dtos;

namespace TrackApi.Application.Plans.Dtos
{
    public class CreationPlanDto:BasePlanDto
    {
        public IList<CreationGoalDto> Goals { get; set; }
    }
}
