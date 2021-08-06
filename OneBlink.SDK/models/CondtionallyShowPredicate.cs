using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class ConditionallyShowPredicate
    {
        public Guid elementId
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public List<string> optionIds
        {
            get; set;
        }
        public string @operator
        {
            get; set;
        }
        public double? value
        {
            get; set;
        }
        public Boolean? hasValue
        {
            get; set;
        }
        public long? min
        {
            get; set;
        }
        public long? max
        {
            get; set;
        }
    }
}