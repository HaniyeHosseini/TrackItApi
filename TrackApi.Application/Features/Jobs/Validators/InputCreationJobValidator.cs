using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Jobs.Dtos;
using TrackItApi.Common;

namespace TrackApi.Application.Features.Jobs.Validators
{
    public class InputCreationJobValidator : AbstractValidator<InputCreationJobDto>
    {
        public InputCreationJobValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.PriorityLevel).NotNull().NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.StartDate).NotNull().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.GoalId).NotNull().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage(ValidatorMessage.InvalidDate);
        }
    }
}
