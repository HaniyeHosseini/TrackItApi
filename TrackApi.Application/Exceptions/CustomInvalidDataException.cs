using System.Net;

namespace TrackApi.Application.Exceptions
{
    public class CustomInvalidDataException : BaseException
    {
        public CustomInvalidDataException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string errorCode="INVALID_ERROR") : base(message, statusCode, errorCode)
        {
        }
    }
}
