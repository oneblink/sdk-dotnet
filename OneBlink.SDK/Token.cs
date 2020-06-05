using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using OneBlink.SDK.Model;
namespace OneBlink.SDK
{
    internal class Token
    {
        internal static string GenerateJSONWebToken(string accessKey, string secretKey, int expiryInSeconds)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(accessKey,
                accessKey,
                null,
                expires: DateTime.Now.AddSeconds(expiryInSeconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static internal byte[] FromBase64Url(string base64Url ) {
            string padded = base64Url.Length % 4 == 0 ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/").Replace("-", "+");
            return Convert.FromBase64String(base64);
        }
        internal static async Task<JsonWebKey> GetJsonWebKey(string iss, string kid) {
            JArray keys = await FetchJsonWebKeys(iss, kid);
            string key = FindMatchingJsonWebKey(kid, keys);
            if (key != null) {
                return new JsonWebKey(key);
            } else {
                throw new Exception("Did not find Json Web Key");
            }
        }

        internal static async Task<JArray> FetchJsonWebKeys(string iss, string kid) {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(iss+"/.well-known/jwks.json/");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string result = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);
                return (JArray)json["keys"];
            } else {
                throw new Exception("Error fetching Json Web Keys");
            }
        }

        internal static string FindMatchingJsonWebKey(string kid, JArray keys) {
            string matchingKey = null;
            foreach(JObject key in keys.Children()) {
                if ((string)key["kid"] == kid) {
                    matchingKey = key.ToString();
                }
            }
            return matchingKey;
        }
        internal static string VerifyJWT(string token, JsonWebKey jwk) {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(
                new RSAParameters()
                {
                    Modulus = FromBase64Url(jwk.N),
                    Exponent = FromBase64Url(jwk.E)
                }
            );
            TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };

            SecurityToken validatedSecurityToken = null;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(token, validationParameters, out validatedSecurityToken);

            JwtSecurityToken validatedJwt = validatedSecurityToken as JwtSecurityToken;
            return validatedJwt.Payload.SerializeToJson();

        }
    }
}