using TrackItApi.Domain.Models;

namespace TrackApi.Application.Contracts.Commands
{
    public interface IPlanCommandRepository : IBaseCommandRepository<Plan>
    {
        Task RemovePlanWithGoals(long planId);
    }
}
