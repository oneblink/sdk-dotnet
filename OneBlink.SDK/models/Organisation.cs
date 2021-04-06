using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class Organisation
    {
        public string id { get; set; }
        public string name {get;set;}
        public string assetsS3Bucket {get;set;}
        public string slug {get;set;}
        public long tierId {get;set;}
        [JsonProperty]
        public DateTime createdAt { get; internal set; }
        public string trialExpiry {get;set;}
        public List<string> tags {get;set;}
        public bool retainSubmissionData {get;set;}
        public long? submissionDataRetentionDays {get;set;}
        public bool retainPrefillData {get;set;}
        public long? prefillDataRetentionDays {get;set;}
        public bool retainDraftData {get;set;}
        public List<FormsAppBase> solutions {get;set;}
        public string awsCustomerId {get;set;}

    }
}