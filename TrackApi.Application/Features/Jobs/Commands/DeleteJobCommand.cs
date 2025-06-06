using MediatR;

namespace TrackApi.Application.Features.Jobs.Commands
{
    public class DeleteJobCommand : IRequest<Unit>
    {
        public long Id { get; }

        public DeleteJobCommand(long id)
        {
            Id = id;
        }
    }
}
