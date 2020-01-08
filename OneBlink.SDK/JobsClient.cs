using System.Threading.Tasks;
using OneBlink.SDK.Model;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using System;

namespace OneBlink.SDK
{
    public class JobsClient
    {
        OneBlinkHttpClient oneBlinkHttpClient;

        public JobsClient(string accessKey, string secretKey)
        {
            this.oneBlinkHttpClient = new OneBlinkHttpClient(accessKey, secretKey);
        }

        public async Task DeleteJob(string jobId)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentException("'jobId' must be provided with a valid value");
            }

            string url = $"/jobs/{jobId}";

            await this.oneBlinkHttpClient.DeleteRequest(url);
        }

        public async Task<Job> CreateJob(JobDetail details, string externalId, int formId, string username)
        {
            NewJob newJob = _CreateJob(details, externalId, formId, username);
            return await CreateJob<Object>(details, externalId, formId, username, null);
        }

        public async Task<Job> CreateJob<T>(JobDetail details, string externalId, int formId, string username, T preFillData)
        {
            NewJob newJob = _CreateJob(details, externalId, formId, username);

            string preFillMetaId = await _SetPreFillData<T>(preFillData, formId);
            newJob.preFillFormDataId = preFillMetaId;

            return await _CreateJob(newJob);
        }

        private NewJob _CreateJob(JobDetail details, string externalId, int formId, string username)
        {
            if (string.IsNullOrEmpty(details.title))
            {
                throw new ArgumentException("The 'Title' property of JobDetail must be provided with a value");
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("'Username' must be provided with a valid value");
            }

            NewJob newJob = new NewJob();

            newJob.username = username;
            newJob.details = details;
            newJob.externalId = externalId;
            newJob.formId = formId;

            return newJob;
        }

        private async Task<Job> _CreateJob(NewJob newJob)
        {
            string url = "/jobs";

            return await this.oneBlinkHttpClient.PostRequest<NewJob, Job>(url, newJob);
        }

        private async Task<string> _SetPreFillData<T>(T preFillData, int formId)
        {
            string url = "/forms/" + formId.ToString() + "/pre-fill-credentials";

            PreFillMeta preFillMeta = await this.oneBlinkHttpClient.PostRequest<PreFillMeta>(url);

            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(preFillMeta.s3.region);

            SessionAWSCredentials sessionAWSCredentials = new SessionAWSCredentials(
                preFillMeta.credentials.AccessKeyId,
                preFillMeta.credentials.SecretAccessKey,
                preFillMeta.credentials.SessionToken
            );

            AmazonS3Client amazonS3Client = new AmazonS3Client(sessionAWSCredentials, regionEndpoint);

            PutObjectRequest request = new PutObjectRequest
            {
                BucketName = preFillMeta.s3.bucket,
                Key = preFillMeta.s3.key,
                ContentBody = JsonConvert.SerializeObject(preFillData),
                ContentType = "application/json"
            };

            await amazonS3Client.PutObjectAsync(request);

            return preFillMeta.preFillFormDataId;
        }
    }
}