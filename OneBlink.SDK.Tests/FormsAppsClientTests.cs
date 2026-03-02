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
        private long workspaceId = 12;
        public FormsAppsClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
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
            string workspaceId = Environment.GetEnvironmentVariable("WORKSPACE_ID");
            if (!String.IsNullOrWhiteSpace(workspaceId))
            {
                this.workspaceId = long.Parse(workspaceId);
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
            string token = "eyJraWQiOiJKSzRrMFBmRFlxT24zOGFIY0xHRis3NmZjWTIrU3R4a3d0VG1DSXBWYjJnPSIsImFsZyI6IlJTMjU2In0.eyJhdF9oYXNoIjoiNjZlejByQ3RST0xtMXZyUUV0WUZEZyIsInN1YiI6IjAyMDMyMTM5LWZmMTMtNGM4Zi1iZTQ3LTNiZTUzNGI5YjQyOSIsImNvZ25pdG86Z3JvdXBzIjpbImFwLXNvdXRoZWFzdC0yXzdrQXN6M24zeF9Hb29nbGUiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC5hcC1zb3V0aGVhc3QtMi5hbWF6b25hd3MuY29tXC9hcC1zb3V0aGVhc3QtMl83a0FzejNuM3giLCJjb2duaXRvOnVzZXJuYW1lIjoiZ29vZ2xlXzEwMjY4MzQ0NzgyODA1MDYzNDM3OSIsImdpdmVuX25hbWUiOiJNYXR0IiwicGljdHVyZSI6Imh0dHBzOlwvXC9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tXC9hXC9BTG01d3UyRHFpcEVvNl9BQ1ZIa3gxZk11amF6aC04QThEQVpLejdtelNYQj1zOTYtYyIsIm9yaWdpbl9qdGkiOiI3MzM1YmZmOC0yODQ5LTQ5N2YtOGQ3OC0xZTU5OWMzNzFjNTIiLCJhdWQiOiI3dTJ2amp2YTVndmcxa2F0dGJvdnZjYmljMSIsImlkZW50aXRpZXMiOlt7InVzZXJJZCI6IjEwMjY4MzQ0NzgyODA1MDYzNDM3OSIsInByb3ZpZGVyTmFtZSI6Ikdvb2dsZSIsInByb3ZpZGVyVHlwZSI6Ikdvb2dsZSIsImlzc3VlciI6bnVsbCwicHJpbWFyeSI6InRydWUiLCJkYXRlQ3JlYXRlZCI6IjE2NjgzMDQ0ODE3MzYifV0sInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjY4MzA0NDgzLCJuYW1lIjoiTWF0dCBDYXJyb2xsIiwiZXhwIjoxNjY4Mzg2ODg2LCJpYXQiOjE2NjgzODMyODYsImZhbWlseV9uYW1lIjoiQ2Fycm9sbCIsImp0aSI6Ijk2MWUzY2M3LThiYjUtNGNhMS1iNjAwLWEwMzAwYzQzMDI1OCIsImVtYWlsIjoibWF0dEBvbmVibGluay5pbyJ9.MTEpY-wTWnKhna2ritfke1Kx0yoYODmXPgvJbq-7URDXzOGtbPbh-f1OKaJaNOxi3XqB48r6yv5kfd3CzSR6OEpAuWV5Bq8Oi21uiyoIyZZJCLRPRiIjRLGh3qCS87pL98MHgZuwKUOqNu0e6zte5r7SmI93aC0Pg5_UcYEzT5YlARI0DHqgU77xsXEleZgP6J5bcD_HhM-iGMNAZGxQfT-OIvbEgKlIERT2QEEx2P0BErxs3fRae9dJ6CwlKir_edVc75ru_fS5qXMRZXW-BI-G2vhuVWJ1GkjWCuB4XLxPyz_Tieui4D1ZmbdU3YwaYdBEFe2Kwdj65QrW4NhaOw";
            var ex = await Assert.ThrowsAsync<Microsoft.IdentityModel.Tokens.SecurityTokenExpiredException>(() => formsApps.VerifyJWT(token));
            Assert.StartsWith("IDX10223: Lifetime validation failed. The token is expired. ValidTo ", ex.Message);
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
            newFormsApp.workspaceId = workspaceId;
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