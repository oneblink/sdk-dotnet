namespace OneBlink.SDK.Model
{
    public class EmailAttachmentData : S3UploadResponse
    {
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