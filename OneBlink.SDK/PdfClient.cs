using System.Threading.Tasks;
using System.IO;

namespace OneBlink.SDK
{
  public class PdfClient
  {
    private OneBlinkHttpClient oneBlinkHttpClient;

    public PdfClient(string accessKey, string secretKey, RegionCode regionCode = RegionCode.AU)
        {
            this.oneBlinkHttpClient = new OneBlinkHttpClient(
                accessKey,
                secretKey,
                region: new Region(regionCode)
            );
        }

        public PdfClient(string accessKey, string secretKey, string apiOrigin)
        {
            this.oneBlinkHttpClient = new OneBlinkHttpClient(
                accessKey,
                secretKey,
                region: new Region(pdfOrigin: apiOrigin)
            );
        }


    public async Task<Stream> GetSubmissionPdf(int formId, string submissionId)
    {
      string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
      return await this.oneBlinkHttpClient.PostRequest(url);
    }
  }
}
