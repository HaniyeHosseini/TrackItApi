using TrackApi.Application.Goals.Dtos;

namespace TrackApi.Application.Plans.Dtos
{
    public class UpdatePlanDto :BasePlanDto
    {
        public long Id { get; set; }
        public IList<UpdateGoalDto> Goals { get; set; }
    }
}
