using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetFormApprovalFlowInstanceResponse
    {
        public FormSubmissionMetadata formSubmissionMeta
        {
            get; set;
        }
        public List<FormSubmissionApproval> formSubmissionApprovals
        {
            get; set;
        }
        public FormApprovalFlowInstance formApprovalFlowInstance
        {
            get; set;
        }
        public Form form
        {
            get; set;
        }
    }
}