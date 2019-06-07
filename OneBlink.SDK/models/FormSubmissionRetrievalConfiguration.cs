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

namespace OneBlink.SDK.Model
{
  public class FormSubmissionRetrievalConfigurationCredentials
  {
    public string AccessKeyId { get; set; }
    public string SecretAccessKey { get; set; }
    public string SessionToken { get; set; }
  }

  public class FormSubmissionRetrievalConfigurationS3
  {
    public string bucket { get; set; }
    public string key { get; set; }
    public string region { get; set; }
  }

  public class FormSubmissionRetrievalConfiguration
  {
    public FormSubmissionRetrievalConfigurationCredentials credentials { get; set; }
    public FormSubmissionRetrievalConfigurationS3 s3 { get; set; }
  }
}