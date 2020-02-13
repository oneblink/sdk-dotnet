using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;
using Newtonsoft.Json;

namespace OneBlink.SDK
{
  internal class OneBlinkApiClient : OneBlinkHttpClient
  {
    private Region region;

    public OneBlinkApiClient(string accessKey, string secretKey, Region region, int expiryInSeconds = 300)
      : base(accessKey, secretKey, expiryInSeconds)
    {
      this.region = region ?? new Region(RegionCode.AU);
    }

    public async Task<T> PostRequest<T>(string path)
    {
      return await PostRequest<object, T>(path, null);
    }

    public async Task<Tout> PostRequest<T, Tout>(string path, T t)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, region.oneBlinkAPIOrigin + path);
      if (t != null)
      {
        string jsonPayload = JsonConvert.SerializeObject(t);
        httpRequestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
      }
      return await SendRequest<Tout>(httpRequestMessage);
    }

    public async Task<T> GetRequest<T>(string path)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, region.oneBlinkAPIOrigin + path);
      return await SendRequest<T>(httpRequestMessage);
    }

    public async Task<HttpContent> DeleteRequest(string path)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, region.oneBlinkAPIOrigin + path);
      return await SendRequest(httpRequestMessage);
    }
  }
}