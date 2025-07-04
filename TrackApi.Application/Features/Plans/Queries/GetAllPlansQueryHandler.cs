using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Features.Plans.Dtos;

namespace TrackApi.Application.Features.Plans.Queries
{
    public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, List<OutputPlanDto>>
    {
        private readonly IPlanQueryRepository _planQueryRepository;

        public GetAllPlansQueryHandler(IPlanQueryRepository planQueryRepository)
        {
            _planQueryRepository = planQueryRepository;
        }

        public async Task<List<OutputPlanDto>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _planQueryRepository.GetAllAsync();
            var planViews = plans.Adapt<List<OutputPlanDto>>();
            return planViews;
        }
    }
}
