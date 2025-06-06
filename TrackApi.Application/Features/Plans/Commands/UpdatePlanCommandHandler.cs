using Mapster;
using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Plans.Dtos;
using TrackApi.Application.Features.Plans.Services;
using TrackApi.Infrastructure.Repositories.Plans.Commands;
using TrackApi.Infrastructure.Repositories.Plans.Queries;

namespace TrackApi.Application.Features.Plans.Commands
{
    public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, OutputPlanDto>
    {
        private readonly IPlanQueryRepository _planQueryRepository;
        private readonly IPlanCommandRepository _planCommandRepository;
        private readonly IPlanValidationService _planValidationService;
        public UpdatePlanCommandHandler(IPlanQueryRepository planQueryRepository, IPlanCommandRepository planCommandRepository, IPlanValidationService planValidationService)
        {
            _planQueryRepository = planQueryRepository;
            _planCommandRepository = planCommandRepository;
            _planValidationService = planValidationService;
        }

        public async Task<OutputPlanDto> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            var inputPlan = request.InputUpdatePlanDto;
            var entity = await _planQueryRepository.GetByIdAsync(inputPlan.Id) ?? throw new RecordNotFoundException();
            var duplicateResult = await _planValidationService.IsPlanDuplicate(request);
            if (duplicateResult)
            {
                throw new DuplicateException();
            }
            entity.PlanType = inputPlan.PlanType;
            entity.StartDate = inputPlan.StartDate;
            entity.EndDate = inputPlan.EndDate;
            entity.ParentPlanId = inputPlan.ParentPlanId;
            entity.LastUpdate = DateTime.UtcNow;
            entity.Description = inputPlan.Description;
            await _planCommandRepository.UpdateAsync(entity);
            var planDto = entity.Adapt<OutputPlanDto>();
            return planDto;
        }
    }
}
