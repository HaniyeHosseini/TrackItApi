using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Dtos;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalsByDateFilterQuery : IRequest<List<OutputGoalDto>>

    {
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        public GetGoalsByDateFilterQuery(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
