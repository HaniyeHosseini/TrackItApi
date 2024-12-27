using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackItApi.Domain.Models
{
    public class JobTag
    {
        public long JobId { get; set; }
        public Job Job { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }

        public JobTag(long JobId, long tagId)
        {
            JobId = JobId;
            TagId = tagId;
        }
    }
}
