using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
    public class JsonConverterTests
    {
        [Fact]
        public void CanDeserializeLegacySingleObject()
        {
            string json = @"{
                ""html"": ""<div>Test</div>"",
                ""allowPDFDownload"": {
                    ""pdfFileName"": ""MyLegacyPdf.pdf"",
                    ""includeSubmissionIdInPdf"": true
                }
            }";

            var receipt = JsonConvert.DeserializeObject<FormPostSubmissionReceipt>(json);

            Assert.NotNull(receipt);
            Assert.NotNull(receipt.allowPDFDownload);
            Assert.Single(receipt.allowPDFDownload);

            var config = receipt.allowPDFDownload[0];
            // ID should be auto-generated for legacy data
            Assert.NotNull(config.id);
            Assert.NotEqual(Guid.Empty, config.id);
            Assert.Equal("MyLegacyPdf.pdf", config.configuration.pdfFileName);
            Assert.True(config.configuration.includeSubmissionIdInPdf);
        }

        [Fact]
        public void CanDeserializeNewArrayFormat()
        {
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            string json = $@"{{
                ""html"": ""<div>Test</div>"",
                ""allowPDFDownload"": [
                    {{
                        ""id"": ""{id1}"",
                        ""configuration"": {{
                            ""pdfFileName"": ""MyNewPdf1.pdf"",
                            ""includeSubmissionIdInPdf"": false
                        }}
                    }},
                    {{
                        ""id"": ""{id2}"",
                        ""configuration"": {{
                            ""pdfFileName"": ""MyNewPdf2.pdf"",
                            ""includeSubmissionIdInPdf"": true
                        }}
                    }}
                ]
            }}";

            var receipt = JsonConvert.DeserializeObject<FormPostSubmissionReceipt>(json);

            Assert.NotNull(receipt);
            Assert.NotNull(receipt.allowPDFDownload);
            Assert.Equal(2, receipt.allowPDFDownload.Count);

            var config1 = receipt.allowPDFDownload[0];
            Assert.Equal(id1, config1.id);
            Assert.Equal("MyNewPdf1.pdf", config1.configuration.pdfFileName);
            Assert.False(config1.configuration.includeSubmissionIdInPdf);

            var config2 = receipt.allowPDFDownload[1];
            Assert.Equal(id2, config2.id);
            Assert.Equal("MyNewPdf2.pdf", config2.configuration.pdfFileName);
            Assert.True(config2.configuration.includeSubmissionIdInPdf);
        }

        [Fact]
        public void CanDeserializeNullFormat()
        {
            string json = @"{
                ""html"": ""<div>Test</div>""
            }";

            var receipt = JsonConvert.DeserializeObject<FormPostSubmissionReceipt>(json);

            Assert.NotNull(receipt);
            Assert.Null(receipt.allowPDFDownload);
        }

        [Fact]
        public void CanSerializeArrayFormat()
        {
            Guid id1 = Guid.NewGuid();
            var receipt = new FormPostSubmissionReceipt
            {
                html = "<div>Test</div>",
                allowPDFDownload = new List<FormPostSubmissionReceiptPdfConfiguration>
                {
                    new FormPostSubmissionReceiptPdfConfiguration
                    {
                        id = id1,
                        configuration = new PDFConfiguration
                        {
                            pdfFileName = "Serialized.pdf"
                        }
                    },
                    new FormPostSubmissionReceiptPdfConfiguration
                    {
                        // Simulate legacy style (no ID) inside the new list structure
                        // ID can be null if manually created, but usually should have one
                        id = null,
                        configuration = new PDFConfiguration
                        {
                            pdfFileName = "LegacyStyle.pdf"
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(receipt);

            Assert.Contains($"\"id\":\"{id1}\"", json);
            Assert.Contains("\"pdfFileName\":\"Serialized.pdf\"", json);
            Assert.Contains("\"pdfFileName\":\"LegacyStyle.pdf\"", json);

            // Verify it is an array
            Assert.Contains("\"allowPDFDownload\":[", json);
        }

        [Fact]
        public void CanDeserializeFormElementApproverEditability()
        {
            string json = @"{
                ""id"": ""element-id"",
                ""type"": ""location"",
                ""approverEditability"": {
                    ""type"": ""ALL_STEPS""
                },
                ""requiresAllConditionallyShowOptionsPredicates"": true,
                ""autocompleteAttributes"": [""street-address""],
                ""includeTimestampWatermark"": true,
                ""layout"": ""MULTIPLE_ADD_BUTTONS"",
                ""reverseGeocoding"": {
                    ""formattedAddressElementId"": ""address-element-id"",
                    ""integrationType"": ""GEOSCAPE""
                },
                ""options"": [{
                    ""id"": ""parent-option"",
                    ""value"": ""parent"",
                    ""label"": ""Parent"",
                    ""options"": [{
                        ""id"": ""child-option"",
                        ""value"": ""child"",
                        ""label"": ""Child""
                    }]
                }]
            }";

            var element = JsonConvert.DeserializeObject<FormElement>(json);

            Assert.NotNull(element.approverEditability);
            Assert.Equal("ALL_STEPS", element.approverEditability.type);
            Assert.True(element.requiresAllConditionallyShowOptionsPredicates);
            Assert.Single(element.autocompleteAttributes);
            Assert.True(element.includeTimestampWatermark);
            Assert.Equal("MULTIPLE_ADD_BUTTONS", element.layout);
            Assert.Equal("address-element-id", element.reverseGeocoding.formattedAddressElementId);
            Assert.Equal("GEOSCAPE", element.reverseGeocoding.integrationType);
            Assert.Single(element.options[0].options);
            Assert.Equal("child-option", element.options[0].options[0].id);
        }

        [Fact]
        public void CanDeserializeFormSubmissionMetadataResponseAdditions()
        {
            string json = @"{
                ""formSubmissionMeta"": {
                    ""submissionId"": ""submission-id"",
                    ""formId"": 123,
                    ""lastEdit"": {
                        ""id"": ""edit-id"",
                        ""submissionId"": ""submission-id"",
                        ""formId"": 123,
                        ""editedS3ObjectVersionId"": ""previous-version-id"",
                        ""s3ObjectVersionId"": ""edited-version-id""
                    }
                },
                ""formSubmissionMetaEdits"": [{
                    ""id"": ""edit-id"",
                    ""submissionId"": ""submission-id"",
                    ""formId"": 123,
                    ""editedS3ObjectVersionId"": ""previous-version-id"",
                    ""s3ObjectVersionId"": ""edited-version-id""
                }],
                ""formSubmissionSchedulingBooking"": {
                    ""submissionId"": ""submission-id"",
                    ""formId"": 123,
                    ""nylasSchedulingPageId"": 456
                },
                ""taskCompletion"": {
                    ""completedTask"": {
                        ""id"": ""completed-task-id"",
                        ""formsAppId"": 789,
                        ""taskVersionId"": 10,
                        ""submissionId"": ""submission-id"",
                        ""createdAt"": ""2026-08-28T00:00:00Z"",
                        ""savedAt"": ""2026-08-28T00:00:01Z""
                    },
                    ""task"": {
                        ""taskId"": ""task-id"",
                        ""versionId"": 10,
                        ""createdAt"": ""2026-08-27T00:00:00Z"",
                        ""organisationId"": ""organisation-id"",
                        ""formsAppEnvironmentId"": 11,
                        ""name"": ""Inspect site"",
                        ""actionIds"": [""action-id""]
                    }
                }
            }";

            var response = JsonConvert.DeserializeObject<FormSubmissionMetadataResponse>(json);

            Assert.Equal("edited-version-id", response.formSubmissionMeta.lastEdit.s3ObjectVersionId);
            Assert.Single(response.formSubmissionMetaEdits);
            Assert.Equal(456, response.formSubmissionSchedulingBooking.nylasSchedulingPageId);
            Assert.Equal("completed-task-id", response.taskCompletion.completedTask.id);
            Assert.Equal("task-id", response.taskCompletion.task.taskId);
        }
    }
}