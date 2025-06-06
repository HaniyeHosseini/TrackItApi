using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals.Commands
{
    public class GoalCommandRepository : BaseCommandRepository<Goal> , IGoalCommandRepository
    {
        public GoalCommandRepository(TrackApiContext context) : base(context)
        {
        }
    }
}
