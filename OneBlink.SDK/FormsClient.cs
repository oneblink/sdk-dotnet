using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
using System.Net.Mime;
using System.Web;
using Task = System.Threading.Tasks.Task;

namespace OneBlink.SDK
{
    public class FormsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public FormsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<FormSubmission<T>> GetFormSubmission<T>(long formId, string submissionId)
        {
            return await GetFormSubmission<T>(formId, submissionId, false);
        }

        [ObsoleteAttribute("This method is obsolete. Call GetFormSubmissionMeta instead.", true)]
        public async Task<FormSubmissionMetadataResponse> GetSubmissionMeta(string submissionId)
        {
            return await GetFormSubmissionMeta(submissionId);
        }

        public async Task<FormSubmissionMetadataResponse> GetFormSubmissionMeta(string submissionId)
        {
            string url = "/form-submission-meta/" + submissionId;
            return await this.oneBlinkApiClient.GetRequest<FormSubmissionMetadataResponse>(url);
        }

        public async Task<FormSubmission<T>> GetFormSubmission<T>(long formId, string submissionId, bool isDraft)
        {
            if (String.IsNullOrWhiteSpace(submissionId))
            {
                throw new ArgumentException("submissionId must be provided with a value");
            }

            string url = "/forms/" + formId + "/retrieval-credentials/" + submissionId;
            if (isDraft)
            {
                url = "/forms/" + formId + "/download-draft-data-credentials/" + submissionId;

            }
            FormSubmissionRetrievalConfiguration formRetrievalData = await this.oneBlinkApiClient.PostRequest<FormSubmissionRetrievalConfiguration>(url);
            return await GetFormSubmission<T>(formRetrievalData);
        }

