using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrackApi.Application.Features.Plans.Commands.Delete
{
    public class DeletePlanCommand : IRequest<Unit>
    {
        public long Id { get; }

        public DeletePlanCommand(long id)
        {
            Id = id;
        }
    }
}
