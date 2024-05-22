using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class ApprovalsFormsApp : FormsAppBase
    {
        public ApprovalsFormsApp()
        {
            this.type = "APPROVALS";
        }
        public FormsAppStylesBase styles
        {
            get; set;
        }
        public override string type
        {
            get;
        }
        public List<string> approvalGroups
        {
            get; set;
        }
    }
}