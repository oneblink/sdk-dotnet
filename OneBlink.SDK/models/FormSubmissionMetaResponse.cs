using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionMetadataResponse
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
        public List<FormSubmissionPayment> formSubmissionPayments
        {
            get; set;
        }
        public List<FormSubmissionWorkflowEvent> formSubmissionWorkflowEvents
        {
            get; set;
        }
        public NylasBooking formSubmissionNylasBooking
        {
            get; set;
        }
    }
}
