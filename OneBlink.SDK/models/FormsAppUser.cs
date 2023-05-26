using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormsAppUser
    {
        public long id
        {
            get; set;
        }
        public Boolean generatePassword
        {
            get; set;
        }
        public dynamic welcomeEmailParamters
        {
            get; set;
        }
        [JsonProperty]
        public DateTime createdAt
        {
            get; internal set;
        }
        [JsonProperty]
        public DateTime updatedAt
        {
            get; internal set;
        }
        public string email
        {
            get; set;
        }
        public long formsAppId
        {
            get; set;
        }
        public List<string> groups
        {
            get; set;
        }
        public string firstName
        {
            get; set;
        }
        public string lastName
        {
            get; set;
        }

    }
}