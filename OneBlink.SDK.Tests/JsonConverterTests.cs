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
    }
}
