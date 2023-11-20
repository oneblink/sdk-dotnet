using System.Threading.Tasks;
using System.Web;
using OneBlink.SDK.Model;
using Task = System.Threading.Tasks.Task;

namespace OneBlink.SDK
{
    public class FormElementListsClient
    {
        OneBlinkApiClient oneblinkApiClient;

        public FormElementListsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneblinkApiClient = new OneBlinkApiClient(accessKey, secretKey, tenant: new Tenant(tenantName));
        }

        public async Task Delete(long id)
        {
            string url = "/form-element-options/dynamic/" + id.ToString();
            await this.oneblinkApiClient.DeleteRequest(url);
        }

        public async Task<FormElementListSearchResult> Search(string organisationId, int? limit = null, int? offset = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(limit), limit);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(offset), offset);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(organisationId), organisationId);

            string url = "/form-element-options/dynamic?" + query.ToString();
            FormElementListInternalSearchResult results = await this.oneblinkApiClient.GetRequest<FormElementListInternalSearchResult>(url);
            FormElementListSearchResult formElementListSearchResults = new FormElementListSearchResult()
            {
                formElementLists = results.formElementDynamicOptionSets,
                meta = results.meta
            };
            return formElementListSearchResults;
        }

        public async Task<FormElementList> Create(FormElementList newFormElementList)
        {
            string url = "/form-element-options/dynamic";
            FormElementList formElementList = await this.oneblinkApiClient.PostRequest<FormElementList, FormElementList>(url, newFormElementList);
            return formElementList;
        }

        public async Task<FormElementList> Update(FormElementList formElementListToUpdate)
        {
            string url = "/form-element-options/dynamic/" + formElementListToUpdate.id.ToString();
            FormElementList formElementList = await this.oneblinkApiClient.PutRequest<FormElementList, FormElementList>(url, formElementListToUpdate);
            return formElementList;
        }
    }
}