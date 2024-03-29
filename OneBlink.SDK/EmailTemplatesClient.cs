using OneBlink.SDK.Model;
using System.Threading.Tasks;
using System.Web;
using Task = System.Threading.Tasks.Task;

namespace OneBlink.SDK
{
    public class EmailTemplatesClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public EmailTemplatesClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<EmailTemplatesSearchResult> Search(int? limit = null, int? offset = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(limit), limit);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(offset), offset);

            string url = "/email-templates?" + query.ToString();
            return await this.oneBlinkApiClient.GetRequest<EmailTemplatesSearchResult>(url);
        }

        public async Task<EmailTemplate> Create(EmailTemplate newEmailTemplate)
        {
            string url = "/email-templates";
            EmailTemplate emailTemplate = await this.oneBlinkApiClient.PostRequest<EmailTemplate, EmailTemplate>(url, newEmailTemplate);
            return emailTemplate;
        }

        public async Task<EmailTemplate> Get(long id)
        {
            string url = "/email-templates/" + id.ToString();
            return await this.oneBlinkApiClient.GetRequest<EmailTemplate>(url);
        }

        public async Task<EmailTemplate> Update(EmailTemplate emailTemplateToUpdate)
        {
            string url = "/email-templates/" + emailTemplateToUpdate.id.ToString();
            EmailTemplate emailTemplate = await this.oneBlinkApiClient.PutRequest<EmailTemplate, EmailTemplate>(url, emailTemplateToUpdate);
            return emailTemplate;
        }

        public async Task Delete(long id)
        {
            string url = "/email-templates/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }
    }
}