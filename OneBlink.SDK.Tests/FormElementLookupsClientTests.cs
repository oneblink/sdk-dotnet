using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class FormElementLookupsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private long formsAppEnvironmentId = 22;
        private string organisationId = "5c58beb2ff59481100000002";
        public FormElementLookupsClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
            string formsAppEnvironmentId = Environment.GetEnvironmentVariable("FORMS_APP_ENVIRONMENT_ID");
            if (!String.IsNullOrWhiteSpace(formsAppEnvironmentId))
            {
                this.formsAppEnvironmentId = long.Parse(formsAppEnvironmentId);
            }
            string organisationId = Environment.GetEnvironmentVariable("ORGANISATION_ID");
            if (!String.IsNullOrWhiteSpace(organisationId))
            {
                this.organisationId = organisationId;
            }
        }
        [Fact]
        public void can_be_constructed()
        {
            FormElementLookupsClient formElementLookupsClient = new FormElementLookupsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(formElementLookupsClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new FormElementLookupsClient("", ""));
        }

        [Fact]
        public async void can_crud_form_element_lookups()
        {
            FormElementLookupsClient formElementLookupsClient = new FormElementLookupsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementLookupSearchResult results = await formElementLookupsClient.Search(organisationId, null, null);
            Assert.NotNull(results);
            Assert.True(results.formElementLookups.Count <= 0, "Expected no form element lookups");

            FormElementLookup newFormElementLookup = new FormElementLookup();
            newFormElementLookup.name = "Unit test environment";
            newFormElementLookup.type = "DATA";
            newFormElementLookup.organisationId = organisationId;
            newFormElementLookup.environments = new System.Collections.Generic.List<FormElementLookupEnvironment>()
            {
                new FormElementLookupEnvironment()
                {
                    formsAppEnvironmentId = formsAppEnvironmentId,
                    url = "https://www.OneBlink.io",
                }
            };

            FormElementLookup savedFormElementLookup = await formElementLookupsClient.Create(newFormElementLookup);
            Assert.NotNull(savedFormElementLookup);

            FormElementLookup receivedFormElementLookup = await formElementLookupsClient.Get(savedFormElementLookup.id);
            Assert.NotNull(receivedFormElementLookup);

            String updatedUrl = "https://www.google.com";
            receivedFormElementLookup.environments = new System.Collections.Generic.List<FormElementLookupEnvironment>()
            {
                new FormElementLookupEnvironment()
                {
                    formsAppEnvironmentId = formsAppEnvironmentId,
                    url = updatedUrl,
                }
            };
            FormElementLookup updatedFormElementLookup = await formElementLookupsClient.Update(receivedFormElementLookup);
            foreach (FormElementLookupEnvironment formElementLookupEnvironment in updatedFormElementLookup.environments)
            {
                Assert.Equal(updatedUrl, formElementLookupEnvironment.url);
            }

            await formElementLookupsClient.Delete(updatedFormElementLookup.id);

            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => formElementLookupsClient.Get(updatedFormElementLookup.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
        }
    }
}

