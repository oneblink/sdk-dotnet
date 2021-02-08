using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormsApp
    {
        private string[] AllowedTypes = new string[]
        {
            "FORMS_LIST",
            "TILES",
            "VOLUNTEERS"
        };
        public long id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        [JsonProperty]
        public string hostname { get; internal set; }
        [JsonProperty]
        public DateTime createdAt { get; internal set; }
        [JsonProperty]
        public DateTime updatedAt { get; internal set; }
        public string organisationId { get; set; }
        public long formsAppEnvironmentId { get; set; }
        [JsonProperty]
        public string oAuthClientId { get; internal set; }
        public List<long> formIds { get; set; }
        [JsonProperty]
        public FormsAppStyles styles { get; internal set; }
        public FormsAppPWASettings pwaSettings { get; set; }
        public FormsAppWelcomeEmail welcomeEmail { get; set; }
        [JsonProperty]
        public bool hasSamlIdentityProvider { get; internal set; }
        public List<string> notificationEmailAddresses { get; set; }

        private string _Type;
        public string type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (!AllowedTypes.Any(x => x == value))
                {
                    throw new ArgumentException(value = " not a valid Form Element Type");
                }
                _Type = value;
            }
        }

        public List<string> categories {get;set;}
        public string waiverUrl {get;set;}

    }
}