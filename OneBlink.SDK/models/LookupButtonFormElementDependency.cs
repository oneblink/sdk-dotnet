using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class LookupButtonFormElementDependency
    {
        public string type
        {
            get; set;
        }
        public string elementId
        {
            get; set;
        }
        public LookupButtonFormElementDependency elementDependency
        {
            get; set;
        }
    }

}