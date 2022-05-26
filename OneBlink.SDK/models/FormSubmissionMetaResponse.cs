using System;
using Newtonsoft.Json;
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

        public IEnumerable<FormSubmissionApproval> formSubmissionApprovals
        {
            get; set;
        }
        public FormSubmissionPayment formSubmissionPayment
        {
            get; set;
        }
    }
}
