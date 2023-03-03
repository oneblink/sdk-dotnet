using System;
using OneBlink.SDK.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;

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
            List<string> lastUpdatedBy = null,
            long? formApprovalFlowInstanceId = null
        )
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query[nameof(limit)] = limit.ToString();
            query[nameof(offset)] = offset.ToString();
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formId), formId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(externalId), externalId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submissionId), submissionId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submittedAfterDateTime), submittedAfterDateTime);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submittedBeforeDateTime), submittedBeforeDateTime);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(updatedAfterDateTime), updatedAfterDateTime);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(updatedBeforeDateTime), updatedBeforeDateTime);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formApprovalFlowInstanceId), formApprovalFlowInstanceId);
            if (statuses != default(List<string>))
            {
                foreach (var status in statuses)
                {
                    query[nameof(statuses)] = status;
                }
            }
            if (lastUpdatedBy != default(List<string>))
            {
                foreach (var lastUpdated in lastUpdatedBy)
                {
                    query[nameof(lastUpdatedBy)] = lastUpdated;
                }
            }
            string url = "/forms-apps/" + formsAppId + "/approvals?" + query.ToString();
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