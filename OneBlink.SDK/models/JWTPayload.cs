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
        public string middle_name
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
        public string address
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
        [JsonProperty("custom:area_code")]
        public string customAreaCode
        {
            get; set;
        }
        [JsonProperty("custom:city")]
        public string customCity
        {
            get; set;
        }
        [JsonProperty("custom:state")]
        public string customState
        {
            get; set;
        }
        [JsonProperty("custom:country")]
        public string customCountry
        {
            get; set;
        }
        [JsonProperty("custom:country_calling_code")]
        public string customCountryCallingCode
        {
            get; set;
        }
        [JsonProperty("custom:department")]
        public string customDepartment
        {
            get; set;
        }
        [JsonProperty("custom:division")]
        public string customDivision
        {
            get; set;
        }
        [JsonProperty("custom:bargain")]
        public string customBargain
        {
            get; set;
        }
        [JsonProperty("custom:employee_number")]
        public string customEmployeeNumber
        {
            get; set;
        }
        [JsonProperty("custom:departmenthead_name")]
        public string customDepartmentHeadName
        {
            get; set;
        }
        [JsonProperty("custom:departmenthead_email")]
        public string customDepartmentHeadEmail
        {
            get; set;
        }
        [JsonProperty("custom:zip_code")]
        public string customZipCode
        {
            get; set;
        }
        [JsonProperty("custom:postal_code")]
        public string customPostalCode
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
