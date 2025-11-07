using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormApprovalFlowStepBase
    {
        public string group
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
        public long? approvalFormId
        {
            get; set;
        }
        public bool? hideApprovalDenyButton
        {
            get; set;
        }
    }
}