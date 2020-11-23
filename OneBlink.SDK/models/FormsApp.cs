using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsApp
    {
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

    }
}