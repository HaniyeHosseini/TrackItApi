using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class CreateJobCommand : IRequest<OutputJobDto>
    {
        public InputCreationJobDto InputCreationJobDto { get; }

        public CreateJobCommand(InputCreationJobDto inputCreationJobDto)
        {
            InputCreationJobDto = inputCreationJobDto;
        }
    }
}
