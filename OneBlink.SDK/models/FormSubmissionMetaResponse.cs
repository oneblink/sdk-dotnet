using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionMetadataResponse
    {
        [JsonProperty]
        public FormSubmissionMetadata formSubmissionMeta
        {
            get; internal set;
        }

        [JsonProperty]
        public FormApprovalFlowInstance formApprovalFlowInstance
        {
            get; internal set;
        }

        [JsonProperty]
        public IEnumerable<FormSubmissionApproval> formSubmissionApprovals
        {
            get; internal set;
        }
    }
}
