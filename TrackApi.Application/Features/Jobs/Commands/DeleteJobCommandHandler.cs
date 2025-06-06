using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Infrastructure.Repositories.Jobs.Commands;
using TrackApi.Infrastructure.Repositories.Jobs.Queries;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, Unit>
    {
        private readonly IJobCommandRepository _jobCommandRepository;
        private readonly IJobQueryRepository _jobQueryRepository;
        public DeleteJobCommandHandler(IJobCommandRepository jobCommandRepository, IJobQueryRepository jobQueryRepository)
        {
            _jobCommandRepository = jobCommandRepository;
            _jobQueryRepository = jobQueryRepository;
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var entity = await _jobQueryRepository.GetByIdAsync(request.Id);
            if (entity == null) throw new RecordNotFoundException();
            await _jobCommandRepository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
