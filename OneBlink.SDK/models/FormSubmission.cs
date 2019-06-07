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

namespace OneBlink.SDK.Modal
{
  public class FormSubmissionUser
  {
    public string userId { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string fullName { get; set; }
    public string picture { get; set; }
    public string providerType { get; set; }
    public string providerUserId { get; set; }
  }

  public class FormSubmission<T>
  {
    public Form definition { get; set; }
    public T submission { get; set; }
    public DateTime submissionTimestamp { get; set; }
    public string keyId { get; set; }
    public int formsAppId { get; set; }
    public FormSubmissionUser user { get; set; }
  }
}