using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItApi.Domain.Models
{
    public class TaskTag
    {
        public long TaskId { get; set; }
        public Task Task { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }

        public TaskTag(long taskId, long tagId)
        {
            TaskId = taskId;
            TagId = tagId;
        }
    }
}
