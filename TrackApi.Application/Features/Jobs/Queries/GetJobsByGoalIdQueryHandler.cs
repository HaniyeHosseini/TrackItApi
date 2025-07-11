﻿using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Features.Jobs.Dtos;

namespace TrackApi.Application.Features.Jobs.Queries
{
    public class GetJobsByGoalIdQueryHandler : IRequestHandler<GetJobsByGoalIdQuery, List<OutputJobDto>>
    {
        private readonly IJobQueryRepository _jobQueryRepository;

        public GetJobsByGoalIdQueryHandler(IJobQueryRepository jobQueryRepository)
        {
            _jobQueryRepository = jobQueryRepository;
        }

        public async Task<List<OutputJobDto>> Handle(GetJobsByGoalIdQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobQueryRepository.GetJobsByGoalId(request.GoalId);
            return jobs.Adapt<List<OutputJobDto>>();
        }
    }
}
