using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalStep : FormApprovalFlowStepBase
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
}