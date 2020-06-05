using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class JWTPayload
    {
        public bool? isOneBlinkMachine { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public bool? email_verified { get; set; }
        public string iss { get; set; }
        public string sub { get; set; }
        public string aud { get; set; }
        public int iat { get; set; }
        public int exp { get; set; }
        public List<Identity> identities { get; set; }
        public string client_id { get; set; }
    }

    public class Identity {
        public string userId { get; set; }
        public string providerType { get; set; }
    }
}
