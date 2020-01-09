using System;
using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
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

        public JobDetail(string title)
        {
            this.title = title;
        }
    }

    public class NewJob
    {
        public JobDetail details
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string externalId
        {
            get; set;
        }

        public int formId
        {
            get; set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string preFillFormDataId
        {
            get; set;
        }
        public string username
        {
            get; set;
        }

        public NewJob()
        {

        }

        public NewJob(JobDetail details, int formId, string username)
        {
            this.details = details;
            this.formId = formId;
            this.username = username;
        }

        public NewJob(JobDetail details, int formId, string username, string externalId)
        {
            this.details = details;
            this.formId = formId;
            this.username = username;
            this.externalId = externalId;
        }
    }

    public class Job : NewJob
    {
        public string id
        {
            get; set;
        }

        public bool isSubmitted
        {
            get; set;
        }

        public DateTime createdAt
        {
            get; set;
        }
    }
}