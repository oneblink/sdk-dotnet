using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public abstract class FormsAppBase
    {
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
        public bool isClientLoggingEnabled {get; set;}
        private string _Type;
        public abstract string type { get; }

    }
}