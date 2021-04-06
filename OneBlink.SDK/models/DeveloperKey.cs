using System;

namespace OneBlink.SDK.Model
{
    public class DeveloperKey
    {
        public string id { get; internal set; }
        public string secret { get; internal set; }
        public string name { get; internal set; }
        public DeveloperKeyPrivilege privilege { get; internal set; }
        public DeveloperKeyLinks links { get; internal set; }
        public Boolean isSolutions { get; internal set; }

    }

    public class DeveloperKeyPrivilege
    {
        public string API_HOSTING { get; internal set; }
        public string PDF { get; internal set; }
        public string WEB_APP_HOSTING { get; internal set; }
        public string FORMS { get; internal set; }
    }

    public class DeveloperKeyLinks
    {
        public string organisations { get; internal set; }
    }
}