        public async Task<FormsSearchResult> Search(bool? isAuthenticated,
            bool? isPublished,
            string name,
            long? formsAppEnvironmentId = null,
            long? formsAppId = null,
            int? limit = null,
            int? offset = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(isAuthenticated), isAuthenticated);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(isPublished), isPublished);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(name), name);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formsAppEnvironmentId), formsAppEnvironmentId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formsAppId), formsAppId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(limit), limit);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(offset), offset);

            string url = "/v2/forms?" + query.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormsSearchResult>(url);
        }

        public async Task<FormSubmissionSearchResult> SearchSubmissions(long formId, int limit = 0, int offset = 0)
        {
            return await SearchSubmissions(formId, null, null, limit, offset);
        }

        public async Task<FormSubmissionSearchResult> SearchSubmissionsFromDate(long formId, DateTime? submissionDateFrom, int limit = 0, int offset = 0)
        {
            return await SearchSubmissions(formId, submissionDateFrom, null, limit, offset);
        }

        public async Task<FormSubmissionSearchResult> SearchSubmissionsToDate(long formId, DateTime? submissionDateTo, int limit = 0, int offset = 0)
        {
            return await SearchSubmissions(formId, null, submissionDateTo, limit, offset);
        }

        public async Task<FormSubmissionSearchResult> SearchSubmissions(long formId, DateTime? submissionDateFrom, DateTime? submissionDateTo, int limit = 0, int offset = 0, bool? isValid = null, string submissionTitle = null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(formId), formId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submissionDateFrom), submissionDateFrom);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submissionDateTo), submissionDateTo);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(limit), limit);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(offset), offset);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(isValid), isValid);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(submissionTitle), submissionTitle);

            string url = "/form-submission-meta?" + query.ToString();
            return await this.oneBlinkApiClient.GetRequest<FormSubmissionSearchResult>(url);
        }

        public async Task<Form> Get(long id, Boolean? injectForms)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(injectForms), injectForms);
            string url = "/forms/" + id.ToString() + "?" + query.ToString();
            return await this.oneBlinkApiClient.GetRequest<Form>(url);
        }

        public async Task<Form> Create(Form newForm)
        {
            string url = "/forms";
            Form form = await this.oneBlinkApiClient.PostRequest<Form, Form>(url, newForm);
            return form;
        }

        public async Task<Form> Update(Form formToUpdate, bool overrideLock = false)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(overrideLock), overrideLock);

            string url = "/forms/" + formToUpdate.id.ToString() + "?" + query.ToString();
            Form form = await this.oneBlinkApiClient.PutRequest<Form, Form>(url, formToUpdate);
            return form;
        }

        public async Task Delete(long id, bool overrideLock = false)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(overrideLock), overrideLock);

            string url = "/forms/" + id.ToString() + "?" + query.ToString();
            await this.oneBlinkApiClient.DeleteRequest(url);
        }

        private async Task<FormSubmission<T>> GetFormSubmission<T>(FormSubmissionRetrievalConfiguration formRetrievalData)
        {
            if (formRetrievalData == null || formRetrievalData.s3 == null || formRetrievalData.credentials == null)
            {
                throw new Exception("Could not create credentials to retrieve form submission data");
            }

            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(formRetrievalData.s3.region);
            SessionAWSCredentials sessionAWSCredentials = new SessionAWSCredentials(
                formRetrievalData.credentials.AccessKeyId,
                formRetrievalData.credentials.SecretAccessKey,
                formRetrievalData.credentials.SessionToken
            );
            AmazonS3Client amazonS3Client = new AmazonS3Client(sessionAWSCredentials, regionEndpoint);

            string responseBody = "";
            using (GetObjectResponse response = await amazonS3Client.GetObjectAsync(formRetrievalData.s3.bucket, formRetrievalData.s3.key, null))
            using (Stream responseStream = response.ResponseStream)
            using (StreamReader reader = new StreamReader(responseStream))
            {
                responseBody = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<FormSubmission<T>>(responseBody);
        }
        public static string EncryptUserToken(string username, string secret)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(secret))
            {
                throw new Exception("Must pass a valid username and secret");
            }
            AesUserToken aesUserToken = new AesUserToken(secret);
            return aesUserToken.encrypt(username);
        }
        public static string DecryptUserToken(string userToken, string secret)
        {
            if (String.IsNullOrEmpty(userToken) || String.IsNullOrEmpty(secret))
            {
                throw new Exception("Must pass a valid userToken and secret");
            }
            AesUserToken aesUserToken = new AesUserToken(secret);
            return aesUserToken.decrypt(userToken);
        }

        public async Task<FormUrlResult> GenerateFormUrl(FormUrlOptions parameters)
        {
            if (parameters == null)
            {
                throw new Exception("parameters not provided");
            }
            if (parameters.formsAppId == null)
            {
                Form form = await oneBlinkApiClient.GetRequest<Form>($"/forms/{parameters.formId}");

                parameters.formsAppId = form.formsAppIds[0];
            }

            if (parameters.formsAppId == null)
            {
                throw new Exception("This form has not been added to a forms app yet.");
            }
            FormsListFormsApp formsApp = await oneBlinkApiClient.GetRequest<FormsListFormsApp>($"/forms-apps/{parameters.formsAppId}");

            DeveloperKeyAccess developerKeyAccess = new DeveloperKeyAccess()
            {
                submissions = new DeveloperKeyAccessSubmissions()
                {
                    create = new DeveloperKeyAccessSubmissionsCreate()
                    {
                        formIds = new List<long>() { parameters.formId }
                    }
                },
                forms = new DeveloperKeyAccessForms()
                {
                    read = new DeveloperKeyAccessFormsRead()
                    {
                        ids = new List<long>() { parameters.formId }
                    }
                }
            };
            Guid? preFillFormDataId = null;
            if (parameters.preFillData != null)
            {
                PrefillClient prefillClient = new PrefillClient(oneBlinkApiClient);
                PreFillMeta preFillMeta = await prefillClient.GetPreFillMeta(parameters.formId);
                await prefillClient.PutPreFillData<dynamic>(parameters.preFillData, preFillMeta);
                preFillFormDataId = preFillMeta.preFillFormDataId;
                developerKeyAccess.prefillData = new DeveloperKeyAccessPrefillData()
                {
                    read = new DeveloperKeyAccessPrefillDataRead()
                    {
                        ids = new List<Guid>() { preFillMeta.preFillFormDataId }
                    }
                };
            }

            string userToken = null;
            if (parameters.username != null)
            {
                AesUserToken aesUserToken = new AesUserToken(parameters.secret);
                userToken = aesUserToken.encrypt(parameters.username);
            }

            // Default expiry for token is 8 hours
            int jwtExpiry = parameters.expiryInSeconds ?? 28800;
            string token = Token.GenerateJSONWebToken(accessKey: oneBlinkApiClient.accessKey, oneBlinkApiClient.secretKey, jwtExpiry, developerKeyAccess);

            string formUrl = _generateFormUrl(
                formId: parameters.formId,
                formsApp: formsApp,
                token: token,
                externalId: parameters.externalId,
                preFillFormDataId: preFillFormDataId,
                userToken: userToken,
                previousFormSubmissionApprovalId: parameters.previousFormSubmissionApprovalId
            );
            string expiry = DateTime.UtcNow.AddSeconds(jwtExpiry).ToString("o");
            return new FormUrlResult()
            {
                formUrl = formUrl,
                expiry = expiry
            };
        }

        public async Task<SubmissionDataUrl> GenerateSubmissionDataUrl(long formId, string submissionId, long expiryInSeconds)
        {
            if (expiryInSeconds < 900)
            {
                throw new ArgumentOutOfRangeException("expiryInSeconds must be greater than or equal to 900");
            }
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, "expirySeconds", expiryInSeconds);

            string url = "/forms/" + formId.ToString() + "/retrieval-url/" + submissionId + "?" + query.ToString();
            SubmissionDataUrl submissionDataUrl = await this.oneBlinkApiClient.PostRequest<SubmissionDataUrl>(url);
            return submissionDataUrl;
        }

        public async Task<Stream> GetFormSubmissionAttachment(long formId, string attachmentId)
        {
            string url = "/submissions/" + formId.ToString() + "/attachments/" + attachmentId;
            return await this.oneBlinkApiClient.GetStreamRequest(url);
        }

        public async Task<FormAttachmentMeta> GetFormSubmissionAttachmentMeta(long formId, string attachmentId)
        {
            string url = "/forms/" + formId.ToString() + "/attachments/" + attachmentId + "/meta";
            return await this.oneBlinkApiClient.GetRequest<FormAttachmentMeta>(url);
        }

        public async Task<AttachmentData> CreateSubmissionAttachment(long formId, Stream body, string fileName, string contentType, bool isPrivate, string username)
        {
            string url = "/forms/" + formId.ToString() + "/upload-attachment-credentials";
            AttachmentUploadCredentialsRequest requestBody = new AttachmentUploadCredentialsRequest();
            requestBody.username = username;
            AttachmentUploadCredentialsResponse response = await this.oneBlinkApiClient.PostRequest<AttachmentUploadCredentialsRequest, AttachmentUploadCredentialsResponse>(url, requestBody);

            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(response.s3.region);

            SessionAWSCredentials sessionAWSCredentials = new SessionAWSCredentials(
                response.credentials.AccessKeyId,
                response.credentials.SecretAccessKey,
                response.credentials.SessionToken
            );
            AmazonS3Client amazonS3Client = new AmazonS3Client(sessionAWSCredentials, regionEndpoint);
            PutObjectRequest request = new PutObjectRequest
            {
                BucketName = response.s3.bucket,
                Key = response.s3.key,
                InputStream = body,
                ContentType = contentType,
                CannedACL = isPrivate ? S3CannedACL.Private : S3CannedACL.PublicRead,
                ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
            };
            ContentDisposition disposition = new ContentDisposition();
            disposition.DispositionType = DispositionTypeNames.Attachment;
            disposition.FileName = fileName;
            request.Headers.ContentDisposition = disposition.ToString();
            request.Headers.ExpiresUtc = new DateTime().AddYears(1).ToUniversalTime(); // Max 1 year
            request.Headers.CacheControl = "max-age=31536000"; // Max 1 year(365 days)

            await amazonS3Client.PutObjectAsync(request);
            AttachmentData attachmentData = new AttachmentData();
            attachmentData.id = response.attachmentDataId;
            attachmentData.contentType = contentType;
            attachmentData.fileName = fileName;
            attachmentData.isPrivate = isPrivate;
            attachmentData.url = oneBlinkApiClient.tenant.oneBlinkAPIOrigin + "/" + response.s3.key;
            attachmentData.s3 = response.s3;
            attachmentData.uploadedAt = response.uploadedAt;
            return attachmentData;
        }

        internal class ExpiryInSeconds
        {
            internal ExpiryInSeconds(long expiryInSeconds)
            {
                this.expiryInSeconds = expiryInSeconds;
            }
            [JsonProperty]
            internal long expiryInSeconds
            {
                get; set;
            }
        }

        public async Task<SubmissionDataUrl> GenerateSubmissionAttachmentUrl(long formId, string attachmentId, long expiryInSeconds)
        {
            if (expiryInSeconds < 900)
            {
                throw new ArgumentOutOfRangeException("expiryInSeconds must be greater than or equal to 900");
            }
            string url = "/forms/" + formId.ToString() + "/attachments/" + attachmentId + "/download-url";
            return await this.oneBlinkApiClient.PostRequest<ExpiryInSeconds, SubmissionDataUrl>(url, new ExpiryInSeconds(expiryInSeconds));
        }
        public async Task<SubmissionDataUrl> GenerateWorkflowAttachmentLink(long formId, string submissionId, string attachmentId)
        {
            string url = "/forms/" + formId.ToString() + "/submissions/" + submissionId + "/attachments/" + attachmentId + "/workflow-link";
            return await this.oneBlinkApiClient.PostRequest<SubmissionDataUrl>(url);
        }

        private string _generateFormUrl(
        long formId,
        FormsAppBase formsApp,
        string token,
        string externalId,
        Guid? preFillFormDataId,
        string userToken,
        long? previousFormSubmissionApprovalId)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, "access_key", token);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(externalId), externalId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(preFillFormDataId), preFillFormDataId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(userToken), userToken);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(previousFormSubmissionApprovalId), previousFormSubmissionApprovalId);

            string url = $"https://{formsApp.hostname}/forms/{formId}?{query.ToString()}";
            return url;
        }

        public async Task Migrate(FormMigrationOptions migrationOptions)
        {
            string url = $"/forms/{migrationOptions.sourceFormId.ToString()}/migrate";
            // C# does not support `void` as a generic type argument -_-
            await this.oneBlinkApiClient.PostRequest<FormMigrationOptions, object>(url, migrationOptions);
            return;
        }

    }
}
