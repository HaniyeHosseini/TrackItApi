using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItApi.Domain.Models
{
    public class Tag : BaseModel
    {
        public string Title { get; set; }

        public Tag(string title)
        {
            Title = title;
        }
    }
}
