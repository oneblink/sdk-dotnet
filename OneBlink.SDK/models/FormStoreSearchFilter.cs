using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchFilter
    {
        public FormStoreSearchDateTimeFilter dateTimeSubmitted
        {
            get; set;
        }

        public FormStoreSearchGuidFilter submissionId
        {
            get; set;
        }
        public FormStoreSearchRegexFilter externalId
        {
            get; set;
        }
        public FormStoreSearchRegexFilter submittedBy
        {
            get; set;
        }
        public Dictionary<string, IFormStoreInterface> submission
        {
            get; set;
        }
    }
}