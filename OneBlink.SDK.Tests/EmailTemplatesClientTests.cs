using dotenv.net;
using System.IO;
using System;
using Xunit;
using OneBlink.SDK.Model;
using System.Net;

namespace OneBlink.SDK.Tests
{
    public class EmailTemplatesClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private int formsAppEnvironmentId = 22;
        public EmailTemplatesClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
            string formsAppEnvironmentId = Environment.GetEnvironmentVariable("FORMS_APP_ENVIRONMENT_ID");
            if (!String.IsNullOrWhiteSpace(formsAppEnvironmentId))
            {
                this.formsAppEnvironmentId = Int32.Parse(formsAppEnvironmentId);
            }
        }
        [Fact]
        public void can_be_constructed()
        {
            EmailTemplatesClient emailTemplatesClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(emailTemplatesClient);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new EmailTemplatesClient("", ""));
        }

        [Fact]
        public async void can_search_email_templates()
        {
            EmailTemplatesClient emailTemplatesClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            EmailTemplatesSearchResult results = await emailTemplatesClient.Search(formsAppEnvironmentId, null, null);
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

            EmailTemplatesClient emailTemplatesClient = new EmailTemplatesClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            EmailTemplate savedEmailClient = await emailTemplatesClient.Create(newEmailTemplate);
            Assert.NotNull(savedEmailClient);

            EmailTemplate receivedEmailTemplate = await emailTemplatesClient.Get(savedEmailClient.id);
            Assert.NotNull(receivedEmailTemplate);

            String updatedDescription = "Updated via unit test";
            receivedEmailTemplate.template = updatedDescription;
            EmailTemplate updatedEmailTemplate = await emailTemplatesClient.Update(receivedEmailTemplate);
            Assert.Equal(updatedDescription, updatedEmailTemplate.template);

            await emailTemplatesClient.Delete(updatedEmailTemplate.id);

            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => emailTemplatesClient.Get(updatedEmailTemplate.id));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
        }
    }
}

