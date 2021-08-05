using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalFlowInstanceStep
    {
        public string group
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
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
        public bool isSkipped
        {
            get; set;
        }
    }
}