using System.Threading.Tasks;
using System.IO;
using OneBlink.SDK.Model;
using System;
using System.Collections.Generic;
using System.Web;
namespace OneBlink.SDK
{
    public class PdfClient
    {
        private OneBlinkPdfClient oneBlinkPdfClient;

        public PdfClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkPdfClient = new OneBlinkPdfClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }
        public async Task<Stream> GetSubmissionPdf(long formId, string submissionId, bool? isDraft = null, bool? includeSubmissionIdInPdf = null, List<Guid> excludedElementIds = null, bool? usePagesAsBreaks = null, bool? includePaymentInPdf = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(isDraft), isDraft);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(includeSubmissionIdInPdf), includeSubmissionIdInPdf);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(includePaymentInPdf), includePaymentInPdf);

            GetSubmissionPdfRequest body = new GetSubmissionPdfRequest() { excludedElementIds = excludedElementIds, usePagesAsBreaks = usePagesAsBreaks };

            string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document?" + query.ToString();
            return await this.oneBlinkPdfClient.PostRequest(url, body);
        }

        public async Task<Stream> GeneratePdf(GeneratePdfOptionsRequest options)
        {
            string url = "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, options);
        }
    }
}
