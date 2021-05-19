using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class ConditionallyShowPredicate
    {
        public Guid elementId { get; set; }
        private string[] AllowedTypes = new string[] { "OPTIONS", "NUMERIC", "VALUE", "BETWEEN" };
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
        public double value { get; set; }
        public Boolean hasValue { get; set; }
    }
}