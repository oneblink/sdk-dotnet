using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetFormSubmissionAdministrationApprovalsResponse : RequiredSearchResult
    {
        public List<GetFormSubmissionAdministrationApproval> approvals
        {
            get; set;
        }
    }
}