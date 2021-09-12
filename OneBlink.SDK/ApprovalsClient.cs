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

        public async Task<GetFormSubmissionAdministrationApprovalsResponse> GetFormSubmissionAdministrationApprovals(
            long formsAppId,
            long limit,
            long offset,
            long? formId = null,
            string externalId = null,
            string submissionId = null,
            string submittedAfterDateTime = null,
            string submittedBeforeDateTime = null,
            List<string> statuses = default(List<string>),
            string updatedAfterDateTime = null,
            string updatedBeforeDateTime = null,
            List<string> lastUpdatedBy = null
        )
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
            if (!String.IsNullOrEmpty(updatedAfterDateTime))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(updatedAfterDateTime) + "=" + updatedAfterDateTime;
            }
            if (!String.IsNullOrEmpty(updatedBeforeDateTime))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += nameof(updatedBeforeDateTime) + "=" + updatedBeforeDateTime;
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
            if (lastUpdatedBy != default(List<string>))
            {
                foreach (var lastUpdated in lastUpdatedBy)
                {
                    if (queryString != string.Empty)
                    {
                        queryString += "&";
                    }

                    queryString += nameof(lastUpdatedBy) + "=" + lastUpdated;
                }
            }
            string url = "/forms-apps/" + formsAppId + "/approvals?" + queryString;
            var response = await this.oneBlinkApiClient.GetRequest<GetFormSubmissionAdministrationApprovalsResponse>(url);
            return response;
        }

        public async Task<GetFormSubmissionApprovalResponse> GetFormSubmissionApproval(
            Guid formSubmissionApprovalId
        )
        {
            string url = "/form-submission-approvals/" + formSubmissionApprovalId.ToString();
            return await this.oneBlinkApiClient.GetRequest<GetFormSubmissionApprovalResponse>(url);
        }

        public async Task<GetFormApprovalFlowInstanceResponse> GetFormApprovalFlowInstance(long formApprovalFlowInstanceId)
        {
            string url = "/form-approval-flow-instances/" + formApprovalFlowInstanceId.ToString();

            return await this.oneBlinkApiClient.GetRequest<GetFormApprovalFlowInstanceResponse>(url);
        }
    }
}