using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementList
    {
        public string name
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public long id
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public string apiId
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
        public long workspaceId
        {
            get; set;
        }
        public List<FormElementListEnvironment> environments
        {
            get; set;
        }
    }

    //This is the result returned from the OneBlink API.
    //We cannot change the data that is returned so we will use this data to transform it
    //into the SearchResult class below this.
    public class FormElementListInternalSearchResult : SearchResult
    {
        public List<FormElementList> formElementDynamicOptionSets
        {
            get; set;
        }
    }

    //This is the result we return from the `Search()` function in ListsClient.
    //This is to avoid mention to the older name of `OptionSets` for `Lists`.
    public class FormElementListSearchResult : SearchResult
    {
        public List<FormElementList> formElementLists
        {
            get; set;
        }
    }

}