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
            "summary"
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
        public List<FormElementConditionallyShowPredicate> conditionallyShowPredicates { get; set; }
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
    }
}