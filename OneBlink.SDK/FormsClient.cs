using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using dotenv.net;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OneBlink.SDK.Modal;

namespace OneBlink.SDK
{
  public class FormsClient
  {
    private string accessKey;
    private string secretKey;
    private string OneBlinkAPIOrigin = "https://auth-api.blinkm.io/"; //Default to production
    public FormsClient(string accessKey, string secretKey)
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
      string configuredOrigin = Environment.GetEnvironmentVariable("ONEBLINK_API_ORIGIN");
      if (!String.IsNullOrWhiteSpace(configuredOrigin))
      {
        OneBlinkAPIOrigin = configuredOrigin;
      }
    }

    public async Task<FormSubmission<T>> GetFormSubmission<T>(int formId, string submissionId)
    {
      if (String.IsNullOrWhiteSpace(submissionId))
      {
        throw new ArgumentException("submissionId must be provided with a value");
      }

      // generate token
      string token = GenerateJSONWebToken();
      using (HttpClient httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        string url = "https://auth-api-test.blinkm.io/forms/" + formId + "/retrieval-credentials/" + submissionId;
        string result = await httpClient.GetStringAsync(url);

        FormSubmissionRetrievalConfiguration formRetrievalData = JsonConvert.DeserializeObject<FormSubmissionRetrievalConfiguration>(result);
        if (formRetrievalData == null || formRetrievalData.s3 == null || formRetrievalData.credentials == null)
        {
          throw new Exception("Could not create credentials to retrieve form submission data");
        }

        RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(formRetrievalData.s3.region);

        AmazonS3Client amazonS3Client = new AmazonS3Client(regionEndpoint);

        string responseBody = "";
        using (GetObjectResponse response = await amazonS3Client.GetObjectAsync(formRetrievalData.s3.bucket, formRetrievalData.s3.key, null))
        using (Stream responseStream = response.ResponseStream)
        using (StreamReader reader = new StreamReader(responseStream))
        {
          responseBody = reader.ReadToEnd();
        }

        return JsonConvert.DeserializeObject<FormSubmission<T>>(responseBody);
      }
    }

    public async Task<FormsSearchResult> Search(bool? isAuthenticated, bool? isPublished, string name)
    {
      // generate token
      string token = GenerateJSONWebToken();
      using (var httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        string queryString = string.Empty;
        if (isAuthenticated.HasValue)
        {
          queryString += "isAuthenticated=" + isAuthenticated.Value.ToString();
        }
        if (isPublished.HasValue)
        {
          if (queryString != string.Empty)
          {
            queryString += "&";
          }
          queryString += "isPublished=" + isPublished.Value.ToString();
        }
        if (String.IsNullOrWhiteSpace(name))
        {
          if (queryString != string.Empty)
          {
            queryString += "&";
          }
          queryString += "name=" + name;
        }
        string url = OneBlinkAPIOrigin + "forms?" + queryString;
        string jsonResult = await httpClient.GetStringAsync(url);
        return JsonConvert.DeserializeObject<FormsSearchResult>(jsonResult);
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