using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Infrastructure.Repositories.Plans.Commands;
using TrackApi.Infrastructure.Repositories.Plans.Queries;

namespace TrackApi.Application.Features.Plans.Commands
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
