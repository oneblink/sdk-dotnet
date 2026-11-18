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
        public void CanDeserializeFormElementAdditions()
        {
            string json = @"{
                ""id"": ""element-id"",
                ""type"": ""location"",
                ""requiresAllConditionallyShowOptionsPredicates"": true,
                ""autocompleteAttributes"": [""street-address""],
                ""includeTimestampWatermark"": true,
                ""hideImagePreview"": true,
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

            Assert.True(element.requiresAllConditionallyShowOptionsPredicates);
            Assert.Single(element.autocompleteAttributes);
            Assert.True(element.includeTimestampWatermark);
            Assert.True(element.hideImagePreview);
            Assert.Equal("MULTIPLE_ADD_BUTTONS", element.layout);
            Assert.Equal("address-element-id", element.reverseGeocoding.formattedAddressElementId);
            Assert.Equal("GEOSCAPE", element.reverseGeocoding.integrationType);
            Assert.Single(element.options[0].options);
            Assert.Equal("child-option", element.options[0].options[0].id);
        }

        [Fact]
        public void CanDeserializeEditableFormElementIds()
        {
            string json = @"{
                ""label"": ""Step 1"",
                ""group"": ""approvers"",
                ""editableFormElementIds"": [""element-id""],
                ""type"": ""CONCURRENT"",
                ""nodes"": [{
                    ""label"": ""Node 1"",
                    ""group"": ""approvers"",
                    ""editableFormElementIds"": [""element-id""]
                }]
            }";

            var step = JsonConvert.DeserializeObject<FormApprovalStep>(json);

            Assert.Single(step.editableFormElementIds);
            Assert.Equal("element-id", step.editableFormElementIds[0]);
            Assert.Single(step.nodes);
            Assert.Equal("element-id", step.nodes[0].editableFormElementIds[0]);
        }

        [Fact]
        public void CanDeserializeApprovalStepPaymentEvent()
        {
            string json = @"{
                ""type"": ""PAYMENT"",
                ""label"": ""Pay"",
                ""group"": ""payers"",
                ""paymentEvent"": {
                    ""type"": ""BPOINT"",
                    ""configuration"": {
                        ""amountType"": ""NUMBER"",
                        ""paymentAmount"": 12.5,
                        ""environmentId"": ""11111111-1111-1111-1111-111111111111"",
                        ""crn2"": ""crn-2"",
                        ""crn3"": ""crn-3""
                    }
                }
            }";

            var step = JsonConvert.DeserializeObject<FormApprovalStep>(json);
            var instanceStep = JsonConvert.DeserializeObject<FormApprovalFlowInstanceStep>(json);

            Assert.Equal("BPOINT", step.paymentEvent.type);
            Assert.Equal("NUMBER", step.paymentEvent.configuration.amountType);
            Assert.Equal(12.5, step.paymentEvent.configuration.paymentAmount);
            Assert.Equal(Guid.Parse("11111111-1111-1111-1111-111111111111"), step.paymentEvent.configuration.environmentId);
            Assert.Equal("crn-2", step.paymentEvent.configuration.crn2);
            Assert.Equal("crn-3", step.paymentEvent.configuration.crn3);
            Assert.Null(step.paymentEvent.configuration.elementId);
            Assert.Null(step.paymentEvent.configuration.paymentCalculation);
            Assert.Null(step.paymentEvent.configuration.gatewayId);

            Assert.Equal("BPOINT", instanceStep.paymentEvent.type);
            Assert.Equal("crn-2", instanceStep.paymentEvent.configuration.crn2);

            string cpPayJson = @"{
                ""type"": ""CP_PAY"",
                ""configuration"": {
                    ""amountType"": ""FORM_ELEMENT"",
                    ""elementId"": ""amount-element"",
                    ""gatewayId"": ""22222222-2222-2222-2222-222222222222""
                }
            }";
            var cpPay = JsonConvert.DeserializeObject<FormApprovalStepPaymentEvent>(cpPayJson);
            Assert.Equal("CP_PAY", cpPay.type);
            Assert.Equal("FORM_ELEMENT", cpPay.configuration.amountType);
            Assert.Equal("amount-element", cpPay.configuration.elementId);
            Assert.Equal(Guid.Parse("22222222-2222-2222-2222-222222222222"), cpPay.configuration.gatewayId);

            string westpacJson = @"{
                ""type"": ""WESTPAC_QUICK_STREAM"",
                ""configuration"": {
                    ""amountType"": ""EXPRESSION"",
                    ""paymentCalculation"": ""1 + 2"",
                    ""environmentId"": ""33333333-3333-3333-3333-333333333333"",
                    ""customerReferenceNumber"": ""ref""
                }
            }";
            var westpac = JsonConvert.DeserializeObject<FormApprovalStepPaymentEvent>(westpacJson);
            Assert.Equal("EXPRESSION", westpac.configuration.amountType);
            Assert.Equal("1 + 2", westpac.configuration.paymentCalculation);
            Assert.Equal("ref", westpac.configuration.customerReferenceNumber);

            string govPayJson = @"{
                ""type"": ""NSW_GOV_PAY"",
                ""configuration"": {
                    ""amountType"": ""NUMBER"",
                    ""paymentAmount"": 10,
                    ""primaryAgencyId"": ""44444444-4444-4444-4444-444444444444"",
                    ""productDescription"": ""Permit"",
                    ""customerReference"": ""customer"",
                    ""subAgencyCode"": ""SUB""
                }
            }";
            var govPay = JsonConvert.DeserializeObject<FormApprovalStepPaymentEvent>(govPayJson);
            Assert.Equal("NSW_GOV_PAY", govPay.type);
            Assert.Equal(Guid.Parse("44444444-4444-4444-4444-444444444444"), govPay.configuration.primaryAgencyId);
            Assert.Equal("Permit", govPay.configuration.productDescription);
            Assert.Equal("customer", govPay.configuration.customerReference);
            Assert.Equal("SUB", govPay.configuration.subAgencyCode);
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
                        ""context"": {
                            ""type"": ""FORM_SUBMISSION_APPROVAL"",
                            ""formSubmissionApprovalId"": ""approval-id"",
                            ""approvalFormSubmissionId"": ""approval-form-submission-id""
                        },
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
            Assert.Equal("approval-form-submission-id", response.formSubmissionMeta.lastEdit.context.approvalFormSubmissionId);
            Assert.Single(response.formSubmissionMetaEdits);
            Assert.Equal(456, response.formSubmissionSchedulingBooking.nylasSchedulingPageId);
            Assert.Equal("completed-task-id", response.taskCompletion.completedTask.id);
            Assert.Equal("task-id", response.taskCompletion.task.taskId);
        }

        [Fact]
        public void CanDeserializeNSWGovPayFormSubmissionPayment()
        {
            string json = @"{
                ""type"": ""NSW_GOV_PAY"",
                ""submissionId"": ""7145544d-853a-47e8-873c-1e849698e414"",
                ""formId"": 123,
                ""status"": ""SUCCEEDED"",
                ""paymentTransaction"": {
                    ""redirectUrl"": ""https://example.test/return"",
                    ""integrationPrimaryAgencyId"": ""44444444-4444-4444-4444-444444444444"",
                    ""nswGovPayPaymentReference"": ""pay-ref"",
                    ""agencyCompletionPayment"": {
                        ""paymentMethod"": ""CARD"",
                        ""paymentReference"": ""pay-ref"",
                        ""paymentCompletionReference"": ""receipt-1"",
                        ""bankReference"": ""bank-1"",
                        ""amount"": 42.5,
                        ""surcharge"": 1.25,
                        ""surchargeGst"": 0.11,
                        ""agencyTransactionId"": ""55555555-5555-5555-5555-555555555555"",
                        ""card"": {
                            ""cardType"": ""VISA"",
                            ""last4Digits"": ""4242"",
                            ""cardPresent"": false
                        }
                    }
                }
            }";

            var payment = JsonConvert.DeserializeObject<FormSubmissionPayment>(json);

            Assert.Equal("NSW_GOV_PAY", payment.type);
            Assert.Equal("pay-ref", payment.paymentTransaction.nswGovPayPaymentReference);
            Assert.Equal("44444444-4444-4444-4444-444444444444", payment.paymentTransaction.integrationPrimaryAgencyId);
            Assert.Equal(42.5, payment.paymentTransaction.agencyCompletionPayment.amount);
            Assert.Equal(1.25, payment.paymentTransaction.agencyCompletionPayment.surcharge);
            Assert.Equal(0.11, payment.paymentTransaction.agencyCompletionPayment.surchargeGst);
            Assert.Equal("receipt-1", payment.paymentTransaction.agencyCompletionPayment.paymentCompletionReference);
            Assert.Equal("CARD", payment.paymentTransaction.agencyCompletionPayment.paymentMethod);
            Assert.Equal("4242", payment.paymentTransaction.agencyCompletionPayment.card.last4Digits);
            Assert.False(payment.paymentTransaction.agencyCompletionPayment.card.cardPresent);
            Assert.Null(payment.paymentTransaction.agencyCompletionPayment.bPay);

            string bpayJson = @"{
                ""type"": ""NSW_GOV_PAY"",
                ""submissionId"": ""7145544d-853a-47e8-873c-1e849698e414"",
                ""formId"": 123,
                ""status"": ""SUCCEEDED"",
                ""paymentTransaction"": {
                    ""nswGovPayPaymentReference"": ""bpay-ref"",
                    ""agencyCompletionPayment"": {
                        ""paymentMethod"": ""BPAY"",
                        ""paymentReference"": ""bpay-ref"",
                        ""paymentCompletionReference"": ""receipt-2"",
                        ""bankReference"": ""bank-2"",
                        ""amount"": 10,
                        ""surcharge"": 0,
                        ""surchargeGst"": 0,
                        ""agencyTransactionId"": ""66666666-6666-6666-6666-666666666666"",
                        ""bPay"": {
                            ""billerCode"": ""123456"",
                            ""crn"": ""crn-1"",
                            ""processingDate"": ""2026-11-17""
                        }
                    }
                }
            }";

            var bpayPayment = JsonConvert.DeserializeObject<FormSubmissionPayment>(bpayJson);

            Assert.Equal("BPAY", bpayPayment.paymentTransaction.agencyCompletionPayment.paymentMethod);
            Assert.Equal("123456", bpayPayment.paymentTransaction.agencyCompletionPayment.bPay.billerCode);
            Assert.Equal("crn-1", bpayPayment.paymentTransaction.agencyCompletionPayment.bPay.crn);
            Assert.Equal("2026-11-17", bpayPayment.paymentTransaction.agencyCompletionPayment.bPay.processingDate);
            Assert.Null(bpayPayment.paymentTransaction.agencyCompletionPayment.card);
        }

        [Fact]
        public void CanDeserializeCPPayV2FormSubmissionPayment()
        {
            string json = @"{
                ""type"": ""CP_PAY"",
                ""submissionId"": ""472d1cd3-d8f0-4f93-a08c-169e3679eb54"",
                ""formSubmissionApprovalId"": ""3cc5831f-1c04-46f9-a655-ace2d5cf511e"",
                ""formId"": 229,
                ""status"": ""SUCCEEDED"",
                ""paymentTransaction"": {
                    ""cpPayVersion"": ""v2"",
                    ""integrationGatewayId"": ""gateway-1"",
                    ""isSuccess"": true,
                    ""timeGenerated"": ""2026-11-13T04:37:19.98Z"",
                    ""result"": {
                        ""type"": ""HostedFormSale"",
                        ""id"": ""11111111-1111-1111-1111-111111111111"",
                        ""token"": ""txn-token"",
                        ""state"": ""Captured"",
                        ""externalReferenceId"": ""472d1cd3-d8f0-4f93-a08c-169e3679eb54"",
                        ""merchantCode"": ""MERCHANT"",
                        ""paymentMethodType"": ""Visa"",
                        ""lastFour"": ""4242"",
                        ""expMonth"": 11,
                        ""expYear"": 2028,
                        ""paymentType"": ""CreditDebitCard"",
                        ""amount"": 25.5,
                        ""responseType"": ""Success"",
                        ""errorCode"": ""NoError"",
                        ""customerReceipt"": ""customer receipt"",
                        ""merchantReceipt"": ""merchant receipt"",
                        ""isSuccessSavedPaymentMethod"": false,
                        ""createdOnUtc"": ""2026-11-13T04:36:34.688Z"",
                        ""lastModifiedOnUtc"": ""2026-11-13T04:37:19.98Z""
                    },
                    ""error"": null,
                    ""links"": {
                        ""details"": { ""href"": ""https://example.test/details"", ""type"": ""GET"" },
                        ""capture"": { ""href"": ""https://example.test/capture"", ""type"": ""PATCH"" },
                        ""void"": { ""href"": ""https://example.test/void"", ""type"": ""PATCH"" },
                        ""refund"": { ""href"": ""https://example.test/refund"", ""type"": ""POST"" }
                    }
                }
            }";

            var payment = JsonConvert.DeserializeObject<FormSubmissionPayment>(json);

            Assert.Equal("CP_PAY", payment.type);
            Assert.Equal("SUCCEEDED", payment.status);
            Assert.Equal("v2", payment.paymentTransaction.cpPayVersion);
            Assert.Equal("gateway-1", payment.paymentTransaction.integrationGatewayId);
            Assert.True(payment.paymentTransaction.isSuccess);
            Assert.Equal(2026, payment.paymentTransaction.timeGenerated.Value.Year);
            Assert.Null(payment.paymentTransaction.transactionId);
            Assert.Null(payment.paymentTransaction.amount);

            Assert.Equal("HostedFormSale", payment.paymentTransaction.result.type);
            Assert.Equal("11111111-1111-1111-1111-111111111111", payment.paymentTransaction.result.id);
            Assert.Equal("txn-token", payment.paymentTransaction.result.token);
            Assert.Equal("Captured", payment.paymentTransaction.result.state);
            Assert.Equal("472d1cd3-d8f0-4f93-a08c-169e3679eb54", payment.paymentTransaction.result.externalReferenceId);
            Assert.Equal("MERCHANT", payment.paymentTransaction.result.merchantCode);
            Assert.Equal("Visa", payment.paymentTransaction.result.paymentMethodType);
            Assert.Equal("4242", payment.paymentTransaction.result.lastFour);
            Assert.Equal(11, payment.paymentTransaction.result.expMonth);
            Assert.Equal(2028, payment.paymentTransaction.result.expYear);
            Assert.Equal("CreditDebitCard", payment.paymentTransaction.result.paymentType);
            Assert.Equal(25.5, payment.paymentTransaction.result.amount);
            Assert.Equal("Success", payment.paymentTransaction.result.responseType);
            Assert.Equal("NoError", payment.paymentTransaction.result.errorCode);
            Assert.Equal("customer receipt", payment.paymentTransaction.result.customerReceipt);
            Assert.Equal("merchant receipt", payment.paymentTransaction.result.merchantReceipt);
            Assert.False(payment.paymentTransaction.result.isSuccessSavedPaymentMethod);
            Assert.Equal(2026, payment.paymentTransaction.result.createdOnUtc.Value.Year);
            Assert.Equal(11, payment.paymentTransaction.result.lastModifiedOnUtc.Value.Month);
            Assert.Null(payment.paymentTransaction.error);

            Assert.Equal("https://example.test/details", payment.paymentTransaction.links.details.href);
            Assert.Equal("GET", payment.paymentTransaction.links.details.type);
            Assert.Equal("https://example.test/capture", payment.paymentTransaction.links.capture.href);
            Assert.Equal("PATCH", payment.paymentTransaction.links.capture.type);
            Assert.Equal("https://example.test/void", payment.paymentTransaction.links.@void.href);
            Assert.Equal("PATCH", payment.paymentTransaction.links.@void.type);
            Assert.Equal("https://example.test/refund", payment.paymentTransaction.links.refund.href);
            Assert.Equal("POST", payment.paymentTransaction.links.refund.type);

            string nullExpiryJson = @"{
                ""type"": ""CP_PAY"",
                ""submissionId"": ""472d1cd3-d8f0-4f93-a08c-169e3679eb54"",
                ""formId"": 229,
                ""status"": ""SUCCEEDED"",
                ""paymentTransaction"": {
                    ""cpPayVersion"": ""v2"",
                    ""result"": {
                        ""id"": ""22222222-2222-2222-2222-222222222222"",
                        ""amount"": 10,
                        ""expMonth"": null,
                        ""expYear"": null,
                        ""lastFour"": ""4242""
                    }
                }
            }";

            var nullExpiryPayment = JsonConvert.DeserializeObject<FormSubmissionPayment>(nullExpiryJson);

            Assert.Equal("22222222-2222-2222-2222-222222222222", nullExpiryPayment.paymentTransaction.result.id);
            Assert.Equal(10, nullExpiryPayment.paymentTransaction.result.amount);
            Assert.Equal("4242", nullExpiryPayment.paymentTransaction.result.lastFour);
            Assert.Null(nullExpiryPayment.paymentTransaction.result.expMonth);
            Assert.Null(nullExpiryPayment.paymentTransaction.result.expYear);
            Assert.Null(nullExpiryPayment.paymentTransaction.isSuccess);
        }

        [Fact]
        public void CanDeserializeCPPayV1FormSubmissionPayment()
        {
            string json = @"{
                ""type"": ""CP_PAY"",
                ""submissionId"": ""472d1cd3-d8f0-4f93-a08c-169e3679eb54"",
                ""formId"": 229,
                ""status"": ""SUCCEEDED"",
                ""paymentTransaction"": {
                    ""transactionId"": ""v1-transaction"",
                    ""transactionToken"": ""v1-token"",
                    ""merchantCode"": ""MERCHANT"",
                    ""orderNumber"": ""ORDER-1"",
                    ""amount"": 10.5,
                    ""lastFour"": ""1111"",
                    ""isSuccessSavedPaymentMethod"": true
                }
            }";

            var payment = JsonConvert.DeserializeObject<FormSubmissionPayment>(json);

            Assert.Equal("v1-transaction", payment.paymentTransaction.transactionId);
            Assert.Equal("v1-token", payment.paymentTransaction.transactionToken);
            Assert.Equal("MERCHANT", payment.paymentTransaction.merchantCode);
            Assert.Equal("ORDER-1", payment.paymentTransaction.orderNumber);
            Assert.Equal(10.5, payment.paymentTransaction.amount);
            Assert.Equal("1111", payment.paymentTransaction.lastFour);
            Assert.True(payment.paymentTransaction.isSuccessSavedPaymentMethod);
            Assert.Null(payment.paymentTransaction.Amount);
            Assert.Null(payment.paymentTransaction.result);
            Assert.Null(payment.paymentTransaction.cpPayVersion);
        }
    }
}