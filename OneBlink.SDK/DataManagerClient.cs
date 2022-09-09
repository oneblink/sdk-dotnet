using OneBlink.SDK.Model;
using System.Threading.Tasks;
using System.Web;

namespace OneBlink.SDK
{
    public class DataManagerClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public DataManagerClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<FormStoreDefinition> GetFormDefinition(long formId)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formId), formId);
            string url = "/form-store/elements?" + query.ToString();

            return await this.oneBlinkApiClient.GetRequest<FormStoreDefinition>(url);
        }

        public async Task<FormStoreSearchResult<T>> Search<T>(FormStoreSearchRequest request)
        {
            string url = "/form-store";
            return await this.oneBlinkApiClient.PostRequest<FormStoreSearchRequest, FormStoreSearchResult<T>>(url, request);
        }

    }
}