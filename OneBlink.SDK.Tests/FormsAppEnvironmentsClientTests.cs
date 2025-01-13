using dotenv.net;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;
using System.Collections.Generic;
// Need to each test run sequenatially, both within the assembly and with in the class, as certain resources (e.g. s3 bucket) are shared
// NOTE: This assembly directive applies to the whole test project
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true)]
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
            FormsAppEnvironmentsClient formsAppEnvironmentsClient = new FormsAppEnvironmentsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormsAppEnvironment newFormsAppEnvironment = new FormsAppEnvironment();
            newFormsAppEnvironment.name = "Unit test environment";
            newFormsAppEnvironment.description = "Created via unit test";
            newFormsAppEnvironment.organisationId = organisationId;
            newFormsAppEnvironment.slug = "unit-test-environment-" + DateTime.Now.ToFileTimeUtc().ToString();
            newFormsAppEnvironment.notificationEmailAddresses = new List<string>() { "developers@oneblink.io" };

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

        [Fact]
        public async void can_clone_forms_app_environment()
        {
            FormsAppEnvironmentsClient formsAppEnvironmentsClient = new(this.ACCESS_KEY, this.SECRET_KEY, TenantName.ONEBLINK_TEST);

            FormsAppEnvironment environment = await formsAppEnvironmentsClient.Get(22);
            Assert.Equal(22, environment.id);

            FormsAppEnvironment clonedEnvironment = await formsAppEnvironmentsClient.Create(
                new FormsAppEnvironment()
                {
                    name = "Cloned Environment",
                    slug = "cloned-prod-" + DateTime.Now.ToFileTimeUtc().ToString(),
                    organisationId = this.organisationId,
                    notificationEmailAddresses = new List<string>() { "developers@oneblink.io" },
                    cloneOptions = new FormsAppEnvironmentCloneOptions()
                    {
                        isCloningFormElementLookups = true,
                        isCloningFormElementOptionsSets = true,
                        isCloningFormExternalIdGenerationOnSubmit = true,
                        isCloningFormPersonalisation = true,
                        isCloningFormPostSubmissionActions = true,
                        isCloningFormServerValidation = true,
                        isCloningFormSubmissionEvents = true,
                        isCloningFormApprovalSteps = true,
                        sourceFormsAppEnvironmentId = environment.id,
                    }
                }
            );
            System.Threading.Thread.Sleep(5000); // give the API time to finish cloning before deleting the clone environment
            await formsAppEnvironmentsClient.Delete(clonedEnvironment.id);
            OneBlinkAPIException oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => formsAppEnvironmentsClient.Get(clonedEnvironment.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);

        }
    }
}