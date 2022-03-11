using System.Threading.Tasks;
using OneBlink.SDK.Model;
using System;

namespace OneBlink.SDK
{
    public class JobsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public JobsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }
        public async Task DeleteJob(string jobId)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentException("'jobId' must be provided with a valid value");
            }

            string url = $"/jobs/{jobId}";

            await this.oneBlinkApiClient.DeleteRequest(url);
        }

        public async Task<Job> CreateJob(Job job)
        {
            _ValidateJob(job);

            return await _CreateJob(job);
        }

        public async Task<Job> CreateJob<T>(Job job, T preFillData)
        {
            _ValidateJob(job);
            PrefillClient prefillClient = new PrefillClient(oneBlinkApiClient);
            string preFillMetaId = await prefillClient.SetPreFillData<T>(preFillData, job.formId);

            job.preFillFormDataId = preFillMetaId;

            return await _CreateJob(job);
        }

        public async Task<JobsSearchResult> SearchByExternalId(string externalId)
        {
            JobsSearchParameters searchParams = new JobsSearchParameters
            {
                externalId = externalId
            };

            return await SearchJobs(searchParams);
        }

        public async Task<JobsSearchResult> SearchByFormId(long formId)
        {
            JobsSearchParameters searchParams = new JobsSearchParameters
            {
                formId = formId
            };

            return await SearchJobs(searchParams);
        }

        public async Task<JobsSearchResult> SearchByUsername(string username)
        {
            JobsSearchParameters searchParams = new JobsSearchParameters
            {
                username = username
            };

            return await SearchJobs(searchParams);
        }

        public async Task<JobsSearchResult> SearchJobs(JobsSearchParameters searchParams)
        {
            string queryString = string.Empty;

            if (searchParams.formId.HasValue)
            {
                queryString += "formId=" + searchParams.formId.Value.ToString();
            }

            if (searchParams.isSubmitted.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "isSubmitted=" + searchParams.isSubmitted.Value.ToString();
            }

            if (searchParams.limit.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "limit=" + searchParams.limit.Value.ToString();
            }

            if (searchParams.offset.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "offset=" + searchParams.offset.Value.ToString();
            }

            if (!String.IsNullOrWhiteSpace(searchParams.username))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "username=" + searchParams.username.ToString();
            }

            if (!String.IsNullOrWhiteSpace(searchParams.externalId))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "externalId=" + searchParams.externalId.ToString();
            }

            string url = "/jobs?" + queryString;

            return await this.oneBlinkApiClient.GetRequest<JobsSearchResult>(url);
        }



        private async Task<Job> _CreateJob(Job job)
        {
            string url = "/jobs";

            return await this.oneBlinkApiClient.PostRequest<Job, Job>(url, job);
        }

        private void _ValidateJob(Job job)
        {
            if (string.IsNullOrWhiteSpace(job.username))
            {
                throw new ArgumentException("'username' must be provided with a valid email address");
            }

            if (string.IsNullOrEmpty(job.details.title))
            {
                throw new ArgumentException("The 'title' property of JobDetail must be provided with a value");
            }
        }
    }
}
