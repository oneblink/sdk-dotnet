using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace OneBlink.SDK.Model
{
    public class JobsSearchParameters
    {
        public JobsSearchParameters(
            string username = null,
            long? formId = null,
            Boolean? isSumbitted = null,
            string externalId = null,
            int? limit = null,
            int? offset = null
        )
        {
            this.username = username;
            this.formId = formId;
            this.isSubmitted = isSubmitted;
            this.externalId = externalId;
            this.limit = limit;
            this.offset = offset;
        }

        public string username
        {
            get; set;
        }

        public long? formId
        {
            get; set;
        }

        public Boolean? isSubmitted
        {
            get; set;
        }

        public string externalId
        {
            get; set;
        }

        public int? limit
        {
            get; set;
        }

        public int? offset
        {
            get; set;
        }
    }

    public class JobsSearchResultMeta
    {
        public int offset
        {
            get; set;
        }
    }


    public class JobsSearchResult
    {
        public JobsSearchResultMeta meta
        {
            get; set;
        }

        public List<Job> jobs
        {
            get; set;
        }
    }

    public class JobDetail
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string key
        {
            get; set;
        }

        public string title
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? priority
        {
            get; set;
        }

        public JobDetail(string title, string key = null, string description = null, string type = null, int? priority = null)
        {
            this.title = title;
            this.key = key;
            this.description = description;
            this.type = type;
            this.priority = priority;
        }
    }

    public class Job
    {

        public Job(
            string username,
            JobDetail details,
            long formId,
            string externalId = null
        )
        {
            this.username = username;
            this.formId = formId;
            this.details = details;
            this.externalId = externalId;
        }

        public string username
        {
            get; set;
        }

        public long formId
        {
            get; set;
        }
        public JobDetail details
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string externalId
        {
            get; set;
        }

        //INTERAL SET PROPERTIES, NO EXTERNAL SETTING FOR USERS
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id
        {
            get; internal set;
        } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<bool> isSubmitted
        {
            get; internal set;
        } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Nullable<DateTime> createdAt
        {
            get; internal set;
        } = null;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? preFillFormDataId
        {
            get; internal set;
        } = null;
    }
}