namespace OneBlink.SDK.Model
{
    public class PreFillMetaCredentials
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

    public class PreFillMetaS3
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

    public class PreFillMeta
    {
        public PreFillMetaCredentials credentials
        {
            get; set;
        }
        public PreFillMetaS3 s3
        {
            get; set;
        }
        public string preFillFormDataId
        {
            get; set;
        }
    }
}