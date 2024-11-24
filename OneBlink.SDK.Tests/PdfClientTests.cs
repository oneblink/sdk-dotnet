using System;
using Xunit;
using OneBlink.SDK;
using System.Net.Http;
using dotenv.net;
using System.IO;
using OneBlink.SDK.Model;
namespace unit_tests
{
    [Collection("IntegrationTests-RunSequentially")]
    public class PdfClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private string pdfOrigin;
        private long formId = 475;
        private string submissionId = "9e947f75-b952-4c45-ab37-f4429ecef1ff";
        public PdfClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
            pdfOrigin = Environment.GetEnvironmentVariable("ONEBLINK_PDF_API_ORIGIN");

            string formId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(formId))
            {
                this.formId = long.Parse(formId);
            }
            string submissionId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_SUBMISSION_ID");
            if (!String.IsNullOrWhiteSpace(submissionId))
            {
                this.submissionId = submissionId;
            }
        }

        [Fact]
        public void can_be_constructed()
        {
            PdfClient pdf = new PdfClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(pdf);
        }

        [Fact]
        public async void can_get_submission_pdf()
        {
            PdfClient pdf = new PdfClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);

            Stream response = await pdf.GetSubmissionPdf(formId, submissionId);
            Assert.NotNull(response);
        }

        [Fact]
        public async void can_generate_pdf()
        {
            PdfClient pdf = new PdfClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            GeneratePdfOptionsRequest pdfOptionsRequest = new GeneratePdfOptionsRequest();
            Html body = new Html();
            body.html = "<body>PDF Test</body>";
            pdfOptionsRequest.body = body;

            Stream response = await pdf.GeneratePdf(pdfOptionsRequest);
            Assert.NotNull(response);
        }
    }
}
