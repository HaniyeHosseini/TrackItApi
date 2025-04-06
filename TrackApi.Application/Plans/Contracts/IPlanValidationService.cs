using TrackApi.Application.DTOs.Plan;

namespace TrackApi.Application.Plans.Contracts
{
    public interface IPlanValidationService
    {
        Task<bool> IsPlanDuplicate(InputCreationPlanDto plan);
        Task<bool> IsPlanDuplicate(InputUpdatePlanDto plan);
    }
}
