using Mapster;
using MediatR;
using TrackApi.Application.Exceptions;
using TrackApi.Application.Features.Goals.Dtos;
using TrackApi.Infrastructure.Repositories.Goals.Commands;
using TrackApi.Infrastructure.Repositories.Goals.Queries;
using TrackApi.Infrastructure.Repositories.Plans.Queries;

namespace TrackApi.Application.Features.Goals.Commands
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, OutputGoalDto>
    {
        private readonly IPlanQueryRepository _planQueryRepository;
        private readonly IGoalQueryRepository _goalQueryRepository;
        private readonly IGoalCommandRepository _goalCommandRepository;

        public UpdateGoalCommandHandler(IPlanQueryRepository planQueryRepository, IGoalQueryRepository goalQueryRepository, IGoalCommandRepository goalCommandRepository)
        {
            _planQueryRepository = planQueryRepository;
            _goalQueryRepository = goalQueryRepository;
            _goalCommandRepository = goalCommandRepository;
        }

        public async Task<OutputGoalDto> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var inputGoal = request.InputUpdateGoalDto;
            var plan = await _planQueryRepository.GetByIdAsync(inputGoal.PlanId) ?? throw new RecordNotFoundException();
            if (inputGoal.TargetDate > plan.EndDate) throw new CustomInvalidDataException(".تاریخ هدف باید کوچکتر از تاریخ پایان برنامه زمانی باشد");
            var goalEntity = await _goalQueryRepository.GetByIdAsync(inputGoal.Id);
            goalEntity.Description = inputGoal.Description;
            goalEntity.TargetDate = inputGoal.TargetDate;
            goalEntity.Title = inputGoal.Title;
            goalEntity.PlanId = inputGoal.PlanId;
            goalEntity.LastUpdate = DateTime.Now;
            await _goalCommandRepository.UpdateAsync(goalEntity);
            var data = goalEntity.Adapt<OutputGoalDto>();
            return data;
        }
    }
}
