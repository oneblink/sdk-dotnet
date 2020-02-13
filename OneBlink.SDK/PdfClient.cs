using System.Threading.Tasks;
using System.IO;
using OneBlink.SDK.Model;
namespace OneBlink.SDK
{
  public class PdfClient
  {
    private OneBlinkPdfClient oneBlinkPdfClient;

    public PdfClient(string accessKey, string secretKey, RegionCode regionCode = RegionCode.AU)
        {
            this.oneBlinkPdfClient = new OneBlinkPdfClient(
                accessKey,
                secretKey,
                region: new Region(regionCode)
            );
        }

        public PdfClient(string accessKey, string secretKey, string apiOrigin)
        {
            this.oneBlinkPdfClient = new OneBlinkPdfClient(
                accessKey,
                secretKey,
                region: new Region(pdfOrigin: apiOrigin)
            );
        }


    public async Task<Stream> GetSubmissionPdf(int formId, string submissionId)
    {
      string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
      return await this.oneBlinkPdfClient.PostRequest(url);
    }
  }
}
