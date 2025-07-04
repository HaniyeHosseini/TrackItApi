using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Features.Goals.Dtos;

namespace TrackApi.Application.Features.Goals.Queries
{
    public class GetGoalsByDateFilterQueryHandler : IRequestHandler<GetGoalsByDateFilterQuery, List<OutputGoalDto>>
    {
        private readonly IGoalQueryRepository _goalQueryRepository;

        public GetGoalsByDateFilterQueryHandler(IGoalQueryRepository goalQueryRepository)
        {
            _goalQueryRepository = goalQueryRepository;
        }

        public async Task<List<OutputGoalDto>> Handle(GetGoalsByDateFilterQuery request, CancellationToken cancellationToken)
        {
            var goals = await _goalQueryRepository.GetGoalsByDateFilter(request.StartDate, request.EndDate);
            return goals.Adapt<List<OutputGoalDto>>();
        }
    }
}
