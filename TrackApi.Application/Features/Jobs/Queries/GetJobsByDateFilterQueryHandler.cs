using Mapster;
using MediatR;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackApi.Infrastructure.Repositories.Jobs.Queries;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobsByDateFilterQueryHandler : IRequestHandler<GetJobsByDateFilterQuery, List<OutputJobDto>>
    {
        private readonly IJobQueryRepository _jobQueryRepository;

        public GetJobsByDateFilterQueryHandler(IJobQueryRepository jobQueryRepository)
        {
            _jobQueryRepository = jobQueryRepository;
        }

        public async Task<List<OutputJobDto>> Handle(GetJobsByDateFilterQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobQueryRepository.GetJobsByDateFilter(request.StartDate, request.EndDate);
            return jobs.Adapt<List<OutputJobDto>>();
        }
    }
}
