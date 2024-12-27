using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans
{
    internal class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        public PlanRepository(TrackApiContext context) : base(context) 
        {
        }
    }
}
