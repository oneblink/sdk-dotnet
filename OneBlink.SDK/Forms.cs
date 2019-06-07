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
    public class Forms
    {
        private string accessKey;
        private string secretKey;
        private string OneBlinkAPIOrigin = "https://auth-api.blinkm.io/"; //Default to production
        public Forms(string accessKey, string secretKey) {
            if (String.IsNullOrWhiteSpace(accessKey)) {
                throw new ArgumentException("accessKey must be provided with a value");
            }
            if (String.IsNullOrWhiteSpace(secretKey)) {
                throw new ArgumentException("secretKey must be provided with a value");
            }
            this.accessKey = accessKey;
            this.secretKey = secretKey;
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            string configuredOrigin = Environment.GetEnvironmentVariable("ONEBLINK_API_ORIGIN");
            if (!String.IsNullOrWhiteSpace(configuredOrigin)) {
                OneBlinkAPIOrigin = configuredOrigin;
            }
        }

        public async Task<string> search(bool? isAuthenticated, bool? isPublished, string name) {
            // generate token
            string token = GenerateJSONWebToken();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string queryString = string.Empty;
                if (isAuthenticated.HasValue) {
                    queryString += "isAuthenticated=" + isAuthenticated.Value.ToString();
                }
                if (isPublished.HasValue) {
                    if (queryString != string.Empty) {
                        queryString += "&";
                    }
                    queryString += "isPublished=" + isPublished.Value.ToString();
                }
                if (String.IsNullOrWhiteSpace(name)) {
                    if (queryString != string.Empty) {
                        queryString += "&";
                    }
                    queryString += "name=" + name;
                }
                string url = OneBlinkAPIOrigin + "forms?" + queryString;
                string jsonResult = await httpClient.GetStringAsync(url);
                return jsonResult;
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
