using System;

namespace OneBlink.SDK.Model
{
    public class FormAttachmentMeta
    {
        public string AcceptRanges
        {
            get; set;
        }
        public DateTime LastModified
        {
            get; set;
        }
        public long ContentLength
        {
            get; set;
        }
        public string ETag
        {
            get; set;
        }
        public string VersionId
        {
            get; set;
        }
        public string CacheControl
        {
            get; set;
        }
        public string ContentDisposition
        {
            get; set;
        }
        public string ContentType
        {
            get; set;
        }
        public DateTime Expires
        {
            get; set;
        }
        public string ServerSideEncryption
        {
            get; set;
        }
    }
}