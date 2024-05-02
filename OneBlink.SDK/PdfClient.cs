#pragma warning disable IDE1006 // T is already used throughout the codebase
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
        public async Task<Stream> GetSubmissionPdf(long formId,
        string submissionId,
        bool? isDraft = null,
        bool? includeSubmissionIdInPdf = null,
        List<Guid> excludedElementIds = null,
        bool? usePagesAsBreaks = null,
        bool? includePaymentInPdf = null,
        bool? includeCalendarBookingInPdf = null,
        List<string> excludedCSSClasses = null,
        bool? includeExternalIdInPdf = null,
        string pdfSize = "A4")
        {
            GetSubmissionPdfRequest body = new GetSubmissionPdfRequest()
            {
                excludedElementIds = excludedElementIds,
                usePagesAsBreaks = usePagesAsBreaks,
                isDraft = isDraft,
                includeSubmissionIdInPdf = includeSubmissionIdInPdf,
                includePaymentInPdf = includePaymentInPdf,
                includeCalendarBookingInPdf = includeCalendarBookingInPdf,
                excludedCSSClasses = excludedCSSClasses,
                includeExternalIdInPdf = includeExternalIdInPdf,
                pdfSize = pdfSize
            };

            string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, body);
        }

        public async Task<Stream> GeneratePdf(GeneratePdfOptionsRequest options)
        {
            string url = "/pdf-document";
            return await this.oneBlinkPdfClient.PostRequest(url, options);
        }

        public async Task<Stream> GeneratePdfFromSubmissionData<T>(GeneratePDFFromSubmissionDataRequest<T> options)
        {
            string url = "/generate-pdf";
            return await this.oneBlinkPdfClient.PostRequest(url, options);
        }
    }
}
