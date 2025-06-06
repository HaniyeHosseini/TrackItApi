using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Dtos;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalsByPlanIdQuery : IRequest<List<OutputGoalDto>>
    {
        public long PlanId { get; }

        public GetGoalsByPlanIdQuery(long planId)
        {
            PlanId = planId;
        }
    }
}
