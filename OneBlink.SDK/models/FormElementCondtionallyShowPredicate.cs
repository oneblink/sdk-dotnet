using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormElementConditionallyShowPredicate
    {
        public Guid elementId { get; set; }
        private string[] AllowedTypes = new string[] { "OPTIONS", "NUMERIC", "VALUE" };
        private string _Type;
        public string type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (!AllowedTypes.Any(x => x == value))
                {
                    throw new ArgumentException(value = " not a valid Form Element Conditionally Show Predicate Type");
                }
                _Type = value;
            }
        }
        public List<string> optionIds { get; set; }
        public string @operator { get; set; }
        public int value { get; set; }
        public Boolean hasValue { get; set; }
    }
}