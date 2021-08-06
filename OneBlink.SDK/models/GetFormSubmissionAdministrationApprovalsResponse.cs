using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetFormSubmissionAdministrationApprovalsResponse : SearchResult
    {
        public List<GetFormSubmissionAdministrationApproval> approvals
        {
            get; set;
        }
    }
}