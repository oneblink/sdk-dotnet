using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using dotenv.net;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
  internal class OneBlinkPdfHttpClient
  {
    private string accessKey;
    private string secretKey;
    private int expiryInSeconds;
    private string oneBlinkAPIOrigin = "https://pdf.blinkm.io"; //Default to production

    public OneBlinkPdfHttpClient(string accessKey, string secretKey, int expiryInSeconds = 300)
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
      bool raiseException = false;
      DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
      string configuredOrigin = Environment.GetEnvironmentVariable("ONEBLINK_PDF_API_ORIGIN");
      if (!String.IsNullOrWhiteSpace(configuredOrigin))
      {
        oneBlinkAPIOrigin = configuredOrigin;
      }
    }

    public async Task<Stream> PostRequest(string path) {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, oneBlinkAPIOrigin + path);
      return await SendRequest(httpRequestMessage);
    }

    public async Task<Stream> SendRequest(HttpRequestMessage httpRequestMessage)
    {
      // generate token
      string token = Token.GenerateJSONWebToken(accessKey, secretKey, expiryInSeconds);
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
          string errorResult = await httpResponseMessage.Content.ReadAsStringAsync();
          APIErrorResponse apiErrorResponse = JsonConvert.DeserializeObject<APIErrorResponse>(errorResult);
          throw new OneBlinkAPIException(apiErrorResponse);
        }
        Stream result = await httpResponseMessage.Content.ReadAsStreamAsync();
        return result;
      }
    }
  }
}