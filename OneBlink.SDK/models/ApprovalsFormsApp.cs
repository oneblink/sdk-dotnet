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
    }
}