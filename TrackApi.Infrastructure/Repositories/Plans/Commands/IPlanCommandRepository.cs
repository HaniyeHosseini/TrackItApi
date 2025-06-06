using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans.Commands
{
    public interface IPlanCommandRepository : IBaseCommandRepository<Plan>
    {
        Task RemovePlanWithGoals(long planId);
    }
}
