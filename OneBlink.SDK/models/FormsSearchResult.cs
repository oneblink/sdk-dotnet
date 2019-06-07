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
  public class FormsSearchResult : SearchResult<Form>
  {
    public List<Form> forms { get; set; }
  }
}
