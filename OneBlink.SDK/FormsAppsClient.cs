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
        public async Task<T> Get<T>(long id) where T : FormsAppBase
        {
            string url = "/forms-apps/" + id.ToString();
            return await this.oneBlinkApiClient.GetRequest<T>(url);
        }

        public async Task<T> GetMyFormsApp<T>(string token) where T : FormsAppBase
        {
            string url = "/my-forms-app";
            return await this.oneBlinkApiClient.GetRequest<T>(url, token);
        }
        public async Task<T> Create<T>(T newFormsApp) where T : FormsAppBase
        {
            string url = "/forms-apps";
            var formsApp = await this.oneBlinkApiClient.PostRequest<T, T>(url, newFormsApp);
            return formsApp;
        }
        public async Task<T> Update<T>(FormsAppBase formsAppToUpdate) where T : FormsAppBase
        {
            string url = "/forms-apps/" + formsAppToUpdate.id.ToString();

            var formsApp = await this.oneBlinkApiClient.PutRequest<FormsAppBase, T>(url, formsAppToUpdate);
            return formsApp;
        }
        public async Task Delete(long id, bool overrideLock = false)
        {
            string url = "/forms-apps/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }
        public async Task<T> UpdateStyles<T>(long id, T styles) where T : FormsAppStylesBase
        {
            string url = "/forms-apps/" + id.ToString() + "/styles";

            var formsAppStyles = await this.oneBlinkApiClient.PutRequest<T, T>(url, styles);
            return formsAppStyles;
        }

        public async Task<FormsAppSendingAddressResponse> SetSendingAddress(long id, NewFormsAppSendingAddress newFormsAppSendingAddress)
        {
            if (String.IsNullOrEmpty(newFormsAppSendingAddress.emailAddress))
            {
                throw new Exception("Email Address must not be empty");
            }
            string url = "/v2/forms-apps/" + id.ToString() + "/sending-address";

            FormsAppSendingAddressResponse sendingAddress = await this.oneBlinkApiClient.PostRequest<NewFormsAppSendingAddress, FormsAppSendingAddressResponse>(url, newFormsAppSendingAddress);
            return sendingAddress;
        }

        public async Task DeleteSendingAddress(long id)
        {
            string url = "/forms-apps/" + id.ToString() + "/sending-address";
            await this.oneBlinkApiClient.DeleteRequest(url);
        }
        public async Task<FormsAppSendingAddressResponse> GetSendingAddress(long formsAppId)
        {
            string url = "/v2/forms-apps/" + formsAppId.ToString() + "/sending-address";
            FormsAppSendingAddressResponse sendingAddress = await this.oneBlinkApiClient.GetRequest<FormsAppSendingAddressResponse>(url);
            return sendingAddress;
        }

        public async Task<FormsAppUser> CreateUser(FormsAppUser newUser)
        {
            string url = "/appUsers";
            FormsAppUser formsAppUser = await this.oneBlinkApiClient.PostRequest<FormsAppUser, FormsAppUser>(url, newUser);
            return formsAppUser;
        }
        public async Task DeleteUser(long id)
        {
            string url = "/appUsers/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }
    }
}
