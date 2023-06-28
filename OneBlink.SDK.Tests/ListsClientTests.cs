using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class ListsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private long formsAppEnvironmentId = 22;
        private string organisationId = "5c58beb2ff59481100000002";
        public ListsClientTests()
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
            ListsClient listsClient = new ListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(listsClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new ListsClient("", ""));
        }

        [Fact]
        public async void can_search_form_element_lists()
        {
            ListsClient listsClient = new ListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementListSearchResult results = await listsClient.Search(organisationId, null, null);
            Assert.NotNull(results);
            Assert.True(results.FormElementLists.Count <= 0, "Expected no form element lists");
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

            ListsClient listsClient = new ListsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormElementList savedFormElementList = await listsClient.Create(newFormElementList);
            Assert.NotNull(savedFormElementList);

            FormElementListSearchResult results = await listsClient.Search(organisationId, null, null);
            Assert.Single(results.FormElementLists);

            FormElementList receivedFormElementList = results.FormElementLists[0];

            String updatedUrl = "https://www.google.com";
            receivedFormElementList.environments = new System.Collections.Generic.List<FormElementListEnvironment>()
            {
                new FormElementListEnvironment()
                {
                    formsAppEnvironmentId = formsAppEnvironmentId,
                    url = updatedUrl,
                }
            };
            FormElementList updatedFormElementList = await listsClient.Update(receivedFormElementList);
            foreach (FormElementListEnvironment formElementListEnvironment in updatedFormElementList.environments)
            {
                Assert.Equal(updatedUrl, formElementListEnvironment.url);
            }

            await listsClient.Delete(updatedFormElementList.id);
        }
    }
}

