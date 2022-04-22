using System;
using System.IO;
using System.Net;
using System.Reflection;
using dotenv.net;
using OneBlink.SDK.Model;
using Xunit;
using System.Collections.Generic;

namespace OneBlink.SDK.Tests
{
    public class FormsAppsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private string organisationId = "5c58beb2ff59481100000002";
        private long formsAppEnvironmentId = 22;
        public FormsAppsClientTests()
        {
            bool raiseException = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: raiseException, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
            string organisationId = Environment.GetEnvironmentVariable("ORGANISATION_ID");
            if (!String.IsNullOrWhiteSpace(organisationId))
            {
                this.organisationId = organisationId;
            }
            string formsAppEnvironmentId = Environment.GetEnvironmentVariable("FORMS_APP_ENVIRONMENT_ID");
            if (!String.IsNullOrWhiteSpace(formsAppEnvironmentId))
            {
                this.formsAppEnvironmentId = long.Parse(formsAppEnvironmentId);
            }
        }

        [Fact]
        public void can_be_constructed()
        {
            FormsAppsClient formsApps = new FormsAppsClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(formsApps);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new FormsAppsClient("", ""));
        }

        [Fact]
        public async void verify_function_throws_correct_error_when_jwt_from_wrong_issuer()
        {
            FormsAppsClient formsApps = new FormsAppsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK);
            string token = "eyJraWQiOiJKSWR1dzRYbmlRSmp1dFFpdURTM2tcL1ZtbGY3d05zWEF5cXV2MHJaenE3Zz0iLCJhbGciOiJSUzI1NiJ9.eyJhdF9oYXNoIjoicEtTcDJ5djFJR0lRRS01d2VPNE5zZyIsInN1YiI6ImJlODlmM2I2LTgzMjEtNGI0YS1iMzFkLTlmN2Q2MDg4MDY2MyIsImNvZ25pdG86Z3JvdXBzIjpbImFwLXNvdXRoZWFzdC0yX0UwM3hCYWFmVF9Hb29nbGUiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC5hcC1zb3V0aGVhc3QtMi5hbWF6b25hd3MuY29tXC9hcC1zb3V0aGVhc3QtMl9FMDN4QmFhZlQiLCJjb2duaXRvOnVzZXJuYW1lIjoiR29vZ2xlXzEwMjY4MzQ0NzgyODA1MDYzNDM3OSIsImdpdmVuX25hbWUiOiJNYXR0IiwicGljdHVyZSI6Imh0dHBzOlwvXC9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tXC9hLVwvQU9oMTRHaXVRR0xXRXlfZ0tvODk3aHZ6YklJTXFLY2JPcEFEa1JES3NYQm09czk2LWMiLCJhdWQiOiI1ZDBlZjJrdmZqbzl1ZXZidWQ5bmY3MmZvYSIsImlkZW50aXRpZXMiOlt7InVzZXJJZCI6IjEwMjY4MzQ0NzgyODA1MDYzNDM3OSIsInByb3ZpZGVyTmFtZSI6Ikdvb2dsZSIsInByb3ZpZGVyVHlwZSI6Ikdvb2dsZSIsImlzc3VlciI6bnVsbCwicHJpbWFyeSI6InRydWUiLCJkYXRlQ3JlYXRlZCI6IjE1NTEzOTQwMTgyOTMifV0sInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNTg5MTYxMTIxLCJuYW1lIjoiTWF0dCBDYXJyb2xsIiwiZXhwIjoxNTkxNjcyMzc1LCJpYXQiOjE1OTE2Njg3NzUsImZhbWlseV9uYW1lIjoiQ2Fycm9sbCIsImVtYWlsIjoibWF0dEBvbmVibGluay5pbyJ9.PqdETv9X7iHvW0kEAF9m_yZH_KhkZG3sR6ijLWLGf-sVrXdY0U-ydKQ4_BspLF8kpqyajdsZjhCo7HWDzPpRi2cM_Q9uRalK2JqHcLcGZ4t0Rma3DymMz-U4DtLdD8Fu-n5q1uBAIEfKLrIg1pzzTh-GggjM_ZloJVeWtkrYxJcHQAoj1VSXDA2BA_5dyhqJcaAQYf4h1y9kVWlCPDW9pR1d9_QCOx2d55MBIDP2b-fJoCbOQYQo_87ZR0qYkNEDZsaOdDGUZfY6IDYoopramwpnGUSzv8lE2_DFtaJaVcXd48dROg-n_8BIIAJBHqighRo4E-LpftlEOgMRlLBG_A";
            var ex = await Assert.ThrowsAsync<System.Exception>(() => formsApps.VerifyJWT(token));
            Assert.Equal("Did not find Json Web Key", ex.Message);
        }

        [Fact]
        public async void verify_function_throws_correct_error_when_jwt_expired()
        {
            FormsAppsClient formsApps = new FormsAppsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK);
            string token = "eyJraWQiOiJSaTZ1VzQzQ1ZlNmhtQ1NcL291Rms1TnlaUkI4aytaUmZGc3RPYUliNHdNaz0iLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiI4ODcyNGRlMy1kNzI4LTQ0OGEtYjBhOS03YzFiNTg1ZjFmMGYiLCJjb2duaXRvOmdyb3VwcyI6WyJhcC1zb3V0aGVhc3QtMl9vMXQzbnRHV3hfR29vZ2xlIl0sInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoiYXdzLmNvZ25pdG8uc2lnbmluLnVzZXIuYWRtaW4gb3BlbmlkIHByb2ZpbGUgZW1haWwiLCJhdXRoX3RpbWUiOjE1OTEwNzgyNTEsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC5hcC1zb3V0aGVhc3QtMi5hbWF6b25hd3MuY29tXC9hcC1zb3V0aGVhc3QtMl9vMXQzbnRHV3giLCJleHAiOjE1OTE3NDg4ODMsImlhdCI6MTU5MTc0NTI4MywidmVyc2lvbiI6MiwianRpIjoiOTVlNjI0ODEtMWVlNC00NGE4LWE0ZWMtMGVjNDMxOTJhYTIyIiwiY2xpZW50X2lkIjoiNzBtbmp2MjFkbXBkMWtjOWZlZmx0OWRoZGkiLCJ1c2VybmFtZSI6Ikdvb2dsZV8xMTU1MzExMjk5MzE2MTk0Nzk4NTUifQ.hm8Xn1ya0R-Zouuo0OkWiguThso8AkYYcQR4K8m3wxxtCBtUuEo046ZOFbRMOTb977bkr2AZY8PKlr4BuO35yDYD6ieKdMte3L8KvXw25F4u1Z33TJsFwGZpWUfmF41rfsTNbOx8vG6LVbMxEF1omBlYd0MPe3o8nCBICHJWYykGmGYjiTO4T2HRtbf9BJlAOEOUOcTKyKLqSQp7RUubsdfG-l05zWpuZLFVIaOwbs8EFPrMeDr6e0VPNjBTTKX-jaEojD5cI9AoEpyc4OY3N1lNXYCPCWu-ahXlUkSeUg919FsQ3J_L2qxOfBi-_EOuKanM6e343NXuxNn7_h9tMw";
            var ex = await Assert.ThrowsAsync<Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException>(() => formsApps.VerifyJWT(token));
            Assert.StartsWith("IDX10223: Lifetime validation failed. The token is expired. ValidTo: ", ex.Message);
        }

        [Fact]
        public async void can_crud_forms_app()
        {
            FormsAppsClient formsAppsClient = new FormsAppsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);

            FormsAppPWASettings pWASettings = new FormsAppPWASettings();
            var newFormsApp = new FormsListFormsApp();
            newFormsApp.name = "Unit test app";
            newFormsApp.slug = DateTime.Now.ToFileTimeUtc().ToString();
            newFormsApp.organisationId = organisationId;
            newFormsApp.formsAppEnvironmentId = formsAppEnvironmentId;
            newFormsApp.formIds = new List<long>();
            newFormsApp.pwaSettings = pWASettings;
            newFormsApp.notificationEmailAddresses = new List<string>() { "developers@oneblink.io" };

            var savedFormsApp = await formsAppsClient.Create<FormsListFormsApp>(newFormsApp);
            Assert.NotNull(savedFormsApp);

            var retrievedFormsApp = await formsAppsClient.Get<FormsListFormsApp>(savedFormsApp.id);
            Assert.NotNull(retrievedFormsApp);

            String updatedName = "Unit test app updated";
            retrievedFormsApp.name = updatedName;
            var updatedFormsApp = await formsAppsClient.Update<FormsListFormsApp>(retrievedFormsApp);
            Assert.Equal(updatedName, updatedFormsApp.name);

            // create and delete user
            FormsAppUser newUser = new FormsAppUser();
            newUser.formsAppId = updatedFormsApp.id;
            newUser.email = "test@oneblink.io";

            FormsAppUser savedUser = await formsAppsClient.CreateUser(newUser);
            Assert.NotNull(savedUser);
            await formsAppsClient.DeleteUser(savedUser.id);

            await formsAppsClient.Delete(updatedFormsApp.id);

            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => formsAppsClient.Get<FormsListFormsApp>(updatedFormsApp.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
        }

        [Fact]
        public void can_encrypt_and_decrypt_user_token()
        {
            AesUserToken aesUserToken = new AesUserToken("secret");
            string username = "zac@oneblink.io";
            string userToken = aesUserToken.encrypt(username);
            Assert.NotNull(userToken);

            string decryptedUsername = aesUserToken.decrypt(userToken);

            Assert.Equal(username, decryptedUsername);
        }

        [Fact]
        public void can_decrypt_user_token_from_js_sdk()
        {
            AesUserToken aesUserToken = new AesUserToken("secret");
            string userToken = "ZGyRaKLZY5w96FLTGHZEO0eKZQD0XGg1FwHrSrchUgI=";
            string decryptedUsername = aesUserToken.decrypt(userToken);

            Assert.Equal("zac@oneblink.io", decryptedUsername);
        }
    }
}