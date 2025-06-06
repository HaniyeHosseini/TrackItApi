using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobsByDateFilterQuery : IRequest<List<OutputJobDto>>
    {
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public GetJobsByDateFilterQuery(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
