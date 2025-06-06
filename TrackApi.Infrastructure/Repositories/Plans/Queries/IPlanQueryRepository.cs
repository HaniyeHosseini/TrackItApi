using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackApi.Infrastructure.Repositories.Plans.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans.Queries
{
    public interface IPlanQueryRepository : IBaseQueryRepository<Plan>
    {
    }
}
