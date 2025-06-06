using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Goals.Commands;
using TrackApi.Application.Features.Goals.Dtos;
using TrackItApi.Common;

namespace TrackApi.Application.Features.Goals.Validators
{
    public class InputCreationGoalValidator : AbstractValidator<CreateGoalCommand>
    {
        public InputCreationGoalValidator()
        {
            RuleFor(x => x.InputCreationGoalDto.Title).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.InputCreationGoalDto.PlanId).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.InputCreationGoalDto.TargetDate).NotEmpty().WithMessage(ValidatorMessage.Required);
        }
    }
}
