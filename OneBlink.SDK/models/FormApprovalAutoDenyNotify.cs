using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormApprovalConfigurationAutoDenyNotify
    {
        public string notes
        {
            get; set;
        }
        public List<string> notificationEmailAddress
        {
            get; set;
        }
        public string cannedResponseKey
        {
            get; set;
        }
    }
}