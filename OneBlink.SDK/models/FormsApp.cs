using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsApp
    {
        public long id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string hostname { get; }
        public DateTime createdAt { get; }
        public DateTime updatedAt { get; }
        public string organisationId { get; set; }
        public long formsAppEnvironmentId { get; set; }
        public string oAuthClientId { get; }
        public List<long> formIds { get; set; }
        public FormsAppStyles styles { get; }
        public FormsAppPWASettings pwaSettings { get; set; }
        public FormsAppWelcomeEmail welcomeEmail { get; set; }
        public bool hasSamlIdentityProvider { get; }
        public List<string> notificationEmailAddresses { get; set; }

    }
}