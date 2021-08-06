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
        public SearchMeta meta
        {
            get; set;
        }
    }

    public class SearchMeta
    {
        public long? limit
        {
            get; set;
        }
        public long? offset
        {
            get; set;
        }
        public long? nextOffset
        {
            get; set;
        }
    }
}
