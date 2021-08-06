using System;
using OneBlink.SDK.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<GetFormSubmissionAdministrationApprovalsResponse> GetFormSubmissionAdministrationApprovals(long formsAppId,
        long limit,
        long offset,
        long? formId = null,
        string externalId = null,
        string submissionId = null,
        string submittedAfterDateTime = null,
        string submittedBeforeDateTime = null,
        List<string> statuses = default(List<string>))
        {
            string queryString = nameof(limit) + "=" + limit.ToString() + "&" + nameof(offset) + "=" + offset.ToString();
            if (formId.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "formId=" + formId.Value.ToString();
            }
            if (!String.IsNullOrEmpty(externalId))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(externalId) + "=" + externalId;
            }
            if (!String.IsNullOrEmpty(submissionId))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(submissionId) + "=" + submissionId;
            }
            if (!String.IsNullOrEmpty(submittedAfterDateTime))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(submittedAfterDateTime) + "=" + submittedAfterDateTime;
            }
            if (!String.IsNullOrEmpty(submittedBeforeDateTime))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(submittedBeforeDateTime) + "=" + submittedBeforeDateTime;
            }
            if (statuses != default(List<string>))
            {
                foreach (var status in statuses)
                {
                    if (queryString != string.Empty)
                    {
                        queryString += "&";
                    }

                    queryString += nameof(statuses) + "=" + status;
                }
            }
            string url = "/forms-apps/" + formsAppId + "/approvals?" + queryString;
            var response = await this.oneBlinkApiClient.GetRequest<GetFormSubmissionAdministrationApprovalsResponse>(url);
            return response;
        }
    }
}