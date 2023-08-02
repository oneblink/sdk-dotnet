using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class FormElementListsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private long formsAppEnvironmentId = 22;
        private string organisationId = "5c58beb2ff59481100000002";
        public FormElementListsClientTests()
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
            FormElementListsClient formElementListsClient = new FormElementListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(formElementListsClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new FormElementListsClient("", ""));
        }

        [Fact]
        public async void can_search_form_element_lists()
        {
            FormElementListsClient formElementListsClient = new FormElementListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementListSearchResult results = await formElementListsClient.Search(organisationId, null, null);
            Assert.NotNull(results);
        }

        [Fact]
        public async void can_crud_form_element_lists()
        {
            FormElementList newFormElementList = new FormElementList();
            newFormElementList.name = "Unit test environment";
            newFormElementList.type = "URL";
            newFormElementList.organisationId = organisationId;
            newFormElementList.environments = new System.Collections.Generic.List<FormElementListEnvironment>()
            {
                new FormElementListEnvironment()
                {
                    formsAppEnvironmentId = formsAppEnvironmentId,
                    url = "https://www.OneBlink.io",
                }
            };

            FormElementListsClient formElementListsClient = new FormElementListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementList savedFormElementList = await formElementListsClient.Create(newFormElementList);
            Assert.NotNull(savedFormElementList);

            FormElementListSearchResult results = await formElementListsClient.Search(organisationId, null, null);
            FormElementList receivedFormElementList = results.formElementLists.Find(formElementList => formElementList.id == savedFormElementList.id);
            Assert.NotNull(receivedFormElementList);

            String updatedUrl = "https://www.google.com";
            receivedFormElementList.environments = new System.Collections.Generic.List<FormElementListEnvironment>()
            {
                new FormElementListEnvironment()
                {
                    formsAppEnvironmentId = formsAppEnvironmentId,
                    url = updatedUrl,
                }
            };
            FormElementList updatedFormElementList = await formElementListsClient.Update(receivedFormElementList);
            foreach (FormElementListEnvironment formElementListEnvironment in updatedFormElementList.environments)
            {
                Assert.Equal(updatedUrl, formElementListEnvironment.url);
            }

            await formElementListsClient.Delete(updatedFormElementList.id);
        }
    }
}

