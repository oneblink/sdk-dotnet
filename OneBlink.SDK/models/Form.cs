using System;
using System.Collections.Generic;
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
  public class Form
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string organisationId { get; set; }
    public List<object> elements { get; set; }
    public bool isAuthenticated { get; set; }
    public List<object> submissionEvents { get; set; }
    public bool isPublished { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool isMultiPage { get; set; }
    public string postSubmissionAction { get; set; }
    public object redirectUrl { get; set; }
    public bool isInfoPage { get; set; }
    public List<int> formsAppIds { get; set; }
  }
}