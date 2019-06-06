using System;
using System.IdentityModel.Tokens.Jwt; 
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace oneblink_sdk_dotnet
{
    public class Forms
    {
        private string accessKey;
        private string secretKey;
        public Forms(string accessKey, string secretKey) {
            this.accessKey = accessKey; // TODO Add validation for empty keys
            this.secretKey = secretKey;
        }

        public string search(bool? isAuthenticated, bool? isPublished, string name) {
            // generate token
            string token = GenerateJSONWebToken();
            // construct request parameters

            // call api
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
                string url = "https://auth-api-test.blinkm.io/forms" + queryString; //TODO Get host from config
                var response = httpClient.GetAsync(url).Result;
                string jsonResult = response.Content.ReadAsStringAsync().Result;
                return jsonResult; // TODO return a poco
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
