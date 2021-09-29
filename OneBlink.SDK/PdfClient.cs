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
        public async Task<Stream> GetSubmissionPdf(int formId, string submissionId, bool? isDraft = null, bool? includeSubmissionIdInPdf = null, List<Guid> excludedElementIds = null, bool? usePagesAsBreaks = null)
        {
            string queryString = string.Empty;
            if (isDraft.HasValue)
            {
                queryString += "isDraft=" + isDraft.Value.ToString();
            }
            if (includeSubmissionIdInPdf.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "includeSubmissionIdInPdf=" + includeSubmissionIdInPdf.Value.ToString();
            }
            if (usePagesAsBreaks.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "usePagesAsBreaks=" + usePagesAsBreaks.Value.ToString();
            }
            GetSubmissionPdfRequest body = new GetSubmissionPdfRequest() { excludedElementIds = excludedElementIds };


            string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document?" + queryString;
            return await this.oneBlinkPdfClient.PostRequest(url, body);
        }

        public async Task<Stream> GeneratePdf(GeneratePdfOptionsRequest options)
        {
            string url = "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, options);
        }
    }
}
