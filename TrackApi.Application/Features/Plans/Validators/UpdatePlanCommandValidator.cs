using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Features.Plans.Dtos;
using TrackItApi.Common;
using TrackItApi.Domain.Enums;

namespace TrackApi.Application.Features.Plans.Validators
{
    public class UpdatePlanCommandValidator : AbstractValidator<InputUpdatePlanDto>
    {
        public UpdatePlanCommandValidator()
        {
            RuleFor(x => x.PlanType).NotEmpty().WithMessage(ValidatorMessage.Required);
            RuleFor(x => x.StartDate).NotEmpty().LessThanOrEqualTo(x => x.EndDate).WithMessage(ValidatorMessage.Required);
            RuleFor(x => x).Must(x => IsValidEndDate(x.PlanType, x.StartDate, x.EndDate)).WithMessage(ValidatorMessage.InvalidDate);
        }
        private bool IsValidEndDate(PlanType planType, DateTime startDate, DateTime endDate)
        {
            int daysDifference = (endDate - startDate).Days;
            switch (planType)
            {
                case PlanType.Daily: return daysDifference == 0;
                case PlanType.Weekly: return daysDifference == 7;
                case PlanType.Monthly: return ValidateDaysInMonth(startDate, endDate);
                case PlanType.Yearly: return ValidateYear(startDate, endDate);
                default:
                    return false;
            }
        }
        private bool ValidateDaysInMonth(DateTime startDate, DateTime endDate)
        {
            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            return (endDate - startDate).Days == daysInMonth;
        }
        private bool ValidateYear(DateTime startDate, DateTime endDate)
        {
            int yearDays = DateTime.IsLeapYear(startDate.Year) ? 366 : 365;
            return (endDate - startDate).Days == yearDays;
        }
    }
}
