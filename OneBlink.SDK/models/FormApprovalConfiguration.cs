using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalConfiguration
    {
        public Guid? defaultNotificationEmailElementId
        {
            get; set;
        }
        public bool? sendNotificationEmailOptionDefaultUnchecked
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
        public FormApprovalConfigurationPendingApprovalsReminder pendingApprovalsReminder
        {
            get; set;
        }
        public bool? disallowApprovingWhenAwaitingClarification
        {
            get; set;
        }
        public long? approvalCreatedEmailTemplateId
        {
            get; set;
        }
        public long? clarificationRequestEmailTemplateId
        {
            get; set;
        }
        public long? approvedEmailTemplateId
        {
            get; set;
        }
        public long? deniedEmailTemplateId
        {
            get; set;
        }
    }
}