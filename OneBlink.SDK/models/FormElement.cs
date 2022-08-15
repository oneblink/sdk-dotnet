using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormElement
    {
        public Guid id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string label
        {
            get; set;
        }

        public Boolean conditionallyShow
        {
            get; set;
        }
        public Boolean requiresAllConditionallyShowPredicates
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public Boolean required
        {
            get; set;
        }
        public string requiredMessage
        {
            get; set;
        }
        public Boolean readOnly
        {
            get; set;
        }
        public List<ConditionallyShowPredicate> conditionallyShowPredicates
        {
            get; set;
        }
        public dynamic defaultValue
        {
            get; set;
        }
        public long? defaultValueDaysOffset
        {
            get; set;
        }
        public Boolean buttons
        {
            get; set;
        }
        public Boolean multi
        {
            get; set;
        }
        public Boolean isSlider
        {
            get; set;
        }
        public long? sliderIncrement
        {
            get; set;
        }
        public long? minNumber
        {
            get; set;
        }
        public long? maxNumber
        {
            get; set;
        }
        public long? headingType
        {
            get; set;
        }
        public string fromDate
        {
            get; set;
        }
        public long? fromDateDaysOffset
        {
            get; set;
        }
        public string toDate
        {
            get; set;
        }
        public long? toDateDaysOffset
        {
            get; set;
        }
        public string optionsType
        {
            get; set;
        }
        public string freshdeskFieldName
        {
            get; set;
        }
        public long? dynamicOptionSetId
        {
            get; set;
        }
        public List<FormElementOption> options
        {
            get; set;
        }
        public List<FormElementAttributeMapping> attributesMapping
        {
            get; set;
        }
        public Boolean conditionallyShowOptions
        {
            get; set;
        }
        public List<Guid> conditionallyShowOptionsElementIds
        {
            get; set;
        }
        public long? minSetEntries
        {
            get; set;
        }
        public long? maxSetEntries
        {
            get; set;
        }
        public string addSetEntryLabel
        {
            get; set;
        }
        public string removeSetEntryLabel
        {
            get; set;
        }
        public List<FormElement> elements
        {
            get; set;
        }
        public Boolean restrictBarcodeTypes
        {
            get; set;
        }
        public List<string> restrictedBarcodeTypes
        {
            get; set;
        }
        public string calculation
        {
            get; set;
        }
        public string preCalculationDisplay
        {
            get; set;
        }
        public Boolean isDataLookup
        {
            get; set;
        }
        public long? dataLookupId
        {
            get; set;
        }
        public Boolean isElementLookup
        {
            get; set;
        }
        public long? elementLookupId
        {
            get; set;
        }
        public long? formId
        {
            get; set;
        }
        public string searchUrl
        {
            get; set;
        }
        public Boolean restrictFileTypes
        {
            get; set;
        }
        public List<string> restrictedFileTypes
        {
            get; set;
        }

        public bool allowExtensionlessAttachments
        {
            get; set;
        }
        public int? minEntries
        {
            get; set;
        }
        public int? maxEntries
        {
            get; set;
        }
        public List<Guid> elementIds
        {
            get; set;
        }
        public List<string> stateTerritoryFilter
        {
            get; set;
        }
        public string hint
        {
            get; set;
        }
        public string placeholderValue
        {
            get; set;
        }
        public int? minLength
        {
            get; set;
        }
        public int? maxLength
        {
            get; set;
        }
        public List<string> addressTypeFilter
        {
            get; set;
        }
        public Boolean? isInteger
        {
            get; set;
        }
        public Boolean? displayAsCurrency
        {
            get; set;
        }
        public string storageType
        {
            get; set;
        }
        public string regexPattern
        {
            get; set;
        }
        public string regexFlags
        {
            get; set;
        }
        public string regexMessage
        {
            get; set;
        }
        public Boolean? canToggleAll
        {
            get; set;
        }
        public Boolean? useGeoscapeAddressing
        {
            get; set;
        }
        public Boolean? isCollapsed
        {
            get; set;
        }
        public string titleLabel
        {
            get; set;
        }
        public string familyNameLabel
        {
            get; set;
        }
        public string givenName1Label
        {
            get; set;
        }
        public Boolean? givenName1IsRequired
        {
            get; set;
        }
        public Boolean? givenName1IsHidden
        {
            get; set;
        }
        public string emailAddressLabel
        {
            get; set;
        }
        public Boolean? emailAddressIsRequired
        {
            get; set;
        }
        public Boolean? emailAddressIsHidden
        {
            get; set;
        }
        public string homePhoneLabel
        {
            get; set;
        }
        public Boolean? homePhoneIsRequired
        {
            get; set;
        }
        public Boolean? homePhoneIsHidden
        {
            get; set;
        }
        public string businessPhoneLabel
        {
            get; set;
        }
        public Boolean? businessPhoneIsRequired
        {
            get; set;
        }
        public Boolean? businessPhoneIsHidden
        {
            get; set;
        }
        public string mobilePhoneLabel
        {
            get; set;
        }
        public Boolean? mobilePhoneIsRequired
        {
            get; set;
        }
        public Boolean? mobilePhoneIsHidden
        {
            get; set;
        }
        public string faxPhoneLabel
        {
            get; set;
        }
        public Boolean? faxPhoneIsRequired
        {
            get; set;
        }
        public Boolean? faxPhoneIsHidden
        {
            get; set;
        }
        public string streetAddressesLabel
        {
            get; set;
        }
        public string address1Label
        {
            get; set;
        }
        public string address2Label
        {
            get; set;
        }
        public string postcodeLabel
        {
            get; set;
        }
        public string subCategoryLabel
        {
            get; set;
        }
        public string subCategoryHint
        {
            get; set;
        }
        public string itemLabel
        {
            get; set;
        }
        public string itemHint
        {
            get; set;
        }
        public List<string> customCssClasses
        {
            get; set;
        }
        public string meta
        {
            get; set;
        }
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
            int? maxLength = null,
            List<string> customCssClasses = null,
            string meta = null
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
            textElement.customCssClasses = customCssClasses;
            textElement.meta = meta;
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
            List<string> stateTerritoryFilter = null,
            List<string> customCssClasses = null,
            string meta = null
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
            geoscapeAddressElement.customCssClasses = customCssClasses;
            geoscapeAddressElement.meta = meta;
            return geoscapeAddressElement;
        }

        public static FormElement CreateSummaryElement(
            string name,
            string label,
            List<Guid> elementIds,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            List<string> customCssClasses = null,
            string meta = null
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
            summaryElement.customCssClasses = customCssClasses;
            summaryElement.meta = meta;

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
            long? dataLookupId = null,
            bool isElementLookup = false,
            long? elementLookupId = null,
            List<string> customCssClasses = null,
            string meta = null
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
            if (dataLookupId.HasValue)
            {
                complianceElement.dataLookupId = dataLookupId.Value;
            }
            complianceElement.isElementLookup = isElementLookup;
            if (elementLookupId.HasValue)
            {
                complianceElement.elementLookupId = elementLookupId.Value;
            }
            complianceElement.customCssClasses = customCssClasses;
            complianceElement.meta = meta;
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
            List<string> addressTypeFilter = null,
            List<string> customCssClasses = null,
            string meta = null
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
            pointAddressElement.customCssClasses = customCssClasses;
            pointAddressElement.meta = meta;
            return pointAddressElement;
        }

        public static FormElement CreateBooleanElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            bool defaultValue = false,
            string hint = null,
            bool isDataLookup = false,
            long? dataLookupId = null,
            bool isElementLookup = false,
            long? elementLookupId = null,
            List<string> customCssClasses = null,
            string meta = null
        )
        {
            FormElement booleanElement = new FormElement();
            booleanElement.type = "boolean";
            booleanElement.id = initialiseId(id);
            booleanElement.conditionallyShow = conditionallyShow;
            booleanElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            booleanElement.conditionallyShowPredicates = conditionallyShowPredicates;
            booleanElement.name = name;
            booleanElement.label = label;
            booleanElement.required = required;
            booleanElement.readOnly = readOnly;
            booleanElement.defaultValue = defaultValue;
            booleanElement.hint = hint;
            booleanElement.isDataLookup = isDataLookup;
            if (dataLookupId.HasValue)
            {
                booleanElement.dataLookupId = dataLookupId.Value;
            }
            booleanElement.isElementLookup = isElementLookup;
            if (elementLookupId.HasValue)
            {
                booleanElement.elementLookupId = elementLookupId.Value;
            }
            booleanElement.customCssClasses = customCssClasses;
            booleanElement.meta = meta;
            return booleanElement;
        }

        public static FormElement CreateCivicaNameRecordElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            dynamic defaultValue = null,
            string hint = null,
            Boolean useGeoscapeAddressing = false,
            string titleLabel = null,
            string familyNameLabel = null,
            string givenName1Label = null,
            Boolean givenName1IsRequired = false,
            Boolean givenName1IsHidden = false,
            string emailAddressLabel = null,
            Boolean emailAddressIsRequired = false,
            Boolean emailAddressIsHidden = false,
            string homePhoneLabel = null,
            Boolean homePhoneIsRequired = false,
            Boolean homePhoneIsHidden = false,
            string businessPhoneLabel = null,
            Boolean businessPhoneIsRequired = false,
            Boolean businessPhoneIsHidden = false,
            string mobilePhoneLabel = null,
            Boolean mobilePhoneIsRequired = false,
            Boolean mobilePhoneIsHidden = false,
            string faxPhoneLabel = null,
            Boolean faxPhoneIsRequired = false,
            Boolean faxPhoneIsHidden = false,
            string streetAddressesLabel = null,
            string address1Label = null,
            string address2Label = null,
            string postcodeLabel = null,
            List<string> customCssClasses = null,
            string meta = null
        )
        {
            FormElement civicaNameRecordElement = new FormElement();
            civicaNameRecordElement.type = "civicaNameRecord";
            civicaNameRecordElement.id = initialiseId(id);
            civicaNameRecordElement.conditionallyShow = conditionallyShow;
            civicaNameRecordElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            civicaNameRecordElement.conditionallyShowPredicates = conditionallyShowPredicates;
            civicaNameRecordElement.name = name;
            civicaNameRecordElement.label = label;
            civicaNameRecordElement.required = required;
            civicaNameRecordElement.readOnly = readOnly;
            civicaNameRecordElement.defaultValue = defaultValue;
            civicaNameRecordElement.hint = hint;
            civicaNameRecordElement.useGeoscapeAddressing = useGeoscapeAddressing;
            civicaNameRecordElement.titleLabel = titleLabel;
            civicaNameRecordElement.familyNameLabel = familyNameLabel;
            civicaNameRecordElement.givenName1Label = givenName1Label;
            civicaNameRecordElement.givenName1IsRequired = givenName1IsRequired;
            civicaNameRecordElement.givenName1IsHidden = givenName1IsHidden;
            civicaNameRecordElement.emailAddressLabel = emailAddressLabel;
            civicaNameRecordElement.emailAddressIsRequired = emailAddressIsRequired;
            civicaNameRecordElement.emailAddressIsHidden = emailAddressIsHidden;
            civicaNameRecordElement.homePhoneLabel = homePhoneLabel;
            civicaNameRecordElement.homePhoneIsRequired = homePhoneIsRequired;
            civicaNameRecordElement.homePhoneIsHidden = homePhoneIsHidden;
            civicaNameRecordElement.businessPhoneLabel = businessPhoneLabel;
            civicaNameRecordElement.businessPhoneIsRequired = businessPhoneIsRequired;
            civicaNameRecordElement.businessPhoneIsHidden = businessPhoneIsHidden;
            civicaNameRecordElement.mobilePhoneLabel = mobilePhoneLabel;
            civicaNameRecordElement.mobilePhoneIsRequired = mobilePhoneIsRequired;
            civicaNameRecordElement.mobilePhoneIsHidden = mobilePhoneIsHidden;
            civicaNameRecordElement.faxPhoneLabel = faxPhoneLabel;
            civicaNameRecordElement.faxPhoneIsRequired = faxPhoneIsRequired;
            civicaNameRecordElement.faxPhoneIsHidden = faxPhoneIsHidden;
            civicaNameRecordElement.streetAddressesLabel = streetAddressesLabel;
            civicaNameRecordElement.address1Label = address1Label;
            civicaNameRecordElement.address2Label = address2Label;
            civicaNameRecordElement.postcodeLabel = postcodeLabel;
            civicaNameRecordElement.customCssClasses = customCssClasses;
            civicaNameRecordElement.meta = meta;
            return civicaNameRecordElement;
        }

        public static FormElement CreateSectionElement(
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            string hint = null,
            Boolean isCollapsed = false,
            List<FormElement> elements = null,
            List<string> customCssClasses = null,
            string meta = null
        )
        {
            FormElement sectionElement = new FormElement();
            sectionElement.type = "section";
            sectionElement.id = initialiseId(id);
            sectionElement.conditionallyShow = conditionallyShow;
            sectionElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            sectionElement.conditionallyShowPredicates = conditionallyShowPredicates;
            sectionElement.label = label;
            sectionElement.hint = hint;
            sectionElement.isCollapsed = isCollapsed;
            sectionElement.elements = elements;
            sectionElement.customCssClasses = customCssClasses;
            sectionElement.meta = meta;
            return sectionElement;
        }

        public static FormElement CreateCivicaStreetNameElement(
            string name,
            string label,
            Guid? id = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool required = false,
            bool readOnly = false,
            string placeholderValue = null,
            string hint = null,
            bool isDataLookup = false,
            long? dataLookupId = null,
            bool isElementLookup = false,
            long? elementLookupId = null,
            List<string> customCssClasses = null,
            string meta = null
        )
        {
            FormElement civicaStreetNameElement = new FormElement();
            civicaStreetNameElement.type = "civicaStreetName";
            civicaStreetNameElement.id = initialiseId(id);
            civicaStreetNameElement.conditionallyShow = conditionallyShow;
            civicaStreetNameElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            civicaStreetNameElement.conditionallyShowPredicates = conditionallyShowPredicates;
            civicaStreetNameElement.name = name;
            civicaStreetNameElement.label = label;
            civicaStreetNameElement.required = required;
            civicaStreetNameElement.readOnly = readOnly;
            civicaStreetNameElement.placeholderValue = placeholderValue;
            civicaStreetNameElement.hint = hint;
            if (dataLookupId.HasValue)
            {
                civicaStreetNameElement.dataLookupId = dataLookupId.Value;
            }
            civicaStreetNameElement.isElementLookup = isElementLookup;
            if (elementLookupId.HasValue)
            {
                civicaStreetNameElement.elementLookupId = elementLookupId.Value;
            }
            civicaStreetNameElement.customCssClasses = customCssClasses;
            civicaStreetNameElement.meta = meta;
            return civicaStreetNameElement;
        }
        public static FormElement CreateFilesElementEvent(
            string name,
            string label,
            Guid? id = null,
            bool readOnly = false,
            string hint = null,
            string storageType = null,
            bool restrictFileTypes = false,
            List<string> restrictedFileTypes = null,
            int? maxEntries = null,
            int? minEntries = null,
            bool conditionallyShow = false,
            bool requiresAllConditionallyShowPredicates = false,
            List<ConditionallyShowPredicate> conditionallyShowPredicates = null,
            bool isDataLookup = false,
            long? dataLookupId = null,
            bool isElementLookup = false,
            long? elementLookupId = null,
            bool allowExtensionlessAttachments = false,
            List<string> customCssClasses = null,
            string meta = null
        )
        {
            FormElement filesElement = new FormElement();
            filesElement.type = "files";
            filesElement.name = name;
            filesElement.label = label;
            filesElement.id = initialiseId(id);
            filesElement.readOnly = readOnly;
            filesElement.hint = hint;
            filesElement.storageType = storageType;
            filesElement.restrictFileTypes = restrictFileTypes;
            filesElement.restrictedFileTypes = restrictedFileTypes;
            filesElement.minEntries = minEntries;
            filesElement.maxEntries = maxEntries;
            filesElement.conditionallyShow = conditionallyShow;
            filesElement.requiresAllConditionallyShowPredicates = requiresAllConditionallyShowPredicates;
            filesElement.conditionallyShowPredicates = conditionallyShowPredicates;
            filesElement.isDataLookup = isDataLookup;
            filesElement.dataLookupId = dataLookupId;
            filesElement.isElementLookup = isElementLookup;
            filesElement.elementLookupId = elementLookupId;
            filesElement.allowExtensionlessAttachments = allowExtensionlessAttachments;
            filesElement.customCssClasses = customCssClasses;
            filesElement.meta = meta;
            return filesElement;
        }
    }
}