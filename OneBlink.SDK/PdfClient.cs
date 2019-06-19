using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using dotenv.net;
using System.IO;

namespace OneBlink.SDK
{
  public class PdfClient
  {
    private string accessKey;
    private string secretKey;
    OneBlinkPdfHttpClient oneBlinkPdfHttpClient;
    public PdfClient(string accessKey, string secretKey)
    {
        if (String.IsNullOrWhiteSpace(accessKey))
        {
            throw new ArgumentException("accessKey must be provided with a value");
        }
        if (String.IsNullOrWhiteSpace(secretKey))
        {
            throw new ArgumentException("secretKey must be provided with a value");
        }
        this.accessKey = accessKey;
        this.secretKey = secretKey;
        bool raiseException = false;
        DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");

        this.oneBlinkPdfHttpClient = new OneBlinkPdfHttpClient(accessKey, secretKey);
    }

    public async Task<Stream> GetSubmissionPdf(int formId, string submissionId)
    {
      string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/pdf-document";
      return await this.oneBlinkPdfHttpClient.PostRequest(url);
    }
  }
}
