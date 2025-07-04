using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Plans.Dtos;

namespace TrackApi.Application.Features.Plans.Queries
{
    public class GetPlanByPlanIdQueryHandler : IRequestHandler<GetPlanByIdQuery, OutputPlanDto>
    {
        private readonly IPlanQueryRepository _planQueryRepository;

        public GetPlanByPlanIdQueryHandler(IPlanQueryRepository planQueryRepository)
        {
            _planQueryRepository = planQueryRepository;
        }

        public async Task<OutputPlanDto> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var plan = await _planQueryRepository.GetByIdAsync(request.PlanId) ?? throw new RecordNotFoundException();
            // var goals = await _goalService.GetGoalsByPlanId(planId);
            var planView = plan.Adapt<OutputPlanDto>();
            //  planView.Goals = goals;
            return planView;
        }
    }
}
