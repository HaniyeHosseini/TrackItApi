using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TrackApi.Application.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; }
        public string ErrorCode { get; }
        public BaseException(string message, HttpStatusCode statusCode, string errorCode) : base(message)
        {
            StatusCode = (int)statusCode;
            ErrorCode = errorCode;
        }
    }
}
