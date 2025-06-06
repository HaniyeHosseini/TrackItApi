using Mapster;
using MediatR;
using TrackApi.Application.Features.Goals.Dtos;
using TrackApi.Infrastructure.Repositories.Goals.Queries;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, OutputGoalDto>
    {
        private readonly IGoalQueryRepository _goalQueryRepository;

        public GetGoalByIdQueryHandler(IGoalQueryRepository goalQueryRepository)
        {
            _goalQueryRepository = goalQueryRepository;
        }

        public async Task<OutputGoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            var goalEntity = await _goalQueryRepository.GetByIdAsync(request.GoalId);
            var goal = goalEntity.Adapt<OutputGoalDto>();
            return goal;
        }
    }
}
