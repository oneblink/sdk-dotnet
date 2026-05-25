using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalPrefillElementPath
    {
        public List<FormApprovalPrefillPathSegment> containers
        {
            get; set;
        }
        public string formElementId
        {
            get; set;
        }
    }
}
