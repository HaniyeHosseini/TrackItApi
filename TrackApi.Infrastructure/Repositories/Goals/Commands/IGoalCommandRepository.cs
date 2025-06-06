using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals.Commands
{
    public interface IGoalCommandRepository : IBaseCommandRepository<Goal>
    {
    }
}
