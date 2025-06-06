namespace TrackApi.Application.Features.Goals.Dtos
{
    public class InputCreationGoalDto : BaseGoalDto
    {
        public long PlanId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}

