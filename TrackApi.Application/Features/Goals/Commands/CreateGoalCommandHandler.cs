using Mapster;
using MediatR;
using TrackApi.Application.Contracts.Commands;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Goals.Dtos;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, OutputGoalDto>
    {
        private readonly IGoalCommandRepository _goalCommandRepository;
        private readonly IPlanQueryRepository _planQueryRepository;
        public CreateGoalCommandHandler(IGoalCommandRepository goalCommandRepository, IPlanQueryRepository lanQueryRepository)
        {
            _goalCommandRepository = goalCommandRepository;
            _planQueryRepository = lanQueryRepository;
        }

        public async Task<OutputGoalDto> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            var inputGoal = request.InputCreationGoalDto;
            var plan = await _planQueryRepository.GetByIdAsync(inputGoal.PlanId) ?? throw new RecordNotFoundException();
            if (inputGoal.TargetDate > plan.EndDate) throw new CustomInvalidDataException(".تاریخ هدف باید کوچکتر از تاریخ پایان برنامه زمانی باشد");
            var goalEntity = new Goal(inputGoal.Title, inputGoal.Description, inputGoal.TargetDate, inputGoal.PlanId);
            await _goalCommandRepository.AddAsync(goalEntity);
            var data = goalEntity.Adapt<OutputGoalDto>();
            return data;
        }
    }
}
