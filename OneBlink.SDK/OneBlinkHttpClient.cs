using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace OneBlink.SDK
{
  internal class OneBlinkHttpClient
  {
    internal string accessKey;
    internal string secretKey;
    internal int expiryInSeconds;

    public OneBlinkHttpClient(string accessKey, string secretKey, int expiryInSeconds = 300)
    {

      if (String.IsNullOrWhiteSpace(accessKey))
      {
        throw new ArgumentException("accessKey must be provided with a value");
      }
      if (String.IsNullOrWhiteSpace(secretKey))
      {
        throw new ArgumentException("secretKey must be provided with a value");
      }
      this.accessKey = accessKey;
      this.secretKey = secretKey;
      this.expiryInSeconds = expiryInSeconds;
    }

    internal async Task<T> SendRequest<T>(HttpRequestMessage httpRequestMessage)
    {
      return await SendRequest<T>(httpRequestMessage, null);
    }

    internal async Task<T> SendRequest<T>(HttpRequestMessage httpRequestMessage, string userToken)
    {
      HttpContent httpContent = await SendRequest(httpRequestMessage, userToken);
      string result = await httpContent.ReadAsStringAsync();
      return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task<HttpContent> SendRequest(HttpRequestMessage httpRequestMessage)
    {
      return await SendRequest(httpRequestMessage, null);
    }

    public async Task<HttpContent> SendRequest(HttpRequestMessage httpRequestMessage, string userToken)
    {
      // generate token
      string token = !String.IsNullOrEmpty(userToken) ? userToken : Token.GenerateJSONWebToken(accessKey, secretKey, expiryInSeconds);
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        httpClient.DefaultRequestHeaders.Add("User-Agent", ".Net OneBlink.SDK / " + GetType().Assembly.GetName().Version.ToString());

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
          string result = await httpResponseMessage.Content.ReadAsStringAsync();
          if (httpResponseMessage.Content.Headers.ContentType.MediaType == "application/json")
          {
            APIErrorResponse apiErrorResponse = JsonConvert.DeserializeObject<APIErrorResponse>(result);
            throw new OneBlinkAPIException(apiErrorResponse);
          }
          throw new OneBlinkAPIException(httpResponseMessage.StatusCode, result);
        }
        return httpResponseMessage.Content;
      }
    }

    public async Task<Stream> StreamRequest(HttpRequestMessage httpRequestMessage, string userToken = null)
    {
        HttpContent content = await SendRequest(httpRequestMessage, userToken);
        return await content.ReadAsStreamAsync();
    }
  }
}