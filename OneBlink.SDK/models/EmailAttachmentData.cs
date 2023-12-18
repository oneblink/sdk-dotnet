namespace OneBlink.SDK.Model
{
    public class EmailAttachmentData
    {
        public S3Details s3
        {
            get; set;
        }
        public string contentType
        {
            get; set;
        }
        public string filename
        {
            get; set;
        }
    }
}