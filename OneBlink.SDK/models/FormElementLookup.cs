using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementLookup
    {
        public string type
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public string apiId
        {
            get; set;
        }
        public List<FormElementLookupEnvironment> environments
        {
            get; set;
        }
        public long id
        {
            get; set;
        }
        public string createdAt
        {
            get; set;
        }
        public string updatedAt
        {
            get; set;
        }
        public bool? excludeDefinition
        {
            get; set;
        }

    }

    public class FormElementLookupSearchResult : SearchResult
    {
        public List<FormElementLookup> formElementLookups
        {
            get; set;
        }
    }
}