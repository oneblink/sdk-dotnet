using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormsAppBase
    {
        private string[] AllowedTypes = new string[]
        {
            "FORMS_LIST",
            "TILES",
            "VOLUNTEERS",
            "APPROVALS"
        };
        public long id {get;set;}
        [JsonProperty]
        public DateTime createdAt { get; internal set; }
        [JsonProperty]
        public DateTime updatedAt { get; internal set; }
        public string name {get;set;}
        public string hostname {get;set;}
        public string oAuthClientId {get;set;}
        public string organisationId {get;set;}
        public FormsAppPWASettings pwaSettings {get;set;}
        public FormsAppWelcomeEmail welcomeEmail {get;set;}
        public bool hasSamlIdentityProvider {get;set;}
        public long formsAppEnvironmentId {get;set;}
        public List<string> notificationEmailAddresses {get;set;}
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
                    throw new ArgumentException(value = " not a valid Forms App Type");
                }
                _Type = value;
            }
        }
    }
}