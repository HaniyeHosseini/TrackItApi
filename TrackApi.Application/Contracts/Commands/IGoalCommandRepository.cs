using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackItApi.Domain.Models;

namespace TrackApi.Application.Contracts.Commands
{
    public interface IGoalCommandRepository : IBaseCommandRepository<Goal>
    {
    }
}
