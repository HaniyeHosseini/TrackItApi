using Mapster;
using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Plans.Dtos;
using TrackApi.Application.Features.Plans.Services;
using TrackApi.Infrastructure.Repositories.Plans.Commands;
using TrackApi.Infrastructure.Repositories.Plans.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Plans.Commands
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, OutputPlanDto>
    {
        private readonly IPlanCommandRepository _planCommandRepository;
        private readonly IPlanValidationService _planValidationService;
        public CreatePlanCommandHandler(IPlanCommandRepository planCommandRepository, IPlanValidationService planValidationService)
        {
            _planCommandRepository = planCommandRepository;
            _planValidationService = planValidationService;
        }

        public async Task<OutputPlanDto> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var duplicateResult = await _planValidationService.IsPlanDuplicate(request);
            if (duplicateResult)
            {
                throw new DuplicateException();
            }
            var inputPlan = request.InputCreationPlanDto;
            var entity = new Plan(inputPlan.PlanType, inputPlan.StartDate, inputPlan.EndDate, inputPlan.ParentPlanId.HasValue ? inputPlan.ParentPlanId.Value : null, inputPlan.Description);
            await _planCommandRepository.AddAsync(entity);
            var planDto = entity.Adapt<OutputPlanDto>();
            return planDto;
        }
    }
}
