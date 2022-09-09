using System;

namespace OneBlink.SDK.Model
{
    public class FormStoreRecord<T>
    {
        public string _id
        {
            get; set;
        }
        public Guid submissionId
        {
            get; set;
        }
        public long formsAppId
        {
            get; set;
        }
        public FormSubmissionUser user
        {
            get; set;
        }
        public string externalId
        {
            get; set;
        }
        public FormSubmissionMetaKey key
        {
            get; set;
        }
        public Form definition
        {
            get; set;
        }
        public T submission
        {
            get; set;
        }
        public FormSubmissionDevice device
        {
            get; set;
        }
        public string ipAddress
        {
            get; set;
        }
    }
}