using TrackApi.Application.DTOs.Plan;

namespace TrackApi.Application.Services.Plans
{
    public interface IPlanValidationService
    {
        Task<bool> IsPlanDuplicate(InputCreationPlanDto plan);
        Task<bool> IsPlanDuplicate(InputUpdatePlanDto plan);
    }
}
