using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormCustomPDF
    {
        public string id
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
        public S3Details s3
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationMapping> mapping
        {
            get; set;
        }
    }
}
