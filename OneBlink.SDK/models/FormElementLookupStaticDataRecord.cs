using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementLookupStaticDataRecord
    {
        public string inputType
        {
            get; set;
        }
        public string inputValue
        {
            get; set;
        }
        public List<FormElementLookupStaticDataPreFill> preFills
        {
            get; set;
        }
    }
}