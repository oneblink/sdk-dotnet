using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormStoreDefinition
    {
        public long formId
        {
            get; set;
        }

        public List<FormElement> formElements
        {
            get; set;
        }
    }
}