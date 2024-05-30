using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    internal class RawJWTPayload
    {
        public string email
        {
            get; set;
        }
        public string username
        {
            get; set;
        }
        public string given_name
        {
            get; set;
        }
        public string family_name
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public bool? email_verified
        {
            get; set;
        }
        public string iss
        {
            get; set;
        }
        public string sub
        {
            get; set;
        }
        public string aud
        {
            get; set;
        }
        public int iat
        {
            get; set;
        }
        public int exp
        {
            get; set;
        }
        public List<Identity> identities
        {
            get; set;
        }
        public string client_id
        {
            get; set;
        }
        public string picture
        {
            get; set;
        }
        [JsonProperty("custom:role")]
        public string customRole
        {
            get; set;
        }
        [JsonProperty("custom:supervisor_name")]
        public string customSupervisorName
        {
            get; set;
        }
        [JsonProperty("custom:supervisor_email")]
        public string customSupervisorEmail
        {
            get; set;
        }
        [JsonProperty("custom:supervisor_user_id")]
        public string customSupervisorUserId
        {
            get; set;
        }
        [JsonProperty("custom:phone_number")]
        public string customPhoneNumber
        {
            get; set;
        }
        [JsonProperty("custom:phone_number_verified")]
        public bool? customPhoneNumberVerified
        {
            get; set;
        }
        public string preferred_username
        {
            get; set;
        }
        [JsonProperty("custom:groups")]
        public string customGroups
        {
            get; set;
        }
    }

    public class Identity
    {
        public string userId
        {
            get; set;
        }
        public string providerType
        {
            get; set;
        }
    }

    public class JWTPayload : FormSubmissionMetaUserDetails
    {
    }
}
