using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalStepNode : FormApprovalFlowStepBase
    {
        public bool? isConditional
        {
            get; set;
        }
        public bool? requiresAllConditionalPredicates
        {
            get; set;
        }
        public List<ConditionallyShowPredicate> conditionalPredicates
        {
            get; set;
        }
    }

    public class FormApprovalStep : FormApprovalStepNode
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