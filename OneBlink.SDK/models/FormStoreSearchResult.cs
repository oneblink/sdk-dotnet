using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormStoreSearchResult<T> : SearchResult
    {
        public List<FormStoreRecord<T>> submissions
        {
            get; set;
        }
    }
}