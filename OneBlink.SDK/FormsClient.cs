using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using dotenv.net;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
  public class FormsClient
  {
    OneBlinkHttpClient oneBlinkHttpClient;

    public FormsClient(string accessKey, string secretKey)
    {
      this.oneBlinkHttpClient = new OneBlinkHttpClient(accessKey, secretKey);
    }

    public async Task<FormSubmission<T>> GetDraftSubmission<T>(int formId, string draftDataId)
    {
      if (String.IsNullOrWhiteSpace(draftDataId))
      {
        throw new ArgumentException("draftDataId must be provided with a value");
      }

      string url = "/forms/" + formId + "/download-draft-data-credentials/" + draftDataId;
      FormSubmissionRetrievalConfiguration formRetrievalData = await this.oneBlinkHttpClient.PostRequest<FormSubmissionRetrievalConfiguration>(url);
      return await GetFormSubmission<T>(formRetrievalData);
    }

    public async Task<FormSubmission<T>> GetFormSubmission<T>(int formId, string submissionId)
    {
      if (String.IsNullOrWhiteSpace(submissionId))
      {
        throw new ArgumentException("submissionId must be provided with a value");
      }

      string url = "/forms/" + formId + "/retrieval-credentials/" + submissionId;
      FormSubmissionRetrievalConfiguration formRetrievalData = await this.oneBlinkHttpClient.PostRequest<FormSubmissionRetrievalConfiguration>(url);
      return await GetFormSubmission<T>(formRetrievalData);
    }

    public async Task<FormsSearchResult> Search(bool? isAuthenticated, bool? isPublished, string name)
    {
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
      string url = "/forms?" + queryString;
      return await this.oneBlinkHttpClient.GetRequest<FormsSearchResult>(url);
    }

    private async Task<FormSubmission<T>> GetFormSubmission<T>(FormSubmissionRetrievalConfiguration formRetrievalData)
    {
      if (formRetrievalData == null || formRetrievalData.s3 == null || formRetrievalData.credentials == null)
      {
        throw new Exception("Could not create credentials to retrieve form submission data");
      }

      RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(formRetrievalData.s3.region);
      SessionAWSCredentials sessionAWSCredentials = new SessionAWSCredentials(
          formRetrievalData.credentials.AccessKeyId,
          formRetrievalData.credentials.SecretAccessKey,
          formRetrievalData.credentials.SessionToken
      );
      AmazonS3Client amazonS3Client = new AmazonS3Client(sessionAWSCredentials, regionEndpoint);

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
}