using FluentValidation;
using TrackApi.Application.Features.Goals.Dtos;
using TrackItApi.Common;

namespace TrackApi.Application.Features.Goals.Validators
{
    public class InputUpdateGoalValidator : AbstractValidator<InputUpdateGoalDto>
    {
        public InputUpdateGoalValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.PlanId).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.TargetDate).NotEmpty().WithMessage(ValidatorMessage.Required);
        }
    }
}
