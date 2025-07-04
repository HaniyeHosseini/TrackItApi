using MediatR;
using TrackApi.Application.Features.Plans.Dtos;

namespace TrackApi.Application.Features.Plans.Commands.Create
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
