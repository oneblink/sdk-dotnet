using System;
using System.Linq;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsAppMenuItems
    {
        public string label { get; set; }
        public string icon { get; set; }
        private string _Type;
        public string type {get;set;}
        public bool isHidden { get; set; }
        public bool isDefault { get; set; }
        public string href { get; set; }
        public List<long> formIds { get; set; }
        public long formId { get; set; }
    }
}