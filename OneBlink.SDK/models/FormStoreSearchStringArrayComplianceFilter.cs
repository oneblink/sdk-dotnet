using System;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchStringArrayComplianceFilter : IFormStoreInterface
    {
        public FormStoreSearchStringArrayFilter value
        {
            get; set;
        }
        public FormStoreSearchRegexFilter notes
        {
            get; set;
        }
    }
}