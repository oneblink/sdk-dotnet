using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementLookupEnvironment
    {
        public string url
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public List<FormElementLookupStaticDataRecord> records
        {
            get; set;
        }
    }
}