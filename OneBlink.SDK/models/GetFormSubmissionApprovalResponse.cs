using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetFormSubmissionApprovalResponse
    {
        public FormSubmissionMetadata formSubmissionMeta
        {
            get; set;
        }
        public FormSubmissionApproval formSubmissionApproval
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
        public List<FormSubmissionApprovalHistory> history
        {
            get; set;
        }
    }
}