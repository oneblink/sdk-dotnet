using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalConfiguration
    {
        public Guid defaultNotificationEmailElementId
        {
            get; set;
        }
        public List<FormApprovalCannedResponse> approveCannedResponses
        {
            get; set;
        }
        public List<FormApprovalCannedResponse> clarificationRequestCannedResponses
        {
            get; set;
        }
        public List<FormApprovalCannedResponse> denyCannedResponses
        {
            get; set;
        }
        public FormApprovalConfigurationAutoDenyAfterClarificationRequest autoDenyAfterClarificationRequest
        {
            get; set;
        }
    }
}