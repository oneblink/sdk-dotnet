using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchRequest
    {
        public long formId
        {
            get; set;
        }

        public bool? unwindRepeatableSets
        {
            get; set;
        }

        public FormStoreSearchPaging paging
        {
            get; set;
        }

        public List<FormStoreSearchSort> sorting
        {
            get; set;
        }

        public FormStoreSearchFilter filters
        {
            get; set;
        }
    }
}