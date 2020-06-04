using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
    public class FormsAppsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public FormsAppsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public FormsAppsClient(string accessKey, string secretKey, string apiOrigin)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(apiOrigin: apiOrigin)
            );
        }

        public async Task<JWTPayload> VerifyJWT(string token)
        {
            try {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                JsonWebKey jwk = await Token.GetJsonWebKey(
                    iss: this.oneBlinkApiClient.tenant.jwtIssuer,
                    kid: jwt.Header.Kid
                );
                string verifiedToken = Token.VerifyJWT(token, jwk);
                return JsonConvert.DeserializeObject<JWTPayload>(verifiedToken);
            } catch(Exception err) {
                throw new Exception("The supplied JWT was invalid.");
            }
        }

    }
}
