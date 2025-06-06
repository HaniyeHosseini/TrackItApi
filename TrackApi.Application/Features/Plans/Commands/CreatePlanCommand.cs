using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TrackApi.Application.Features.Plans.Dtos;
using TrackItApi.Common;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Plans.Commands
{
    public class CreatePlanCommand : IRequest<OutputPlanDto>
    {
        public InputCreationPlanDto InputCreationPlanDto { get; }

        public CreatePlanCommand(InputCreationPlanDto inputCreationPlanDto)
        {
            InputCreationPlanDto = inputCreationPlanDto;
        }
    }
}
