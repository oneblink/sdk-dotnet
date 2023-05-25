using System;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace OneBlink.SDK
{
    internal class Token
    {
        internal static string GenerateJSONWebToken(string accessKey, string secretKey, int expiryInSeconds, DeveloperKeyAccess developerKeyAccess = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(accessKey,
                accessKey,
                null,
                expires: DateTime.Now.AddSeconds(expiryInSeconds),
                signingCredentials: credentials);

            if (developerKeyAccess != null)
            {
                token.Payload.Add("oneblink:access", developerKeyAccess);
            }
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static internal byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0 ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/").Replace("-", "+");
            return Convert.FromBase64String(base64);
        }
        internal static async Task<JsonWebKey> GetJsonWebKey(string iss, string kid)
        {
            JArray keys = await FetchJsonWebKeys(iss, kid);
            string key = FindMatchingJsonWebKey(kid, keys);
            if (key != null)
            {
                return new JsonWebKey(key);
            }
            else
            {
                throw new Exception("Did not find Json Web Key");
            }
        }

        internal static async Task<JArray> FetchJsonWebKeys(string iss, string kid)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(iss + "/.well-known/jwks.json/");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string result = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);
                return (JArray) json["keys"];
            }
            else
            {
                throw new Exception("Error fetching Json Web Keys");
            }
        }

        internal static string FindMatchingJsonWebKey(string kid, JArray keys)
        {
            string matchingKey = null;
            foreach (JObject key in keys.Children())
            {
                if ((string) key["kid"] == kid)
                {
                    matchingKey = key.ToString();
                }
            }
            return matchingKey;
        }
        internal static string VerifyJWT(string token, JsonWebKey jwk, string iss)
        {
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
                ValidIssuer = iss,
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateLifetime = true,
                IssuerSigningKey = new RsaSecurityKey(rsa)
            };

            SecurityToken validatedSecurityToken = null;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(token, validationParameters, out validatedSecurityToken);

            JwtSecurityToken validatedJwt = validatedSecurityToken as JwtSecurityToken;
            return validatedJwt.Payload.SerializeToJson();
        }
    }

    internal class AesUserToken
    {
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        internal AesUserToken(string key)
        {

            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            // 256 bits (32 characters) hash
            MD5CryptoServiceProvider Provider = new MD5CryptoServiceProvider(); // DevSkim: ignore DS168931
            byte[] keyHash = Provider.ComputeHash(keyBytes);
            // NEED TO CONVERT TO STRING AND BACK TO BYTES ARRAY TO MATCH JS
            string keyHashString = BitConverter.ToString(keyHash).Replace("-", String.Empty).ToLower();
            byte[] keyHashBytes = Encoding.ASCII.GetBytes(keyHashString);
            aes.Key = keyHashBytes;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
        }

        internal string encrypt(string value)
        {
            byte[] cipherData;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                aes.GenerateIV();
                ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cipher, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(value);
                    }
                }
                cipherData = memoryStream.ToArray();
            }

            byte[] combinedData = new byte[aes.IV.Length + cipherData.Length];
            Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
            Array.Copy(cipherData, 0, combinedData, aes.IV.Length, cipherData.Length);
            return Convert.ToBase64String(combinedData);
        }
        internal string decrypt(string value)
        {
            byte[] combinedData = Convert.FromBase64String(value);
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] cipherText = new byte[combinedData.Length - iv.Length];
            Array.Copy(combinedData, iv, iv.Length);
            Array.Copy(combinedData, iv.Length, cipherText, 0, cipherText.Length);
            aes.IV = iv;
            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                ICryptoTransform decipher = aes.CreateDecryptor(aes.Key, aes.IV);
                using (CryptoStream cryptoStream = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
