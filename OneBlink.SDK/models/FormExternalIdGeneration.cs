using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{

    public class FormExternalIdGeneration
    {
        public string type
        {
            get; set;
        }
        public IFormExternalIdGenerationConfiguration configuration
        {
            get; set;
        }
    }
}