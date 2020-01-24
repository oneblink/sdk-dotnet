using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
namespace OneBlink.SDK.Model
{
    public class JobsSearchParameters
    {   
        public JobsSearchParameters(
            string username = null, 
            int? formId = null, 
            Boolean? isSumbitted = null, 
            string externalId = null, 
            int? limit = null, 
            int? offset = null
        ) {
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
        public int? formId
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

        public JobDetail(string title, string key = null, string description = null, string type = null)
        {
            this.title = title;
            this.key = key;
            this.description = description;
            this.type = type;
        }
    }

    // public class NewJob
    // {
    //     public JobDetail details
    //     {
    //         get; set;
    //     }

    //     [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    //     public string externalId
    //     {
    //         get; set;
    //     }

    //     public int formId
    //     {
    //         get; set;
    //     }

    //     [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    //     public string preFillFormDataId
    //     {
    //         get; set;
    //     }
    //     public string username
    //     {
    //         get; set;
    //     }

    //     public NewJob()
    //     {

    //     }

    //     public NewJob(JobDetail details, int formId, string username)
    //     {
    //         this.details = details;
    //         this.formId = formId;
    //         this.username = username;
    //     }

    //     public NewJob(JobDetail details, int formId, string username, string externalId)
    //     {
    //         this.details = details;
    //         this.formId = formId;
    //         this.username = username;
    //         this.externalId = externalId;
    //     }
    // }

    // public class Job : NewJob
    // {
        // public string id
        // {
        //     get; set;
        // }

        // public bool isSubmitted
        // {
        //     get; set;
        // }

        // public DateTime createdAt
        // {
        //     get; set;
        // }
    // }

    public class Job {
        
        public Job(
            string username,
            JobDetail details,
            Nullable<int> formId = null, 
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

        public Nullable<int> formId
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

        //INTERAL SET PROPERTIES, NO EXTERNAL SETTING FOR SETTING
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id
        {
            get; set;
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
        public string preFillFormDataId
        {
            get; internal set;
        } = null;

        // public NewJob(JobDetail details, int formId, string username)
        // {
        //     this.details = details;
        //     this.formId = formId;
        //     this.username = username;
        // }

        // public NewJob(JobDetail details, int formId, string username, string externalId)
        // {
        //     this.details = details;
        //     this.formId = formId;
        //     this.username = username;
        //     this.externalId = externalId;
        // }
    }
}


// public class Hello {
//     Hello(){
//         var job = new Job(
//             username: "Hello",
//             formId: 2,
//             externalId: "sasds",
//             details: new JobDetail(
//                 title: "sasds",
//                 key: "MyKey",
//                 description: "MyDescription",
//                 type: "MyType"
//             )
//         );
//         job.createdAt = new DateTime();
//     }

// }
