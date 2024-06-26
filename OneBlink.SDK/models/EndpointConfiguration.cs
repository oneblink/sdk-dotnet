using System;

namespace OneBlink.SDK.Model
{
    public class EndpointConfiguration
    {
        public string apiId
        {
            get; set;
        }
        public string apiEnvironment
        {
            get; set;
        }
        public string apiEnvironmentRoute
        {
            get; set;
        }
        public string url
        {
            get; set;
        }
        [Obsolete("secret is deprecated and will always be null.")]
        public string secret
        {
            get; set;
        }
        public long? organisationManagedSecretId
        {
            get; set;
        }
    }
}