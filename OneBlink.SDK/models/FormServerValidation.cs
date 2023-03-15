using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormServerValidation
    {
        public string type
        {
            get; set;
        }
        public IEndpointConfiguration configuration
        {
            get; set;
        }
    }
}