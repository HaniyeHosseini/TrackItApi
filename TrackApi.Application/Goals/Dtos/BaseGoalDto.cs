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
