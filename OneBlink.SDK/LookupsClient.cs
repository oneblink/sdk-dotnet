using OneBlink.SDK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace OneBlink.SDK
{
    public class LookupsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public LookupsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(accessKey, secretKey, tenant: new Tenant(tenantName));
        }

        public async Task Delete(long id)
        {
            string url = "/form-element-lookups/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }

        public async Task<FormElementLookup> Create(FormElementLookup newFormElementLookup)
        {
            string url = "/form-element-lookups";
            FormElementLookup formElementLookup = await this.oneBlinkApiClient.PostRequest<FormElementLookup, FormElementLookup>(url, newFormElementLookup);
            return formElementLookup;
        }

        public async Task<FormElementLookup> Update(FormElementLookup formElementLookupToUpdate)
        {
            string url = "/form-element-lookups/" + formElementLookupToUpdate.id.ToString();
            FormElementLookup formElementLookup = await this.oneBlinkApiClient.PutRequest<FormElementLookup, FormElementLookup>(url, formElementLookupToUpdate);
            return formElementLookup;
        }

        public async Task<FormElementLookupSearchResult> Search(string organisationId, int? limit = null, int? offset = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(limit), limit);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(offset), offset);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(organisationId), organisationId);

            string url = "/form-element-lookups?" + query.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormElementLookupSearchResult>(url);
        }

        public async Task<FormElementLookup> Get(long id)
        {
            string url = "/form-element-lookups/" + id.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormElementLookup>(url);
        }
    }
}