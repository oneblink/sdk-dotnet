using System;
using OneBlink.SDK.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace OneBlink.SDK
{
    public class ApprovalsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public ApprovalsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<GetFormSubmissionAdministrationApprovalsResponse> GetFormSubmissionAdministrationApprovals(
            long formsAppId,
            long limit,
            long offset,
            long? formId = null,
            string externalId = null,
            Guid? submissionId = null,
            string submittedAfterDateTime = null,
            string submittedBeforeDateTime = null,
            List<string> statuses = default(List<string>),
            string updatedAfterDateTime = null,
            string updatedBeforeDateTime = null,
            List<string> lastUpdatedBy = null
        )
        {
            NameValueCollection searchParams = System.Web.HttpUtility.ParseQueryString(string.Empty);

            searchParams.Add(nameof(limit), limit.ToString());
            searchParams.Add(nameof(offset), offset.ToString());

            if (formId.HasValue)
            {
                searchParams.Add(nameof(formId), formId.Value.ToString());
            }
            if (!String.IsNullOrEmpty(externalId))
            {
                searchParams.Add(nameof(externalId), externalId);
            }
            if (submissionId != null)
            {
                searchParams.Add(nameof(submissionId), submissionId.ToString());
            }
            if (!String.IsNullOrEmpty(submittedAfterDateTime))
            {
                searchParams.Add(nameof(submittedAfterDateTime), submittedAfterDateTime);
            }
            if (!String.IsNullOrEmpty(submittedBeforeDateTime))
            {
                searchParams.Add(nameof(submittedBeforeDateTime), submittedBeforeDateTime);
            }
            if (!String.IsNullOrEmpty(updatedAfterDateTime))
            {
                searchParams.Add(nameof(updatedAfterDateTime), updatedAfterDateTime);
            }
            if (!String.IsNullOrEmpty(updatedBeforeDateTime))
            {
                searchParams.Add(nameof(updatedBeforeDateTime), updatedBeforeDateTime);
            }
            if (statuses != default(List<string>))
            {
                foreach (var status in statuses)
                {
                    searchParams.Add(nameof(statuses), status);
                }
            }
            if (lastUpdatedBy != null)
            {
                foreach (string lastUpdated in lastUpdatedBy)
                {
                    searchParams.Add(nameof(lastUpdatedBy), lastUpdated);
                }
            }
            string url = "/forms-apps/" + formsAppId + "/approvals";
            return await this.oneBlinkApiClient.SearchRequest<GetFormSubmissionAdministrationApprovalsResponse>(url, searchParams);
        }
    }
}