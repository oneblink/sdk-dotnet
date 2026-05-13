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
        public Guid formElementId
        {
            get; set;
        }
    }
}
