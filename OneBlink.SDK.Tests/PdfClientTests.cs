using System;
using Xunit;
using OneBlink.SDK;
using System.Net.Http;
using dotenv.net;
using System.IO;
using OneBlink.SDK.Model;
namespace unit_tests
{
  public class PdfClientTests
  {
    private string ACCESS_KEY;
    private string SECRET_KEY;
    private string pdfOrigin;
    private int formId = 475;
    private string submissionId = "5ab3d950-253a-4d22-8ae6-c9eae82f58ba";
    public PdfClientTests()
    {
      bool raiseException = false;
      DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
      ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
      SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
      pdfOrigin = Environment.GetEnvironmentVariable("ONEBLINK_PDF_API_ORIGIN");

      string formId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_FORM_ID");
      if (!String.IsNullOrWhiteSpace(formId))
      {
        this.formId = Int16.Parse(formId);
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
