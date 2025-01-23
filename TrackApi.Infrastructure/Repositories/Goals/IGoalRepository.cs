using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals
{
    public interface IGoalRepository : IBaseRepository<Goal>
    {
    }
    public class GoalRepository : BaseRepository<Goal>, IGoalRepository
    {
        public GoalRepository(TrackApiContext context) : base(context)
        {
        }
    }
}
