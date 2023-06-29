using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementListEnvironment
    {
        public string url
        {
            get; set;
        }
        public string searchQuerystringParameter
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public List<FormElementOption> options
        {
            get; set;
        }
    }
}