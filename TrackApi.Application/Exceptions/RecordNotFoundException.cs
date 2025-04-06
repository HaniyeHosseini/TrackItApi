using System.Net;
using TrackItApi.Common;

namespace TrackApi.Application.Exceptions
{
    public class RecordNotFoundException() : BaseException(ExceptionMessages.RecordNotFoundMessage, HttpStatusCode.Conflict, "NOTFOUND_ERROR")
    {
    }
}
