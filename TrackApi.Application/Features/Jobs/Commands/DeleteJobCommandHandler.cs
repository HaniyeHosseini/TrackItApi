using MediatR;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;

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
