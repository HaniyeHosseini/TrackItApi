namespace TrackItApi.Domain.Models
{
    public class JobTag
    {
        public long JobId { get; set; }
        public long TagId { get; set; }

        public JobTag(long jobId, long tagId)
        {
            JobId = jobId;
            TagId = tagId;
        }
    }
}
