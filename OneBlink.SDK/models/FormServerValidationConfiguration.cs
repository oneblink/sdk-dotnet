using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public interface IEndpointConfiguration
    {
    }

    public class EndpointConfigurationAPI : IEndpointConfiguration
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
        public string secret
        {
            get; set;
        }
    }

    public class EndpointConfigurationCallback : IEndpointConfiguration
    {
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