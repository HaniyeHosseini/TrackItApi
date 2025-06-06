using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Jobs.Dtos
{
    public class BaseJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PriorityLevel { get; set; }
        public string Status { get; set; }
        public long GoalId { get; set; }
        public long? ParentJobId { get; set; }
    }
}
