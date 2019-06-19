using System.Threading.Tasks;
using System.IO;

namespace OneBlink.SDK
{
  public class PdfClient
  {
    private OneBlinkHttpClient oneBlinkHttpClient;

    public PdfClient(string accessKey, string secretKey)
    {
      this.oneBlinkHttpClient = new OneBlinkHttpClient(accessKey, secretKey);
    }

    public async Task<Stream> GetSubmissionPdf(int formId, string submissionId)
    {
      string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
      return await this.oneBlinkHttpClient.PostRequest(url);
    }
  }
}
