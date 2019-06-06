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
    public class Forms
    {
        private string accessKey;
        private string secretKey;
        public Forms(string accessKey, string secretKey) {
            if (String.IsNullOrWhiteSpace(accessKey)) {
                throw new ArgumentException("accessKey must be provided with a value");
            }
            if (String.IsNullOrWhiteSpace(secretKey)) {
                throw new ArgumentException("secretKey must be provided with a value");
            }
            this.accessKey = accessKey;
            this.secretKey = secretKey;
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
                string url = "https://auth-api-test.blinkm.io/forms?" + queryString; //TODO Get host from config
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string jsonResult = await response.Content.ReadAsStringAsync();
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
