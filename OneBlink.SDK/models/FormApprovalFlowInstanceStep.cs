using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalFlowInstanceStepNode : FormApprovalFlowStepBase
    {
        public bool isSkipped
        {
            get; set;
        }
    }

    public class FormApprovalFlowInstanceStep : FormApprovalFlowInstanceStepNode
    {
        public string type
        {
            get; set;
        }

        public long? clarificationRequestEmailTemplateId
        {
            get; set;
        }

        public List<FormApprovalStepNode> nodes
        {
            get; set;
        }
    }
}