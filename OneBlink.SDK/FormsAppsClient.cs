using System;
using System.Threading.Tasks;
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
            await this.GetMyFormsApp<FormsAppBase>(token);

            if (token.Contains("Bearer "))
            {
                token = token.Split(' ')[1];
            }
            string decodedToken = Token.DecodeJWT(token);
            RawJWTPayload rawJWTPayload = JsonConvert.DeserializeObject<RawJWTPayload>(decodedToken);
            if (String.IsNullOrEmpty(rawJWTPayload.sub))
            {
                return null;
            }
            JWTPayload jWTPayload = new JWTPayload();
            jWTPayload.isSAMLUser = false;
            jWTPayload.providerType = "Cognito";
            jWTPayload.providerUserId = rawJWTPayload.sub;
            jWTPayload.userId = rawJWTPayload.sub;
            jWTPayload.email = rawJWTPayload.email;
            jWTPayload.emailVerified = rawJWTPayload.email_verified;
            jWTPayload.firstName = rawJWTPayload.given_name;
            jWTPayload.lastName = rawJWTPayload.family_name;
            jWTPayload.fullName = rawJWTPayload.name;
            jWTPayload.picture = rawJWTPayload.picture;
            jWTPayload.role = rawJWTPayload.customRole;
            jWTPayload.username = !String.IsNullOrEmpty(rawJWTPayload.email) ? rawJWTPayload.email : rawJWTPayload.sub;
            if (!String.IsNullOrEmpty(rawJWTPayload.customSupervisorEmail) && !String.IsNullOrEmpty(rawJWTPayload.customSupervisorName) && !String.IsNullOrEmpty(rawJWTPayload.customSupervisorUserId))
            {
                jWTPayload.supervisor = new FormSubmissionSupervisor();
                jWTPayload.supervisor.fullName = rawJWTPayload.customSupervisorName;
                jWTPayload.supervisor.email = rawJWTPayload.customSupervisorEmail;
                jWTPayload.supervisor.providerUserId = rawJWTPayload.customSupervisorUserId;
            }
            jWTPayload.phoneNumber = rawJWTPayload.customPhoneNumber;
            jWTPayload.phoneNumberVerified = rawJWTPayload.customPhoneNumberVerified;
            if (rawJWTPayload.identities.Count > 0)
            {
                jWTPayload.providerType = rawJWTPayload.identities[0].providerType;
                jWTPayload.providerUserId = rawJWTPayload.identities[0].userId;
                jWTPayload.isSAMLUser = rawJWTPayload.identities[0].providerType == "SAML";
                if (jWTPayload.isSAMLUser.HasValue && jWTPayload.isSAMLUser.Value == true)
                {
                    jWTPayload.username = !String.IsNullOrEmpty(rawJWTPayload.preferred_username) ? rawJWTPayload.preferred_username : rawJWTPayload.identities[0].userId;
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
