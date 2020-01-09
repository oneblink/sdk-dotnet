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

        public async Task<Job> CreateJob(NewJob newJob)
        {
            _ValidateJob(newJob);

            return await _CreateJob(newJob);
        }

        public async Task<Job> CreateJob<T>(NewJob newJob, T preFillData)
        {
            _ValidateJob(newJob);

            string preFillMetaId = await _SetPreFillData<T>(preFillData, newJob.formId);
            newJob.preFillFormDataId = preFillMetaId;

            return await _CreateJob(newJob);
        }

        private async Task<Job> _CreateJob(NewJob newJob)
        {
            string url = "/jobs";

            return await this.oneBlinkHttpClient.PostRequest<NewJob, Job>(url, newJob);
        }

        private void _ValidateJob(NewJob newJob)
        {
            if (string.IsNullOrWhiteSpace(newJob.username))
            {
                throw new ArgumentException("'username' must be provided with a valid email address");
            }

            if (string.IsNullOrEmpty(newJob.details.title))
            {
                throw new ArgumentException("The 'title' property of JobDetail must be provided with a value");
            }
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
