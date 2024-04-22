namespace OneBlink.SDK.Model
{
    public class S3Details
    {
        public string region
        {
            get; set;
        }
        public string bucket
        {
            get; set;
        }
        public string key
        {
            get; set;
        }
    }

    public class S3UploadResponse
    {
        public S3Details s3
        {
            get; set;
        }
    }
}
