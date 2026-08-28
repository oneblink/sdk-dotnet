#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionApprovalEditContext
    {
        public string type
        {
            get; set;
        }
        public string formSubmissionApprovalId
        {
            get; set;
        }
        public string notes
        {
            get; set;
        }
        public string cannedResponseKey
        {
            get; set;
        }
        public string internalNotes
        {
            get; set;
        }
        public List<string> notificationEmailAddress
        {
            get; set;
        }
    }

    public class FormSubmissionMetaEdit
    {
        public string id
        {
            get; set;
        }
        public string submissionId
        {
            get; set;
        }
        public long formId
        {
            get; set;
        }
        public FormSubmissionApprovalEditContext context
        {
            get; set;
        }
        public string editedS3ObjectVersionId
        {
            get; set;
        }
        public string s3ObjectVersionId
        {
            get; set;
        }
        public string dateTimeEdited
        {
            get; set;
        }
        public string createdAt
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails user
        {
            get; set;
        }
        public string ipAddress
        {
            get; set;
        }
        public FormSubmissionMetaKey key
        {
            get; set;
        }
        public S3Details s3
        {
            get; set;
        }
    }
}