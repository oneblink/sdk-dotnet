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
        public FormServerValidationConfiguration configuration
        {
            get; set;
        }
    }
}