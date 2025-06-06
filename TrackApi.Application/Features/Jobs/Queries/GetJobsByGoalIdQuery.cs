using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobsByGoalIdQuery : IRequest<List<OutputJobDto>>
    {
        public long GoalId { get; }
        public GetJobsByGoalIdQuery(long goalId)
        {
            GoalId = goalId;
        }
    }
}
