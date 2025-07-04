using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Features.Jobs.Dtos;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, OutputJobDto>
    {
        private readonly IJobQueryRepository _jobQueryRepository;

        public GetJobByIdQueryHandler(IJobQueryRepository jobQueryRepository)
        {
            _jobQueryRepository = jobQueryRepository;
        }

        public async Task<OutputJobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobQueryRepository.GetByIdAsync(request.JobId);
            return job.Adapt<OutputJobDto>();
        }
    }
}
