using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Dtos;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class CreateGoalCommand : IRequest<OutputGoalDto>
    {
        public InputCreationGoalDto InputCreationGoalDto { get; }

        public CreateGoalCommand(InputCreationGoalDto inputCreationGoalDto)
        {
            InputCreationGoalDto = inputCreationGoalDto;
        }
    }
}
