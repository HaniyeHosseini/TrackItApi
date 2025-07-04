using MediatR;
using TrackApi.Application.Contracts.Commands;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, Unit>
    {
        private readonly IGoalCommandRepository _goalCommandRepository;

        public DeleteGoalCommandHandler(IGoalCommandRepository goalCommandRepository)
        {
            _goalCommandRepository = goalCommandRepository;
        }

        public async Task<Unit> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            await _goalCommandRepository.RemoveAsync(request.GoalId);
            return Unit.Value;
        }
    }
}
