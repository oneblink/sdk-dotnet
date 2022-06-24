
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionApproval
    {
        public string group
        {
            get; set;
        }
        public List<string> notificationEmailAddress
        {
            get; set;
        }
        public long formApprovalFlowInstanceId
        {
            get; set;
        }
        public string stepLabel
        {
            get; set;
        }
        public string status
        {
            get; set;
        }
        public string id
        {
            get; set;
        }
        public string notes
        {
            get; set;
        }
        public string internalNotes
        {
            get; set;
        }
        public string createdAt
        {
            get; set;
        }
        public string updatedAt
        {
            get; set;
        }
        public string updatedBy
        {
            get; set;
        }
        public string approvalFormSubmissionId
        {
            get; set;
        }
        public long? approvalFormId
        {
            get; set;
        }
        public List<FormSubmissionApprovalNote> additionalNotes
        {
            get; set;
        }
    }
}