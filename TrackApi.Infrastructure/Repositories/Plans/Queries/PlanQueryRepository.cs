using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans.Queries
{
    public class PlanQueryRepository : BaseQueryRepository<Plan>, IPlanQueryRepository
    {
        public PlanQueryRepository(TrackApiContext context) : base(context)
        {
        }
    }
}
