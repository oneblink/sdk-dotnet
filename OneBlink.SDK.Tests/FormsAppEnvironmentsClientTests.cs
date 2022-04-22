using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class FormsAppEnvironmentsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private string organisationId = "5c58beb2ff59481100000002";
        private long formsAppEnvironmentId = 22;
        public FormsAppEnvironmentsClientTests()
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
        }

        [Fact]
        public void can_be_constructed()
        {
            FormsAppEnvironmentsClient formsAppEnvironmentsClient = new FormsAppEnvironmentsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(formsAppEnvironmentsClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new FormsAppEnvironmentsClient("", ""));
        }

        [Fact]
        public async void can_search_forms_app_environments()
        {
            FormsAppEnvironmentsClient formsAppEnvironmentsClient = new FormsAppEnvironmentsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormsAppEnvironmentsSearchResult results = await formsAppEnvironmentsClient.Search(null, null);
            Assert.NotNull(results);
            Assert.True(results.formsAppEnvironments.Count > 0, "Expected at least 1 environment");
        }

        [Fact]
        public async void can_crud_forms_app_environments()
        {
            FormsAppEnvironment newFormsAppEnvironment = new FormsAppEnvironment();
            newFormsAppEnvironment.name = "Unit test environment";
            newFormsAppEnvironment.description = "Created via unit test";
            newFormsAppEnvironment.organisationId = organisationId;
            newFormsAppEnvironment.slug = "unit-test-environment";

            FormsAppEnvironmentsClient formsAppEnvironmentsClient = new FormsAppEnvironmentsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormsAppEnvironment savedFormsAppEnvironment = await formsAppEnvironmentsClient.Create(newFormsAppEnvironment);
            Assert.NotNull(savedFormsAppEnvironment);

            FormsAppEnvironment receivedFormsAppEnvironment = await formsAppEnvironmentsClient.Get(savedFormsAppEnvironment.id);
            Assert.NotNull(receivedFormsAppEnvironment);

            String updatedDescription = "Updated via unit test";
            receivedFormsAppEnvironment.description = updatedDescription;
            FormsAppEnvironment updatedFormsAppEnvironment = await formsAppEnvironmentsClient.Update(receivedFormsAppEnvironment);
            Assert.Equal(updatedDescription, updatedFormsAppEnvironment.description);

            await formsAppEnvironmentsClient.Delete(updatedFormsAppEnvironment.id);
            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => formsAppEnvironmentsClient.Get(updatedFormsAppEnvironment.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
        }
    }
}