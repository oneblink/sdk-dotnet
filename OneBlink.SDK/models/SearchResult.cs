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
  public abstract class SearchResult
  {
    public SearchMeta meta { get; set; }
  }

  public class SearchMeta
  {
    public int? limit { get; set; }
    public int? offset { get; set; }
    public int? nextOffset { get; set; }
  }
}
