using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormElement
    {
        private string[] AllowedTypes = new string[]
        {
            "text",
            "email",
            "textarea",
            "number",
            "select",
            "checkboxes",
            "radio",
            "draw",
            "camera",
            "date",
            "time",
            "datetime",
            "heading",
            "location",
            "repeatableSet",
            "page",
            "html",
            "barcodeScanner",
            "captcha",
            "image",
            "file",
            "files",
            "calculation",
            "telephone",
            "autocomplete",
            "form",
            "infoPage",
            "geoscapeAddress",
            "summary",
            "compliance",
            "pointAddress"
        };
        public Guid id { get; set; }
        public string name { get; set; }
        public string label { get; set; }

        public Boolean conditionallyShow { get; set; }
        public Boolean requiresAllConditionallyShowPredicates { get; set; }

        private string _Type;
        public string type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (!AllowedTypes.Any(x => x == value))
                {
                    throw new ArgumentException(value = " not a valid Form Element Type");
                }
                _Type = value;
            }
        }

        public Boolean required { get; set; }
        public Boolean readOnly { get; set; }
        public List<ConditionallyShowPredicate> conditionallyShowPredicates { get; set; }
        public dynamic defaultValue { get; set; }
        public Boolean buttons { get; set; }
        public Boolean multi { get; set; }
        public Boolean isSlider { get; set; }
        public long sliderIncrement { get; set; }
        public long minNumber { get; set; }
        public long maxNumber { get; set; }
        public long headingType { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string optionsType { get; set; }
        public long dynamicOptionSetId { get; set; }
        public List<FormElementOption> options { get; set; }
        public List<FormElementAttributeMapping> attributesMapping { get; set; }
        public Boolean conditionallyShowOptions { get; set; }
        public List<Guid> conditionallyShowOptionsElementIds { get; set; }
        public long minSetEntries { get; set; }
        public long maxSetEntries { get; set; }
        public string addSetEntryLabel { get; set; }
        public string removeSetEntryLabel { get; set; }
        public List<FormElement> elements { get; set; }
        public Boolean restrictBarcodeTypes { get; set; }
        public List<string> restrictedBarcodeTypes { get; set; }
        public string calculation { get; set; }
        public string preCalculationDisplay { get; set; }
        public Boolean isDataLookup { get; set; }
        public long dataLookupId { get; set; }
        public Boolean isElementLookup { get; set; }
        public long elementLookupId { get; set; }
        public long formId { get; set; }
        public string searchUrl { get; set; }
        public Boolean restrictFileTypes { get; set; }
        public List<string> restrictedFileTypes { get; set; }
        public int minEntries { get; set; }
        public int maxEntries { get; set; }
        public List<Guid> elementIds { get; set; }
        public List<string> stateTerritoryFilter { get; set; }
        public string hint { get; set; }
        public string placeholderValue { get; set; }
        public int? minLength {get; set; }
        public int? maxLength {get; set; }
        public List<string> addressTypeFilter {get;set;}

        public Boolean? isInteger {get; set; }
        private static Guid initialiseId(Guid? id)
        {
            if (!id.HasValue)
            {
                return Guid.NewGuid();
            }
            else
            {
                return id.Value;
            }
        }

        public static FormElement CreateTextElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            string defaultValue = null,
            string placeholderValue = null,
            string hint = null,
            int? minLength = null,
            int? maxLength = null
        )
        {
            FormElement textElement = new FormElement();
            textElement.type = "text";
            textElement.id = initialiseId(id);
            textElement.conditionallyShow = conditionallyShow;
            textElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            textElement.conditionallyShowPredicates = conditionallyShowPredicates;
            textElement.name = name;
            textElement.label = label;
            textElement.required = required;
            textElement.readOnly = readOnly;
            textElement.defaultValue = defaultValue;
            textElement.placeholderValue = placeholderValue;
            textElement.minLength = minLength;
            textElement.maxLength = maxLength;
            textElement.hint = hint;
            return textElement;
        }

        public static FormElement CreateGeoscapeAddressElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            string defaultValue = null,
            string placeholderValue = null,
            string hint = null,
            List<string> stateTerritoryFilter = null
        )
        {
            FormElement geoscapeAddressElement = new FormElement();
            geoscapeAddressElement.type = "geoscapeAddress";
            geoscapeAddressElement.id = initialiseId(id);
            geoscapeAddressElement.conditionallyShow = conditionallyShow;
            geoscapeAddressElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            geoscapeAddressElement.conditionallyShowPredicates = conditionallyShowPredicates;
            geoscapeAddressElement.name = name;
            geoscapeAddressElement.label = label;
            geoscapeAddressElement.required = required;
            geoscapeAddressElement.readOnly = readOnly;
            geoscapeAddressElement.defaultValue = defaultValue;
            geoscapeAddressElement.placeholderValue = placeholderValue;
            geoscapeAddressElement.hint = hint;
            geoscapeAddressElement.stateTerritoryFilter = stateTerritoryFilter;
            return geoscapeAddressElement;
        }

        public static FormElement CreateSummaryElement(
            string name,
            string label,
            List<Guid> elementIds,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null
        )
        {
            FormElement summaryElement = new FormElement();
            summaryElement.type = "summary";
            summaryElement.id = initialiseId(id);
            summaryElement.conditionallyShow = conditionallyShow;
            summaryElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            summaryElement.conditionallyShowPredicates = conditionallyShowPredicates;
            summaryElement.name = name;
            summaryElement.label = label;
            summaryElement.elementIds = elementIds;

            return summaryElement;
        }

        public static FormElement CreateComplianceElement(
            string name,
            string label,
            List<FormElementOption> options,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            string defaultValue = null,
            string hint = null,
            bool isDataLookup = false,
            long? dataLookupId =null,
            bool isElementLookup = false,
            long? elementLookupId = null
        )
        {
            FormElement complianceElement = new FormElement();
            complianceElement.type = "compliance";
            complianceElement.id = initialiseId(id);
            complianceElement.conditionallyShow = conditionallyShow;
            complianceElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            complianceElement.conditionallyShowPredicates = conditionallyShowPredicates;
            complianceElement.name = name;
            complianceElement.label = label;
            complianceElement.options = options;
            complianceElement.required = required;
            complianceElement.readOnly = readOnly;
            complianceElement.defaultValue = defaultValue;
            complianceElement.hint = hint;
            complianceElement.isDataLookup = isDataLookup;
            if (dataLookupId.HasValue) {
                complianceElement.dataLookupId = dataLookupId.Value;
            }
            complianceElement.isElementLookup = isElementLookup;
            if (elementLookupId.HasValue) {
                complianceElement.elementLookupId = elementLookupId.Value;
            }
            return complianceElement;
        }

        public static FormElement CreatePointAddressElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            string defaultValue = null,
            string placeholderValue = null,
            string hint = null,
            List<string> stateTerritoryFilter = null,
            List<string> addressTypeFilter = null
        )
        {
            FormElement pointAddressElement = new FormElement();
            pointAddressElement.type = "pointAddress";
            pointAddressElement.id = initialiseId(id);
            pointAddressElement.conditionallyShow = conditionallyShow;
            pointAddressElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            pointAddressElement.conditionallyShowPredicates = conditionallyShowPredicates;
            pointAddressElement.name = name;
            pointAddressElement.label = label;
            pointAddressElement.required = required;
            pointAddressElement.readOnly = readOnly;
            pointAddressElement.defaultValue = defaultValue;
            pointAddressElement.placeholderValue = placeholderValue;
            pointAddressElement.hint = hint;
            pointAddressElement.stateTerritoryFilter = stateTerritoryFilter;
            pointAddressElement.addressTypeFilter = addressTypeFilter;
            return pointAddressElement;
        }
    }
}