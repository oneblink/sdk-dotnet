using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class LookupsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private long formsAppEnvironmentId = 22;
        private string organisationId = "5c58beb2ff59481100000002";
        public LookupsClientTests()
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
            LookupsClient lookupsClient = new LookupsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(lookupsClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new LookupsClient("", ""));
        }

        [Fact]
        public async void can_search_form_element_lookups()
        {
            LookupsClient lookupsClient = new LookupsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementLookupSearchResult results = await lookupsClient.Search(organisationId, null, null);
            Assert.NotNull(results);
            Assert.True(results.formElementLookups.Count <= 0, "Expected no form element lookups");
        }

        [Fact]
        public async void can_crud_form_element_lookups()
        {
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

            LookupsClient lookupsClient = new LookupsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementLookup savedFormElementLookup = await lookupsClient.Create(newFormElementLookup);
            Assert.NotNull(savedFormElementLookup);

            FormElementLookup receivedFormElementLookup = await lookupsClient.Get(savedFormElementLookup.id);
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
            FormElementLookup updatedFormElementLookup = await lookupsClient.Update(receivedFormElementLookup);
            foreach (FormElementLookupEnvironment formElementLookupEnvironment in updatedFormElementLookup.environments)
            {
                Assert.Equal(updatedUrl, formElementLookupEnvironment.url);
            }

            await lookupsClient.Delete(updatedFormElementLookup.id);

            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => lookupsClient.Get(updatedFormElementLookup.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
        }
    }
}

