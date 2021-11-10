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

        public async Task<FormsAppEnvironmentsSearchResult> Search(string organisationId, int? limit = null, int? offset = null)
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
        public async Task<FormsAppEnvironment> Create(FormsAppEnvironment newFormsAppEnvironment)
        {
            string url = "/forms-app-environments";
            FormsAppEnvironment formsAppEnvironment = await this.oneBlinkApiClient.PostRequest<FormsAppEnvironment, FormsAppEnvironment>(url, newFormsAppEnvironment);
            return formsAppEnvironment;
        }

        public async Task<FormsAppEnvironment> Get(long id)
        {
            string url = "/forms-app-environments/" + id.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormsAppEnvironment>(url);
        }

        public async Task<FormsAppEnvironment> Update(FormsAppEnvironment formsAppEnvironmentToUpdate)
        {
            string url = "/forms-app-environments/" + formsAppEnvironmentToUpdate.id.ToString();
            FormsAppEnvironment formsAppEnvironment = await this.oneBlinkApiClient.PutRequest<FormsAppEnvironment, FormsAppEnvironment>(url, formsAppEnvironmentToUpdate);
            return formsAppEnvironment;
        }

        public async Task Delete(long id)
        {
            string url = "/forms-app-environments/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }

    }

}