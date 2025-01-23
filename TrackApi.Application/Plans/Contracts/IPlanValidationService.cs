using TrackApi.Application.Plans.Dtos;

namespace TrackApi.Application.Plans.Contracts
{
    public interface IPlanValidationService
    {
        Task<bool> IsPlanDuplicate(CreationPlanDto plan);
        Task<bool> IsPlanDuplicate(UpdatePlanDto plan);
    }
}
