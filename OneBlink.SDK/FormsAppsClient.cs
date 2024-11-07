using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
using Task = System.Threading.Tasks.Task;

namespace OneBlink.SDK
{
    public class FormsAppsClient
    {
        private readonly OneBlinkApiClient oneBlinkApiClient;

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
            RawJWTPayload rawJWTPayload = JsonConvert.DeserializeObject<RawJWTPayload>(verifiedToken);
            if (string.IsNullOrEmpty(rawJWTPayload.sub))
            {
                throw new ArgumentException("Invalid token");
            }
            JWTPayload jWTPayload = new JWTPayload
            {
                isSAMLUser = false,
                providerType = "Cognito",
                providerUserId = rawJWTPayload.sub,
                userId = rawJWTPayload.sub,
                email = rawJWTPayload.email,
                emailVerified = rawJWTPayload.email_verified,
                firstName = rawJWTPayload.given_name,
                lastName = rawJWTPayload.family_name,
                fullName = rawJWTPayload.name,
                picture = rawJWTPayload.picture,
                role = rawJWTPayload.customRole,
                username = !string.IsNullOrEmpty(rawJWTPayload.email) ? rawJWTPayload.email : rawJWTPayload.sub
            };
            if (!string.IsNullOrEmpty(rawJWTPayload.customSupervisorEmail) && !string.IsNullOrEmpty(rawJWTPayload.customSupervisorName) && !string.IsNullOrEmpty(rawJWTPayload.customSupervisorUserId))
            {
                jWTPayload.supervisor = new FormSubmissionSupervisor
                {
                    fullName = rawJWTPayload.customSupervisorName,
                    email = rawJWTPayload.customSupervisorEmail,
                    providerUserId = rawJWTPayload.customSupervisorUserId
                };
            }
            jWTPayload.phoneNumber = rawJWTPayload.customPhoneNumber;
            jWTPayload.phoneNumberVerified = rawJWTPayload.customPhoneNumberVerified;
            jWTPayload.groups = !string.IsNullOrEmpty(rawJWTPayload.customGroups) ? new System.Collections.Generic.List<string>(rawJWTPayload.customGroups.Split(',')) : null;
            if (rawJWTPayload.identities != null && rawJWTPayload.identities.Count > 0)
            {
                jWTPayload.providerType = rawJWTPayload.identities[0].providerType;
                jWTPayload.providerUserId = rawJWTPayload.identities[0].userId;
                jWTPayload.isSAMLUser = rawJWTPayload.identities[0].providerType == "SAML";
                if (jWTPayload.isSAMLUser.HasValue && jWTPayload.isSAMLUser.Value == true)
                {
                    jWTPayload.username = !string.IsNullOrEmpty(rawJWTPayload.preferred_username) ? rawJWTPayload.preferred_username : rawJWTPayload.identities[0].userId;
                }
            }

            return jWTPayload;
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
            T formsApp = await this.oneBlinkApiClient.PostRequest<T, T>(url, newFormsApp);
            return formsApp;
        }
        public async Task<T> Update<T>(FormsAppBase formsAppToUpdate) where T : FormsAppBase
        {
            string url = "/forms-apps/" + formsAppToUpdate.id.ToString();

            T formsApp = await this.oneBlinkApiClient.PutRequest<FormsAppBase, T>(url, formsAppToUpdate);
            return formsApp;
        }
        public async Task Delete(long id, bool overrideLock = false)
        {
            string url = "/forms-apps/" + id.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }

        public async Task<FormsAppSendingAddressResponse> SetSendingAddress(long id, NewFormsAppSendingAddress newFormsAppSendingAddress)
        {
            if (string.IsNullOrEmpty(newFormsAppSendingAddress.emailAddress))
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
