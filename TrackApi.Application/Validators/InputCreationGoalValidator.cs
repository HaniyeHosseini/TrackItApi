using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.DTOs.Goal;
using TrackApi.Application.DTOs.Plan;
using TrackItApi.Common;

namespace TrackApi.Application.Validators
{
    public class InputCreationGoalValidator : AbstractValidator<InputCreationGoalDto>
    {
        public InputCreationGoalValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.PlanId).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.TargetDate).NotEmpty().WithMessage(ValidatorMessage.Required);
        }
    }
}
