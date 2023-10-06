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
        /// <summary>
        /// If `compareWith` is "ELEMENT" this is an elementId (string), otherwise a number (double)
        /// </summary>
        public object value
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
        /// <summary>
        /// This property can be either "VALUE" or "ELEMENT". if left NULL acts as "VALUE".
        /// </summary>
        public string compareWith
        {
            get; set;
        }
        public ConditionallyShowPredicate predicate
        {
            get; set;
        }
    }
}