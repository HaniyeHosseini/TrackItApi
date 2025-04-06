using TrackApi.Application.DTOs.Plan;
using TrackItApi.Common;

namespace TrackApi.Application.Plans.Contracts
{
    public interface IPlanService
    {
        Task<OutputPlanDto> Insert(InputCreationPlanDto plan);
        Task<OutputPlanDto> Update(InputUpdatePlanDto plan);
        Task<bool> Remove(long planId);
        Task<OutputPlanDto?> GetPlanByPlanId(long planId);
        Task<IList<OutputPlanDto>> GetAllPlans();
    }
}
