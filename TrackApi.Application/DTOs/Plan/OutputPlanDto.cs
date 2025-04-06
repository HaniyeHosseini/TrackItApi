using TrackApi.Application.DTOs.Goal;

namespace TrackApi.Application.DTOs.Plan;
public class OutputPlanDto : BasePlanDto
{
    public long Id { get; set; }

    public IList<OutputGoalDto> Goals { get; set; }

}
