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
    public class FormsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private string apiOrigin;
        private int formId = 475;
        private string submissionId = "5ab3d950-253a-4d22-8ae6-c9eae82f58ba";
        private int draftFormId = 475;
        private string draftDataId = "b2925fbd-f490-49d9-ba07-1c57b97dd120";
        private string organisationId = "5c58beb2ff59481100000002";
        private int formsAppEnvironmentId = 22;
        private int formsAppId = 79;
        public FormsClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
            apiOrigin = Environment.GetEnvironmentVariable("ONEBLINK_API_ORIGIN");

            string formId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(formId))
            {
                this.formId = Int16.Parse(formId);
            }
            string submissionId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_SUBMISSION_ID");
            if (!String.IsNullOrWhiteSpace(submissionId))
            {
                this.submissionId = submissionId;
            }
            string draftFormId = Environment.GetEnvironmentVariable("GET_DRAFT_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(draftFormId))
            {
                this.draftFormId = Int16.Parse(draftFormId);
            }
            string draftDataId = Environment.GetEnvironmentVariable("GET_DRAFT_DATA_DRAFT_DATA_ID");
            if (!String.IsNullOrWhiteSpace(submissionId))
            {
                this.draftDataId = draftDataId;
            }
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
            string formsAppId = Environment.GetEnvironmentVariable("FORMS_APP_ID");
            if (!String.IsNullOrWhiteSpace(formsAppId))
            {
                this.formsAppId = Int32.Parse(formsAppId);
            }
        }

        [Fact]
        public void can_be_constructed()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(forms);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            try
            {
                FormsClient forms = new FormsClient(
                  "",
                  ""
                );
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void can_search_forms()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormsSearchResult response = await forms.Search(null, null, null);
            Assert.NotNull(response);
        }

        [Fact]
        public async void can_search_forms_with_all_params()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormsSearchResult response = await forms.Search(true, true, "Location test");
            Assert.NotNull(response);
        }

        [Fact]
        public async void can_get_draft_data()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormSubmission<object> draftSubmission = await forms.GetFormSubmission<object>(this.draftFormId, this.draftDataId, true);
            Assert.NotNull(draftSubmission);
            Assert.NotNull(draftSubmission.definition);
            Assert.NotNull(draftSubmission.submission);
        }

        [Fact]
        public async void get_draft_data_should_throw_oneblink_exception()
        {
            FormsClient forms = new FormsClient(
              "123",
              "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc",
              tenantName: TenantName.ONEBLINK_TEST
            );
            try
            {
                FormSubmission<object> draftSubmission = await forms.GetFormSubmission<object>(this.draftFormId, this.draftDataId, true);
                Console.WriteLine("Submission as JSON string: " + draftSubmission.submission);
                Assert.NotNull(null);
            }
            catch (OneBlinkAPIException oneBlinkAPIException)
            {
                Assert.NotNull(oneBlinkAPIException);
                Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
                Console.WriteLine(oneBlinkAPIException);
            }
        }

        [Fact]
        public async void can_get_submission_data()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormSubmission<object> formSubmission = await forms.GetFormSubmission<object>(this.formId, this.submissionId);
            Assert.NotNull(formSubmission);
            if (formSubmission.device != null)
            {
                foreach (PropertyInfo propertyInfo in formSubmission.device.GetType().GetProperties())
                {
                    Console.WriteLine("Device: {0}={1}", propertyInfo.Name, propertyInfo.GetValue(formSubmission.device, null));
                }
            }
            if (formSubmission.user != null)
            {
                foreach (PropertyInfo propertyInfo in formSubmission.user.GetType().GetProperties())
                {
                    Console.WriteLine("User: {0}={1}", propertyInfo.Name, propertyInfo.GetValue(formSubmission.user, null));
                }
            }
        }

        [Fact]
        public async void get_submission_data_should_throw_oneblink_exception()
        {
            FormsClient forms = new FormsClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc");
            try
            {
                FormSubmission<object> formSubmission = await forms.GetFormSubmission<object>(this.formId, this.submissionId);
                Assert.NotNull(null);
            }
            catch (OneBlinkAPIException oneBlinkAPIException)
            {
                Assert.NotNull(oneBlinkAPIException);
                Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
                Console.WriteLine(oneBlinkAPIException);
            }
        }

        [Fact]
        public async void can_crud_form()
        {
            Form newForm = new Form();
            newForm.name = "Unit test";
            newForm.description = "Created via unit test";
            newForm.organisationId = organisationId;
            newForm.isAuthenticated = false;
            newForm.isPublished = true;
            newForm.isMultiPage = false;
            newForm.formsAppEnvironmentId = formsAppEnvironmentId;
            newForm.postSubmissionAction = "FORMS_LIBRARY";

            List<long> formsAppIds = new List<long>();
            formsAppIds.Add(formsAppId);
            newForm.formsAppIds = formsAppIds;

            FormElement textElement = FormElement.CreateTextElement(
                "Unit_test_element",
                "Unit test element",
                Guid.NewGuid(),
                false,
                false,
                null,
                true,
                false,
                "default Value",
                "placeholder value"
            );

            FormElement summaryElement = FormElement.CreateSummaryElement(
                "Summary_test_element",
                "Summary test element",
                new List<Guid>() { textElement.id },
                Guid.NewGuid(),
                false,
                false,
                null
            );
            newForm.elements = new List<FormElement>() { textElement, summaryElement };

            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Form savedForm = await formsClient.Create(newForm);
            Assert.NotNull(savedForm);
            Form retrievedForm = await formsClient.Get(savedForm.id, true);
            Assert.NotNull(retrievedForm);
            String updatedDescription = "Updated via unit test";
            retrievedForm.description = updatedDescription;
            Form updatedForm = await formsClient.Update(retrievedForm);
            Assert.Equal(updatedDescription, updatedForm.description);
            await formsClient.Delete(updatedForm.id);

            try
            {
                Form deletedForm = await formsClient.Get(updatedForm.id, true);
                throw new Exception("Form was able to be retrieved after being deleted!");
            }
            catch (OneBlink.SDK.OneBlinkAPIException ex)
            {
                Assert.Equal("Form not found", ex.Message);
            }
        }
        [Fact]
        public async void can_create_with_defaults()
        {
            Form newForm = new Form(
                "name",
                "description",
                organisationId,
                formsAppEnvironmentId
            );
            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Form savedForm = await formsClient.Create(newForm);
            savedForm.elements = new List<FormElement>()
            {
                FormElement.CreateTextElement(
                    label: "Text",
                    name: "Text"
                ),
                FormElement.CreateTextElement(
                    label: "Text2",
                    name: "Text2"
                )
            };
            Form updatedForm = await formsClient.Update(savedForm);

        }
    }
}