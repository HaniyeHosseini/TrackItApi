using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Plans.Dtos;

namespace TrackApi.Application.Features.Plans.Queries
{
    public class GetPlanByIdQuery : IRequest<OutputPlanDto>
    {
        public long PlanId { get; }

        public GetPlanByIdQuery(long planId)
        {
            PlanId = planId;
        }
    }
}
