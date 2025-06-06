using Mapster;
using MediatR;
using TrackApi.Application.Features.Goals.Dtos;
using TrackApi.Infrastructure.Repositories.Goals.Queries;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalsByPlanIdQueryHandler : IRequestHandler<GetGoalsByPlanIdQuery, List<OutputGoalDto>>
    {
        private readonly IGoalQueryRepository _goalQueryRepository;

        public GetGoalsByPlanIdQueryHandler(IGoalQueryRepository goalQueryRepository)
        {
            _goalQueryRepository = goalQueryRepository;
        }

        public async Task<List<OutputGoalDto>> Handle(GetGoalsByPlanIdQuery request, CancellationToken cancellationToken)
        {
            var goals = await _goalQueryRepository.FindAsync(x => x.PlanId == request.PlanId);
            return goals.Adapt<List<OutputGoalDto>>();
        }
    }
}
