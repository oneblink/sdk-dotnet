using System;
using Newtonsoft.Json;

namespace OneBlink.SDK.Model
{
    public class DeveloperKey
    {
        [JsonProperty]
        public string id
        {
            get; internal set;
        }

        [JsonProperty]
        [Obsolete("secret is deprecated and will always be null.")]
        public string secret
        {
            get; internal set;
        }

        [JsonProperty]
        public long customerSecretId
        {
            get; internal set;
        }

        [JsonProperty]
        public string name
        {
            get; internal set;
        }

        [JsonProperty]
        public DeveloperKeyPrivilege privilege
        {
            get; internal set;
        }

        [JsonProperty]
        public DeveloperKeyLinks links
        {
            get; internal set;
        }

    }

    public class DeveloperKeyPrivilege
    {

        [JsonProperty]
        public string API_HOSTING
        {
            get; internal set;
        }

        [JsonProperty]
        public string PDF
        {
            get; internal set;
        }

        [JsonProperty]
        public string WEB_APP_HOSTING
        {
            get; internal set;
        }

        [JsonProperty]
        public string FORMS
        {
            get; internal set;
        }
    }

    public class DeveloperKeyLinks
    {

        [JsonProperty]
        public string organisations
        {
            get; internal set;
        }
    }
}