using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementOptionAttribute
    {
        public List<string> optionIds { get; set; }
        public Guid elementId { get; set; }
    }
}