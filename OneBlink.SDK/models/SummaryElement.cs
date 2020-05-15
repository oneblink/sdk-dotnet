using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public static class SummaryElement
    {
        public static FormElement Create(
            Guid id,
            bool conditionallyShow,
            bool requiresAllConditonallyShowPredicate,
            List<FormElementConditionallyShowPredicate> conditionallyShowPredicates,
            string name,
            string label,
            List<Guid> elementIds
        )
        {
            FormElement summaryElement = new FormElement();
            summaryElement.type = "summary";
            summaryElement.id = id;
            summaryElement.conditionallyShow = conditionallyShow;
            summaryElement.requiresAllConditionallyShowPredicates = requiresAllConditonallyShowPredicate;
            summaryElement.conditionallyShowPredicates = conditionallyShowPredicates;
            summaryElement.name = name;
            summaryElement.label = label;
            summaryElement.elementIds = elementIds;

            return summaryElement;
        }
    }
}