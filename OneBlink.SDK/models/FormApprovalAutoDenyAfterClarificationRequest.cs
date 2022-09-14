namespace OneBlink.SDK.Model
{
    public class FormApprovalConfigurationAutoDenyAfterClarificationRequest
    {
        public long days
        {
            get; set;
        }
        public FormApprovalConfigurationAutoDenyNotify notify
        {
            get; set;
        }

        public string internalNotes
        {
            get; set;
        }
    }
}