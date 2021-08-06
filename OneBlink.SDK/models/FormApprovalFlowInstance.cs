using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalFlowInstance
    {
        public long formId
        {
            get; set;
        }
        public string submissionId
        {
            get; set;
        }
        public long approvalsFormsAppId
        {
            get; set;
        }
        public string previousFormSubmissionApprovalId
        {
            get; set;
        }
        public List<FormApprovalFlowInstanceStep> steps
        {
            get; set;
        }
        public bool isLatest
        {
            get; set;
        }
        public string status
        {
            get; set;
        }
        public long? id
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
    }
}