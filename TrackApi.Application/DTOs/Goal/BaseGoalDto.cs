namespace TrackApi.Application.DTOs.Goal
{
    public class BaseGoalDto
    {
        public long PlanId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
