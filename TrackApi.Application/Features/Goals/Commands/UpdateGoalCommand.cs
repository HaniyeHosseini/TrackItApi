using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Dtos;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class UpdateGoalCommand : IRequest<OutputGoalDto>
    {
        public InputUpdateGoalDto InputUpdateGoalDto { get; }

        public UpdateGoalCommand(InputUpdateGoalDto inputUpdateGoalDto)
        {
            InputUpdateGoalDto = inputUpdateGoalDto;
        }
    }
}
