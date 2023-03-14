using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public interface IEndpointConfiguration {
        string secret
        {
            get; set;
        }
    }
    public class FormExternalIdGeneration
    {
        public string type
        {
            get; set;
        }
        public FormExternalIdGenerationConfiguration configuration
        {
            get; set;
        }
    }
}