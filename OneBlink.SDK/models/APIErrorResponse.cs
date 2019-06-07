using System;
using System.Net;

namespace OneBlink.SDK
{
  internal class APIErrorResponse
  {
    public string message { get; set; }
    public HttpStatusCode statusCode { get; set; }
    public string error { get; set; }
  }
}