namespace OneBlink.SDK.Model
{
    public class FormSubmissionRetrievalConfigurationCredentials
    {
        public string AccessKeyId
        {
            get; set;
        }
        public string SecretAccessKey
        {
            get; set;
        }
        public string SessionToken
        {
            get; set;
        }
    }

    public class FormSubmissionRetrievalConfigurationS3
    {
        public string bucket
        {
            get; set;
        }
        public string key
        {
            get; set;
        }
        public string region
        {
            get; set;
        }
    }

    public class FormSubmissionRetrievalConfiguration
    {
        public FormSubmissionRetrievalConfigurationCredentials credentials
        {
            get; set;
        }
        public FormSubmissionRetrievalConfigurationS3 s3
        {
            get; set;
        }
    }
}