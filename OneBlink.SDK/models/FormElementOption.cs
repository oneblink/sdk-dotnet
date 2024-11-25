using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormElementOption
    {
        public string id
        {
            get; set;
        }
        public string value
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
        public string colour
        {
            get; set;
        }
        public bool displayAlways
        {
            get; set;
        }
        public List<FormElementOptionAttribute> attributes
        {
            get; set;
        }
        public string imageUrl
        {
            get; set;
        }
    }
}