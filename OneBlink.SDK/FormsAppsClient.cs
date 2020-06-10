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

        public async Task<JWTPayload> VerifyJWT(string token)
        {
            if (token.Contains("Bearer ")) {
                token = token.Split(' ')[1];
            }
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            string iss = this.oneBlinkApiClient.tenant.jwtIssuer;
            JsonWebKey jwk = await Token.GetJsonWebKey(
                iss: iss,
                kid: jwt.Header.Kid
            );
            string verifiedToken = Token.VerifyJWT(token, jwk, iss);
            return JsonConvert.DeserializeObject<JWTPayload>(verifiedToken);
        }

    }
}
