using OneBlink.SDK.Model;
using System.Threading.Tasks;

namespace OneBlink.SDK
{
    public class FormsAppEnvironmentsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public FormsAppEnvironmentsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<FormsAppEnvironmentsSearchResult> Search(string organisationId, int? limit, int? offset)
        {
            string queryString = "organisationId" + organisationId;

            if (limit.HasValue)
            {
                queryString += "&";

                queryString += "limit=" + limit.Value;
            }
            if (offset.HasValue)
            {
                queryString += "&";

                queryString += "offset=" + offset.Value;
            }
            string url = "/forms-app-environments?" + queryString;
            return await this.oneBlinkApiClient.GetRequest<FormsAppEnvironmentsSearchResult>(url);
        }
    }
}