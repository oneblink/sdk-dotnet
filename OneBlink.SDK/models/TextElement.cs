using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public static class TextElement
    {
        public static FormElement Create(
            Guid id,
            bool conditionallyShow,
            bool requiresAllConditonallyShowPredicate,
            List<FormElementConditionallyShowPredicate> conditionallyShowPredicates,
            string name,
            string label,
            bool required,
            bool readOnly,
            string defaultValue
        )
        {
            FormElement textElement = new FormElement();
            textElement.type = "text";
            textElement.id = id;
            textElement.conditionallyShow = conditionallyShow;
            textElement.requiresAllConditionallyShowPredicates = requiresAllConditonallyShowPredicate;
            textElement.conditionallyShowPredicates = conditionallyShowPredicates;
            textElement.name = name;
            textElement.label = label;
            textElement.required = required;
            textElement.readOnly = readOnly;
            textElement.defaultValue = defaultValue;
            return textElement;
        }
    }
}