using MediatR;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;

namespace TrackApi.Application.Features.Plans.Commands.Delete
{
    public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, Unit>
    {
        private readonly IPlanQueryRepository _planQueryRepository;
        private readonly IPlanCommandRepository _planCommandRepository;
        public DeletePlanCommandHandler(IPlanQueryRepository planQueryRepository, IPlanCommandRepository planCommandRepository)
        {
            _planQueryRepository = planQueryRepository;
            _planCommandRepository = planCommandRepository;
        }

        public async Task<Unit> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _planQueryRepository.GetByIdAsync(request.Id);
            if (entity == null) throw new RecordNotFoundException();
            await _planCommandRepository.RemovePlanWithGoals(request.Id);
            return Unit.Value;
        }
    }
}
