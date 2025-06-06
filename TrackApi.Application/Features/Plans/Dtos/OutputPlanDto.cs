using TrackApi.Application.Features.Goals.Dtos;

namespace TrackApi.Application.Features.Plans.Dtos;
public class OutputPlanDto : BasePlanDto
{
    public long Id { get; set; }

    public IList<OutputGoalDto> Goals { get; set; }

}
