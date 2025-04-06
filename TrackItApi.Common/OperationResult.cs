using System.Net;

namespace TrackItApi.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();
        public HttpStatusCode StatusCode { get; set; }
        public static OperationResult<T> Success(T data, HttpStatusCode statusCode, string message = "عملیات موفقیت‌آمیز بود.")
        {
            return new OperationResult<T> { IsSuccess = true, Data = data, Message = message, StatusCode = statusCode };
        }

        public static OperationResult<T> Failure(List<string> errors, HttpStatusCode statusCode, string message = "عملیات ناموفق بود.")
        {
            return new OperationResult<T> { IsSuccess = false, Errors = errors, Message = message, StatusCode = statusCode };
        }

        public static OperationResult<T> Failure(string error, HttpStatusCode statusCode, string message = "عملیات ناموفق بود.")
        {
            return new OperationResult<T> { IsSuccess = false, Errors = new List<string> { error }, Message = message, StatusCode = statusCode };
        }
    }
}
