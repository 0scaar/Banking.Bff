using System.Net;

namespace Banking.Bff.Exceptions
{
    public sealed class ApiServiceException : Exception
    {
        public ApiServiceException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
