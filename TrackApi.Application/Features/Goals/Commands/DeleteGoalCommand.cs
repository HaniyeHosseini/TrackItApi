using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class DeleteGoalCommand : IRequest<Unit>
    {
        public long GoalId { get;  }

        public DeleteGoalCommand(long goalId)
        {
            GoalId = goalId;
        }
    }
}
