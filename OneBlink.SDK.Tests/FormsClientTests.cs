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
        private long formId = 475;
        private string submissionId = "9e947f75-b952-4c45-ab37-f4429ecef1ff";
        private long draftFormId = 475;
        private string draftDataId = "8b1e6988-1ee7-4437-9e47-0d6a46d039a4";
        private string organisationId = "5c58beb2ff59481100000002";
        private long formsAppEnvironmentId = 22;
        private long formsAppId = 79;
        public FormsClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");

            string formId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(formId))
            {
                this.formId = long.Parse(formId);
            }
            string submissionId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_SUBMISSION_ID");
            if (!String.IsNullOrWhiteSpace(submissionId))
            {
                this.submissionId = submissionId;
            }
            string draftFormId = Environment.GetEnvironmentVariable("GET_DRAFT_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(draftFormId))
            {
                this.draftFormId = long.Parse(draftFormId);
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
                this.formsAppEnvironmentId = long.Parse(formsAppEnvironmentId);
            }
            string formsAppId = Environment.GetEnvironmentVariable("FORMS_APP_ID");
            if (!String.IsNullOrWhiteSpace(formsAppId))
            {
                this.formsAppId = long.Parse(formsAppId);
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
            Assert.Throws<ArgumentException>(() => new FormsClient("", ""));
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
              "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc", // DevSkim: ignore DS173237
              tenantName: TenantName.ONEBLINK_TEST
            );
            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => forms.GetFormSubmission<object>(this.draftFormId, this.draftDataId, true));
            Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
        }

        [Fact]
        public async void can_execute_form_workflow_event()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormSubmissionWorkflowEvent formSubmissionWorkflowEvent = await forms.ExecuteWorkflowEvent(this.formId, Guid.Parse(this.submissionId), new FormSubmissionEvent()
            {
                type = "CALLBACK",
                configuration = new FormSubmissionEventConfiguration()
                {
                    url = "https://httpstat.us/200",
                    organisationManagedSecretId = 65
                }
            });
            Assert.NotNull(formSubmissionWorkflowEvent);
            Assert.Equal(formSubmissionWorkflowEvent.formId, this.formId);
            Assert.Equal(formSubmissionWorkflowEvent.submissionId, Guid.Parse(this.submissionId));
        }

        [Fact]
        public async void can_get_submission_data()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormSubmission<object> formSubmission = await forms.GetFormSubmission<object>(this.formId, this.submissionId);
            Assert.NotNull(formSubmission);
        }

        [Fact]
        public async void can_get_form_submission_meta()
        {
            FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            var formSubmissionMeta = await forms.GetFormSubmissionMeta(this.submissionId);
            Assert.NotNull(formSubmissionMeta);
        }

        [Fact]
        public async void get_submission_data_should_throw_oneblink_exception()
        {
            FormsClient forms = new FormsClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc", TenantName.ONEBLINK_TEST); // DevSkim: ignore DS173237
            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => forms.GetFormSubmission<object>(this.formId, this.submissionId));
            Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
        }

        [Fact]
        public async void can_crud_form()
        {
            List<string> tags = new List<string>() { "Unit", "Test" };
            // Need to use Today instead of Now so the time is a whole number of seconds,
            // otherwise js rounds seconds and C# does not, resulting in different times
            DateTime startDate = DateTime.Today.AddDays(5);
            DateTime endDate = DateTime.Today.AddDays(10);
            Form newForm = new Form();
            newForm.name = "Unit test";
            string slug = "unit-test-" + DateTime.Now.ToString("o").Replace(":", "-").Replace(".", "-").Replace("+", "-").ToLower();
            newForm.slug = slug;
            newForm.description = "Created via unit test";
            newForm.organisationId = organisationId;
            newForm.isAuthenticated = false;
            newForm.isMultiPage = false;
            newForm.formsAppEnvironmentId = formsAppEnvironmentId;
            newForm.postSubmissionAction = "FORMS_LIBRARY";
            newForm.tags = tags;
            newForm.publishStartDate = startDate;
            newForm.publishEndDate = endDate;
            newForm.unpublishedUserMessage = "<p>Try again later</p>";
            newForm.cancelAction = "URL";
            newForm.cancelRedirectUrl = "https://google.com";
            newForm.postSubmissionReceipt = new FormPostSubmissionReceipt()
            {
                html = "<p>test</p>"
            };
            newForm.externalIdGenerationOnSubmit = new FormExternalIdGeneration()
            {
                type = "RECEIPT_ID",
                configuration = new FormExternalIdGenerationConfiguration()
                {
                    receiptComponents = new List<FormExternalIdGenerationReceiptComponent>()
                    {
                        new FormExternalIdGenerationReceiptComponent()
                        {
                            type = "text",
                            value = "PREFIX"
                        },
                        new FormExternalIdGenerationReceiptComponent()
                        {
                            type = "date",
                            format = "dayOfMonth"
                        },
                        new FormExternalIdGenerationReceiptComponent()
                        {
                            type = "date",
                            format = "monthNumber"
                        },
                        new FormExternalIdGenerationReceiptComponent()
                        {
                            type = "date",
                            format = "year"
                        },
                        new FormExternalIdGenerationReceiptComponent()
                        {
                            type = "random",
                            length = 4,
                            uppercase = true,
                            lowercase = false,
                            numbers = true
                        },
                    }
                }
            };

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
                "default",
                "placeholder value",
                minLength: 2,
                maxLength: 10
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

            FormElementOption option = new FormElementOption();
            option.id = Guid.NewGuid().ToString();
            option.value = "A";
            option.label = "A";
            FormElement complianceElement = FormElement.CreateComplianceElement(
                "Compliance_test_element",
                "Compliance_test_element",
                new List<FormElementOption>() { option }
            );

            newForm.elements = new List<FormElement>() { textElement, summaryElement, complianceElement };

            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Form savedForm = await formsClient.Create(newForm);
            Assert.NotNull(savedForm);
            Form retrievedForm = await formsClient.Get(savedForm.id, true);
            Assert.NotNull(retrievedForm);
            Assert.Equal(slug, retrievedForm.slug);
            Assert.Equal(tags, retrievedForm.tags);
            Assert.Equal(newForm.postSubmissionReceipt.html, retrievedForm.postSubmissionReceipt.html);
            // Need to convert these to UTC time as that is what comes from api, and these dates are in local time
            Assert.Equal(startDate.ToUniversalTime(), retrievedForm.publishStartDate);
            Assert.Equal(endDate.ToUniversalTime(), retrievedForm.publishEndDate);
            Assert.Equal(newForm.unpublishedUserMessage, retrievedForm.unpublishedUserMessage);
            String updatedDescription = "Updated via unit test";
            retrievedForm.description = updatedDescription;
            Form updatedForm = await formsClient.Update(retrievedForm);
            Assert.Equal(updatedDescription, updatedForm.description);
            System.Threading.Thread.Sleep(5000); // give the API time to finish upserting s3 resources before deleting the form
            await formsClient.Delete(updatedForm.id);

            var oneBlinkAPIException = await Assert.ThrowsAsync<OneBlink.SDK.OneBlinkAPIException>(() => formsClient.Get(updatedForm.id, true));
            Assert.Equal(HttpStatusCode.NotFound, oneBlinkAPIException.StatusCode);
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
            System.Threading.Thread.Sleep(5000); // give the API time to finish upserting s3 resources before deleting the form

            await formsClient.Delete(updatedForm.id);
        }

        [Fact]
        public async void can_generate_form_url()
        {
            FormUrlOptions preFill = new FormUrlOptions(
                formId: 475
            );
            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormUrlResult result = await formsClient.GenerateFormUrl(
                new FormUrlOptions(
                    formId: 475,
                    username: "zac@oneblink.io",
                    preFillData: preFill,
                    externalId: "myExternalId"
                )
            );
            Assert.Contains("?access_key=", result.formUrl);
            Assert.Contains("&externalId=myExternalId", result.formUrl);
            Assert.Contains("&preFillFormDataId=", result.formUrl);
            Assert.NotNull(result.expiry);

        }

        [Fact]
        public async void can_generate_submission_url()
        {
            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            SubmissionDataUrl submissionDataUrl = await formsClient.GenerateSubmissionDataUrl(formId, submissionId, 1000);
            Assert.NotNull(submissionDataUrl);
            Assert.NotNull(submissionDataUrl.url);
        }

        [Fact]
        public async void can_crud_form_with_goodtogo_nested_mapping()
        {
            // Create a simple form that will be embedded
            Form embeddedForm = new Form(
                "Embedded Test Form",
                "A simple form for testing nested mapping",
                organisationId,
                formsAppEnvironmentId
            );

            // Add a text element to the embedded form
            FormElement embeddedTextElement = FormElement.CreateTextElement(
                "embedded_text",
                "Embedded Text Field"
            );

            embeddedForm.elements = new List<FormElement> { embeddedTextElement };

            FormsClient formsClient = new FormsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);

            // Create the embedded form first
            Form savedEmbeddedForm = await formsClient.Create(embeddedForm);
            Assert.NotNull(savedEmbeddedForm);

            // Create the main form with a form element that references the embedded form
            Form mainForm = new Form(
                "GoodToGo Nested Mapping Test",
                "Testing GoodToGo submission events with nested mapping",
                organisationId,
                formsAppEnvironmentId
            );

            // Create a text element for the main form
            FormElement mainTextElement = FormElement.CreateTextElement(
                "main_text",
                "Main Text Field"
            );

            // Create a form element that contains the embedded form
            FormElement formElement = new FormElement
            {
                id = Guid.NewGuid(),
                name = "embedded_form_element",
                label = "Embedded Form",
                type = "form",
                formId = savedEmbeddedForm.id,
                required = false
            };

            mainForm.elements = new List<FormElement> { mainTextElement, formElement };

            // Create GoodToGo submission event with nested mapping
            List<FormSubmissionEventConfigurationMapping> goodToGoMapping = new List<FormSubmissionEventConfigurationMapping>
            {
                new FormSubmissionEventConfigurationMapping
                {
                    type = "FORM_ELEMENT",
                    formElementId = mainTextElement.id,
                    goodToGoCustomFieldName = "main_field"
                },
                new FormSubmissionEventConfigurationMapping
                {
                    type = "FORM_FORM_ELEMENT",
                    formElementId = formElement.id,
                    goodToGoCustomFieldName = "embedded_form_data",
                    mapping = new FormSubmissionEventConfigurationMapping
                    {
                        type = "FORM_ELEMENT",
                        formElementId = embeddedTextElement.id,
                        goodToGoCustomFieldName = "nested_text_field"
                    }
                },
                new FormSubmissionEventConfigurationMapping
                {
                    type = "VALUE",
                    value = "Nested Mapping Test",
                    goodToGoCustomFieldName = "test_type"
                }
            };

            FormSubmissionEvent goodToGoEvent = FormSubmissionEvent.CreateGoodToGoSubmissionEvent(
                elementId: mainTextElement.id,
                integrationKeyId: Guid.NewGuid(),
                mapping: goodToGoMapping,
                label: "Update GoodToGo Asset with Nested Mapping"
            );

            mainForm.submissionEvents = new List<FormSubmissionEvent> { goodToGoEvent };

            // Create the main form
            Form savedMainForm = await formsClient.Create(mainForm);
            Assert.NotNull(savedMainForm);

            // Retrieve and verify the form
            Form retrievedForm = await formsClient.Get(savedMainForm.id, true);
            Assert.NotNull(retrievedForm);
            Assert.Equal("GoodToGo Nested Mapping Test", retrievedForm.name);

            // Verify GoodToGo submission event was saved correctly
            Assert.NotNull(retrievedForm.submissionEvents);
            Assert.Single(retrievedForm.submissionEvents);
            FormSubmissionEvent retrievedGoodToGoEvent = retrievedForm.submissionEvents[0];
            Assert.Equal("GOOD_TO_GO_UPDATE_ASSET", retrievedGoodToGoEvent.type);
            Assert.Equal("Update GoodToGo Asset with Nested Mapping", retrievedGoodToGoEvent.label);
            Assert.NotNull(retrievedGoodToGoEvent.configuration);
            Assert.Equal(mainTextElement.id, retrievedGoodToGoEvent.configuration.elementId);
            Assert.NotNull(retrievedGoodToGoEvent.configuration.mapping);
            Assert.Equal(3, retrievedGoodToGoEvent.configuration.mapping.Count);

            // Verify the nested mapping was preserved
            FormSubmissionEventConfigurationMapping nestedMapping = retrievedGoodToGoEvent.configuration.mapping[1];
            Assert.Equal("FORM_FORM_ELEMENT", nestedMapping.type);
            Assert.Equal("embedded_form_data", nestedMapping.goodToGoCustomFieldName);
            Assert.Equal(formElement.id, nestedMapping.formElementId);
            Assert.NotNull(nestedMapping.mapping);
            Assert.Equal("FORM_ELEMENT", nestedMapping.mapping.type);
            Assert.Equal(embeddedTextElement.id, nestedMapping.mapping.formElementId);
            Assert.Equal("nested_text_field", nestedMapping.mapping.goodToGoCustomFieldName);

            // Clean up - delete both forms
            await formsClient.Delete(savedMainForm.id);
            await formsClient.Delete(savedEmbeddedForm.id);

            // Verify forms were deleted
            OneBlinkAPIException mainFormException = await Assert.ThrowsAsync<OneBlinkAPIException>(() => formsClient.Get(savedMainForm.id, true));
            Assert.Equal(HttpStatusCode.NotFound, mainFormException.StatusCode);

            OneBlinkAPIException embeddedFormException = await Assert.ThrowsAsync<OneBlinkAPIException>(() => formsClient.Get(savedEmbeddedForm.id, true));
            Assert.Equal(HttpStatusCode.NotFound, embeddedFormException.StatusCode);
        }
    }
}