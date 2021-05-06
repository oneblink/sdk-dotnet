namespace OneBlink.SDK.Model
{
    public class AttachmentData
    {
        public string id {get;set;}
        public string contentType {get;set;}
        public string fileName {get;set;}
        public bool isPrivate {get;set;}
        public string url {get;set;}
        public S3Details s3 { get; set; }
    }
}
