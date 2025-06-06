using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Jobs.Commands
{
    public class JobCommandRepository : BaseCommandRepository<Job>, IJobCommandRepository
    {
        public JobCommandRepository(TrackApiContext context) : base(context)
        {
        }
    }
}
