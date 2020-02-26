
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using OneBlink.SDK.Model;
namespace OneBlink.SDK
{
  internal class OneBlinkPdfClient : OneBlinkHttpClient
  {
    private Tenant tenant;
    public OneBlinkPdfClient(string accessKey, string secretKey, Tenant tenant, int expiryInSeconds = 300)
      : base(accessKey, secretKey, expiryInSeconds)
    {
      this.tenant = tenant ?? new Tenant(TenantName.ONEBLINK);
    }
    public async Task<Stream> PostRequest(string path)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, tenant.oneBlinkPdfOrigin + path);
      HttpContent httpContent = await SendRequest(httpRequestMessage);
      return await httpContent.ReadAsStreamAsync();
    }
  }
}