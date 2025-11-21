using System.Collections.Generic;
using Newtonsoft.Json;
using OneBlink.SDK.JsonConverters;

namespace OneBlink.SDK.Model
{
    public class FormPostSubmissionReceipt
    {
        public string html
        {
            get; set;
        }
        [JsonConverter(typeof(FormPostSubmissionReceiptPdfConfigurationConverter))]
        public List<FormPostSubmissionReceiptPdfConfiguration> allowPDFDownload
        {
            get; set;
        }
        public FormPersonalisation allowAttachmentsDownload
        {
            get; set;
        }
    }
}