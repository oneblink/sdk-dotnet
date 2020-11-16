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
            if (token.Contains("Bearer "))
            {
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
        public async Task<FormsApp> Get(long id)
        {
            string url = "/forms-apps/" + id.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormsApp>(url);
        }
        public async Task<FormsApp> Create(FormsApp newFormsApp)
        {
            string url = "/forms-apps";
            FormsApp formsApp = await this.oneBlinkApiClient.PostRequest<FormsApp, FormsApp>(url, newFormsApp);
            return formsApp;
        }
        public async Task<FormsApp> Update(FormsApp formsAppToUpdate)
        {
            string url = "/forms-apps/" + formsAppToUpdate.id.ToString();

            FormsApp formsApp = await this.oneBlinkApiClient.PutRequest<FormsApp, FormsApp>(url, formsAppToUpdate);
            return formsApp;
        }
        public async Task Delete(long id, bool overrideLock = false)
        {
            string url = "/forms-apps/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }
        public async Task<FormsAppStyles> UpdateStyles(long id, FormsAppStyles styles)
        {
            string url = "/forms-apps/" + id.ToString() + "/styles";

            FormsAppStyles formsAppStyles = await this.oneBlinkApiClient.PutRequest<FormsAppStyles, FormsAppStyles>(url, styles);
            return formsAppStyles;
        }

        public async Task<FormsAppSendingAddress> SetSendingAddress(long id, NewFormsAppSendingAddress newFormsAppSendingAddress)
        {
            if (String.IsNullOrEmpty(newFormsAppSendingAddress.emailAddress)) {
                throw new Exception("Email Address must not be empty");
            }
            string url = "/forms-apps/" + id.ToString() + "/sending-address";

            FormsAppSendingAddress sendingAddress = await this.oneBlinkApiClient.PostRequest<NewFormsAppSendingAddress, FormsAppSendingAddress>(url, newFormsAppSendingAddress);
            return sendingAddress;
        }
    }
}
