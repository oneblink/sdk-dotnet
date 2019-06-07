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
  internal class OneBlinkHttpClient
  {
    private string accessKey;
    private string secretKey;
    private string oneBlinkAPIOrigin = "https://auth-api.blinkm.io"; //Default to production

    public OneBlinkHttpClient(string accessKey, string secretKey)
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
      bool raiseException = false;
      DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
      string configuredOrigin = Environment.GetEnvironmentVariable("ONEBLINK_API_ORIGIN");
      if (!String.IsNullOrWhiteSpace(configuredOrigin))
      {
        oneBlinkAPIOrigin = configuredOrigin;
      }
    }

    public async Task<T> PostRequest<T>(string path)
    {
      return await PostRequest<object, T>(path, null);
    }

    public async Task<Tout> PostRequest<T, Tout>(string path, T t)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, oneBlinkAPIOrigin + path);
      if (t != null)
      {
        string jsonPayload = JsonConvert.SerializeObject(t);
        httpRequestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
      }
      return await SendRequest<Tout>(httpRequestMessage);
    }

    public async Task<T> GetRequest<T>(string path)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, oneBlinkAPIOrigin + path);
      return await SendRequest<T>(httpRequestMessage);
    }

    public async Task<T> SendRequest<T>(HttpRequestMessage httpRequestMessage)
    {
      // generate token
      string token = GenerateJSONWebToken();
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        string result = await httpResponseMessage.Content.ReadAsStringAsync();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
          APIErrorResponse apiErrorResponse = JsonConvert.DeserializeObject<APIErrorResponse>(result);
          throw new OneBlinkAPIException(apiErrorResponse);
        }

        return JsonConvert.DeserializeObject<T>(result);
      }
    }

    private string GenerateJSONWebToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(accessKey,
          accessKey,
          null,
          expires: DateTime.Now.AddSeconds(300), // TODO Make configurable?
          signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}