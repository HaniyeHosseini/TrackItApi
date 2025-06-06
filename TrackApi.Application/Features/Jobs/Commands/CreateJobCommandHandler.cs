using Mapster;
using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackApi.Infrastructure.Repositories.Jobs.Commands;
using TrackItApi.Domain.Enums;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, OutputJobDto>
    {
        private readonly IJobCommandRepository _jobCommandRepository;
        public CreateJobCommandHandler(IJobCommandRepository jobCommandRepository)
        {
            _jobCommandRepository = jobCommandRepository;
        }

        public async Task<OutputJobDto> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var inputJob = request.InputCreationJobDto;
            var priorityLevel = (int)Enum.Parse(typeof(PriorityLevel), inputJob.PriorityLevel);
            if (priorityLevel < 0) throw new CustomInvalidDataException("مقدار اولویت معتبر نمی باشد");
            var entityJob = new Job(inputJob.Title, inputJob.Description, inputJob.StartDate, inputJob.EndDate, (PriorityLevel)priorityLevel, inputJob.GoalId, inputJob.ParentJobId);
            await _jobCommandRepository.AddAsync(entityJob);
            return entityJob.Adapt<OutputJobDto>();
        }
    }
}
