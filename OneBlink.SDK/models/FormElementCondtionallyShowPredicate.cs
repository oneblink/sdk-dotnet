using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementConditionallyShowPredicate
    {
        public Guid elementId { get; set; }
        public string type { get; set; }
        public List<string> optionIds { get; set; }
        public string @operator { get; set; }
        public int value { get; set; }
    }
}