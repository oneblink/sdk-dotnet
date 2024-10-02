using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormEnableSubmission
    {
        public bool requiresAllConditionalPredicates
        {
            get; set;
        }
        public List<ConditionallyShowPredicate> conditionalPredicates
        {
            get; set;
        }
    }

}