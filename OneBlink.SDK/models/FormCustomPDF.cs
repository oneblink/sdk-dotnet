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
        public FormSubmissionEventConfigurationMapping mapping
        {
            get; set;
        }
    }
}
