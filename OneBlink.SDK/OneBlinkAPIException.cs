using System;
using System.Net;

namespace OneBlink.SDK
{
  public class OneBlinkAPIException : Exception
  {
    public HttpStatusCode StatusCode { get; private set; }

    public OneBlinkAPIException(HttpStatusCode statusCode)
    {
      this.StatusCode = statusCode;
    }

    public OneBlinkAPIException(HttpStatusCode statusCode, string message)
      : base(message)
    {
      this.StatusCode = statusCode;
    }

    public OneBlinkAPIException(HttpStatusCode statusCode, string message, Exception inner)
      : base(message, inner)
    {
      this.StatusCode = statusCode;
    }

    internal OneBlinkAPIException(APIErrorResponse apiErrorResponse)
      : base(apiErrorResponse.message)
    {
      this.StatusCode = apiErrorResponse.statusCode;
    }
  }
}