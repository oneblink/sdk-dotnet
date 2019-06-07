using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace OneBlink.SDK
{
  public class Pdf
  {
    private string accessKey;
    private string secretKey;
    public Pdf(string accessKey, string secretKey)
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
    }

    public async Task<string> generate(int formId, string submissionId)
    {
      // generate token
      string token = GenerateJSONWebToken();
      HttpContent httpContent = new HttpContent();
      using (var httpClient = new HttpClient())
      {
        // HttpContent httpContent = new HttpContent();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        // httpClient.DefaultRequestHeaders.ContentType = new MediaTypeHeaderValue("application/json");
        // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        // httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pdf"));
        // httpClient.encoding = "binary";

        string url = "https://pdf.blinkm.io/forms/" + formId + "/submissions/" + submissionId + "/pdf-document";
        try
        {
          HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
          using (HttpContent content = response.Content)
          {
            string data = await content.ReadAsStringAsync();
            if (data != null)
            {
              Console.WriteLine(data);
            }
            return data;
          }
        }
        catch (HttpRequestException e)
        {
          Console.WriteLine("Ex: ", e);
          return e.Message;
        }

      }
    }

    private string GenerateJSONWebToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(accessKey,
        accessKey,
        null,
        expires: DateTime.Now.AddSeconds(300), // TODO Make configurable?
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
