namespace OneBlink.SDK.Model
{
    public class AssetUploadCredentialsResponse
    {
        public UploadCredentials credentials { get; set; }
        public S3Details s3 { get; set; }
    }
}
