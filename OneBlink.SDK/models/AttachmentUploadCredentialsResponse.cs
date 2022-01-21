namespace OneBlink.SDK.Model
{
    public class AttachmentUploadCredentialsResponse : AssetUploadCredentialsResponse
    {
        public string attachmentDataId
        {
            get; set;
        }
        public string uploadedAt
        {
            get; set;
        }
    }
}