using System;

namespace OneBlink.SDK.Model
{
    public class AttachmentData : S3UploadResponse
    {
        public string id
        {
            get; set;
        }
        public string contentType
        {
            get; set;
        }
        public string fileName
        {
            get; set;
        }
        public bool isPrivate
        {
            get; set;
        }
        [Obsolete("Use tenant origin with the `path` property to construct an absolute URL")]
        public string url
        {
            get; set;
        }
        public string path
        {
            get; set;
        }
        public string uploadedAt
        {
            get; set;
        }
    }
}
