using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Dtos;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalByIdQuery : IRequest<OutputGoalDto>
    {
        public long GoalId { get; }

        public GetGoalByIdQuery(long goalId)
        {
            GoalId = goalId;
        }
    }
}
