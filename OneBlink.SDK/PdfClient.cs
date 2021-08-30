using System.Threading.Tasks;
using System.IO;
using OneBlink.SDK.Model;
using System;
using System.Collections.Generic;
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
        public async Task<Stream> GetSubmissionPdf(int formId, string submissionId, bool? isDraft = null, bool? includeSubmissionIdInPdf = null, List<Guid> excludedElementIds = null)
        {
            IDictionary<string, string> searchParams = new Dictionary<string, string>();
            if (isDraft.HasValue)
            {
                searchParams.Add("isDraft", isDraft.Value.ToString());
            }
            if (includeSubmissionIdInPdf.HasValue)
            {
                searchParams.Add("includeSubmissionIdInPdf", includeSubmissionIdInPdf.Value.ToString());
            }
            GetSubmissionPdfRequest body = new GetSubmissionPdfRequest() { excludedElementIds = excludedElementIds };

            string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, searchParams, body);
        }

        public async Task<Stream> GeneratePdf(GeneratePdfOptionsRequest options)
        {
            string url = "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, options);
        }
    }
}
