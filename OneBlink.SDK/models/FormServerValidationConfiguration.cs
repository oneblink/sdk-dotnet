using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormServerValidationConfiguration
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
        public string secret
        {
            get; set;
        }
    }
}