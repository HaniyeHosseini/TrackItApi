using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Jobs
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(TrackApiContext context) : base(context)
        {
        }
    }

}
