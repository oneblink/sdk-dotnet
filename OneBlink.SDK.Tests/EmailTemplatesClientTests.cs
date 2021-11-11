using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using Newtonsoft.Json;

namespace OneBlink.SDK.Tests
{
    public class EmailTemplatesClientTests
    {
        private int formsAppEnvironmentId = 22;
        public EmailTemplatesClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
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
                this.formsAppEnvironmentId = Int32.Parse(formsAppEnvironmentId);
            }
        }
        [Fact]
        public void can_be_constructed()
        {
            EmailTemplatesClient EmailTemplatesClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(EmailTemplatesClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            try
            {
                EmailTemplatesClient emailTemplateClient = new EmailTemplatesClient("", "");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void can_search_email_templates()
        {
            EmailTemplatesClient emailTemplateClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            EmailTemplatesSearchResult results = await emailTemplateClient.Search(formsAppEnvironmentId, null, null);
            Assert.NotNull(results);
            Assert.True(results.emailTemplates.Count > 0, "Expected at least 1 email template");
        }

        [Fact]
        public async void can_crud_email_templates()
        {
            EmailTemplate newEmailTemplate = new EmailTemplate();
            newEmailTemplate.name = "Unit test environment";
            newEmailTemplate.template = "Created via unit test";
            newEmailTemplate.formsAppEnvironmentId = formsAppEnvironmentId;
            newEmailTemplate.type = "FORM_SUBMISSION_EVENT_PDF";

            EmailTemplatesClient emailTemplateClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            EmailTemplate savedEmailClient = await emailTemplateClient.Create(newEmailTemplate);
            Assert.NotNull(savedEmailClient);

            EmailTemplate receivedEmailTemplate = await emailTemplateClient.Get(savedEmailClient.id);
            Assert.NotNull(receivedEmailTemplate);

            String updatedDescription = "Updated via unit test";
            receivedEmailTemplate.template = updatedDescription;
            EmailTemplate updatedEmailTemplate = await emailTemplateClient.Update(receivedEmailTemplate);
            Assert.Equal(updatedDescription, updatedEmailTemplate.template);

            await emailTemplateClient.Delete(updatedEmailTemplate.id);

            try
            {
                EmailTemplate deletedEmailTemplate = await emailTemplateClient.Get(updatedEmailTemplate.id);
                throw new Exception("Email Template was able to be retrieved after being deleted!");
            }
            catch (OneBlink.SDK.OneBlinkAPIException ex)
            {
                Assert.Equal("Email Template not found", ex.Message);
            }
        }
    }
}

