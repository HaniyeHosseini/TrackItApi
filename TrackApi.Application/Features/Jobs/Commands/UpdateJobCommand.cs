using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class UpdateJobCommand : IRequest<OutputJobDto>
    {
        public InputUpdateJobDto InputUpdateJobDto { get; }
        public UpdateJobCommand(InputUpdateJobDto inputUpdateJobDto)
        {
            InputUpdateJobDto = inputUpdateJobDto;
        }
    }
}
