using System;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionApprovalNote
    {
        public string id
        {
            get; set;
        }
        public DateTime? createdAt
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails createdBy
        {
            get; set;
        }
        public DateTime? updatedAt
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails lastUpdatedBy
        {
            get; set;
        }
        public string note
        {
            get; set;
        }
    }
}