using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneBlink.SDK.Model;
using System;

namespace OneBlink.SDK.JsonConverters
{
    public class FormPostSubmissionReceiptPdfConfigurationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<FormPostSubmissionReceiptPdfConfiguration>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<FormPostSubmissionReceiptPdfConfiguration>>();
            }
            else if (token.Type == JTokenType.Object)
            {
                // It's the legacy single PDFConfiguration object
                PDFConfiguration pdfConfig = token.ToObject<PDFConfiguration>();
                return new List<FormPostSubmissionReceiptPdfConfiguration>
                {
                    new FormPostSubmissionReceiptPdfConfiguration
                    {
                        id = Guid.NewGuid(),
                        configuration = pdfConfig
                    }
                };
            }
            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
