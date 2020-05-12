using System;
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
            "infoPage"
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
        // TODO Add further props, restrict props based on type
    }
}