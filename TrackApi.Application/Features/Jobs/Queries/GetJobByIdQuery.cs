using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobByIdQuery : IRequest<OutputJobDto>
    {
        public long JobId { get; }

        public GetJobByIdQuery(long jobId)
        {
            JobId = jobId;
        }
    }
}
