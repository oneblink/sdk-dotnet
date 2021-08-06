using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetFormSubmissionAdministrationApproval
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
        public List<GetFormSubmissionAdministrationApproval> history
        {
            get; set;
        }
    }
}