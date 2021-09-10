using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionApprovalHistory
    {
        public FormSubmissionMetadata formSubmissionMeta
        {
            get; set;
        }
        public FormApprovalFlowInstance formApprovalFlowInstance
        {
            get; set;
        }
        public List<FormSubmissionApproval> formSubmissionApprovals
        {
            get; set;
        }
    }
}