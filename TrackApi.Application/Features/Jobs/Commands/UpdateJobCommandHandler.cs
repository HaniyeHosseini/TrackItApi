using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, OutputJobDto>
    {
        private readonly IJobQueryRepository _jobQueryRepository;
        private readonly IJobCommandRepository _jobCommandRepository;

        public UpdateJobCommandHandler(IJobQueryRepository jobQueryRepository, IJobCommandRepository jobCommandRepository)
        {
            _jobQueryRepository = jobQueryRepository;
            _jobCommandRepository = jobCommandRepository;
        }

        public async Task<OutputJobDto> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var inputJob = request.InputUpdateJobDto;
            var entity = await _jobQueryRepository.GetByIdAsync(inputJob.Id);
            var priorityLevel = (int)Enum.Parse(typeof(PriorityLevel), inputJob.PriorityLevel);

            if (entity == null) throw new RecordNotFoundException();
            entity.Title = inputJob.Title;
            entity.Description = inputJob.Description;
            entity.StartDate = inputJob.StartDate;
            entity.EndDate = inputJob.EndDate;
            entity.GoalId = inputJob.GoalId;
            entity.ParentJobId = inputJob.ParentJobId;
            entity.LastUpdate = DateTime.UtcNow;
            entity.PriorityLevel = (PriorityLevel)priorityLevel;
            await _jobCommandRepository.UpdateAsync(entity);
            return entity.Adapt<OutputJobDto>();
        }
    }
}
