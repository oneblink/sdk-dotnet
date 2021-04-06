using OneBlink.SDK.Model;
using System.Threading.Tasks;

namespace OneBlink.SDK
{
    public class KeysClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public KeysClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<DeveloperKey> GetDeveloperKey(string id)
        {
            string getUrl = "/keys/" + id;
            DeveloperKey result = await this.oneBlinkApiClient.GetRequest<DeveloperKey>(getUrl);
            return result;
        }
    }
}