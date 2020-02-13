
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
  internal class OneBlinkPdfClient : OneBlinkHttpClient
  {
    private Region region;
    public OneBlinkPdfClient(string accessKey, string secretKey, Region region, int expiryInSeconds = 300)
      : base(accessKey, secretKey, expiryInSeconds)
    {
      this.region = region ?? new Region(RegionCode.AU);
    }
    public async Task<Stream> PostRequest(string path)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, region.oneBlinkPdfOrigin + path);
      HttpContent httpContent = await SendRequest(httpRequestMessage);
      return await httpContent.ReadAsStreamAsync();
    }
  }
}