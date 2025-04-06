using System.Net;
using TrackItApi.Common;

namespace TrackApi.Application.Exceptions
{
    public class DuplicateException() : BaseException(ExceptionMessages.DuplicateRecordMessage, HttpStatusCode.Conflict, "DUPLICATE_ERROR")
    {
    }
}
