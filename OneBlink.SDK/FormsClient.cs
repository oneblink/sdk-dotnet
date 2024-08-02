using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
using System.Net.Mime;
using System.Web;
using Task = System.Threading.Tasks.Task;
using System.Net;

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

            try
            {
                if (isDraft)
                {
                    return await this.oneBlinkApiClient.GetRequest<FormSubmission<T>>("/storage/form-submission-draft-versions/" + submissionId);
                }

                return await this.oneBlinkApiClient.GetRequest<FormSubmission<T>>("/storage/forms/" + formId + "/submissions/" + submissionId);
            }
            catch (OneBlinkAPIException error)
            {
                if (error.StatusCode == HttpStatusCode.Forbidden)
                {
                    return null;
                }
                throw error;
            }
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
                Guid id = await prefillClient.SetPreFillData(parameters.preFillData, parameters.formId);
                preFillFormDataId = id;
                developerKeyAccess.prefillData = new DeveloperKeyAccessPrefillData()
                {
                    read = new DeveloperKeyAccessPrefillDataRead()
                    {
                        ids = new List<Guid>()
                        {
                            id
                        }
                    }
                };
            }

            // Default expiry for token is 8 hours
            int jwtExpiry = parameters.expiryInSeconds ?? 28800;
            string token = Token.GenerateJSONWebToken(
                this.oneBlinkApiClient.accessKey,
                this.oneBlinkApiClient.secretKey,
                jwtExpiry,
                developerKeyAccess,
                parameters.username
            );

            string formUrl = this._generateFormUrl(
                formId: parameters.formId,
                formsApp: formsApp,
                token: token,
                externalId: parameters.externalId,
                preFillFormDataId: preFillFormDataId,
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
            string url = "/storage/forms/" + formId.ToString() + "/attachments/" + attachmentId;
            return await this.oneBlinkApiClient.GetStreamRequest(url);
        }

        public async Task<FormAttachmentMeta> GetFormSubmissionAttachmentMeta(long formId, string attachmentId)
        {
            string url = "/forms/" + formId.ToString() + "/attachments/" + attachmentId + "/meta";
            return await this.oneBlinkApiClient.GetRequest<FormAttachmentMeta>(url);
        }

        private class ExecuteWorkflowEventRequest
        {
            [JsonProperty]
            internal Guid submissionId
            {
                get; set;
            }
            [JsonProperty]
            internal long formId
            {
                get; set;
            }
            [JsonProperty]
            internal FormSubmissionEvent submissionEvent
            {
                get; set;
            }
        }

        public async Task<FormSubmissionWorkflowEvent> ExecuteWorkflowEvent(long formId, Guid submissionId, FormSubmissionEvent workflowEvent)
        {
            string url = "/form-submission-meta/replay-submission-event";
            return await this.oneBlinkApiClient.PostRequest<ExecuteWorkflowEventRequest, FormSubmissionWorkflowEvent>(url, new ExecuteWorkflowEventRequest()
            {
                submissionId = submissionId,
                formId = formId,
                submissionEvent = workflowEvent
            });
        }

        internal class AttachmentUploadRequest
        {
            [JsonProperty]
            internal string username
            {
                get; set;
            }
        }

        internal class AttachmentUploadResponse : AssetUploadResponse
        {
            [JsonProperty]
            internal string attachmentDataId
            {
                get; set;
            }
            [JsonProperty]
            internal string uploadedAt
            {
                get; set;
            }
        }

        public async Task<AttachmentData> CreateSubmissionAttachment(long formId, Stream body, string fileName, string contentType, bool isPrivate, string username)
        {
            string key = "/forms/" + formId.ToString() + "/attachments";
            AttachmentUploadRequest attachmentUploadRequest = new AttachmentUploadRequest()
            {
                username = username
            };
            ContentDisposition disposition = new ContentDisposition
            {
                DispositionType = DispositionTypeNames.Attachment,
                FileName = fileName
            };
            AttachmentUploadResponse attachmentUploadResponse = await this.oneBlinkApiClient.Upload<AttachmentUploadRequest, AttachmentUploadResponse>(key, body, contentType, attachmentUploadRequest, isPublic: !isPrivate, disposition);

            AttachmentData attachmentData = new AttachmentData();
            attachmentData.id = attachmentUploadResponse.attachmentDataId;
            attachmentData.contentType = contentType;
            attachmentData.fileName = fileName;
            attachmentData.isPrivate = isPrivate;
            attachmentData.url = attachmentUploadResponse.url;
            attachmentData.s3 = attachmentUploadResponse.s3;
            attachmentData.uploadedAt = attachmentUploadResponse.uploadedAt;
            return attachmentData;
        }

        internal class WorkflowAttachmentUploadRequest
        {
            [JsonProperty]
            internal string filename
            {
                get; set;
            }
        }

        public async Task<EmailAttachmentData> UploadEmailAttachment(string filename, string contentType, Stream body)
        {
            string key = "email-attachments";
            WorkflowAttachmentUploadRequest requestBody = new WorkflowAttachmentUploadRequest
            {
                filename = filename
            };
            ContentDisposition disposition = new ContentDisposition()
            {
                FileName = filename,
                DispositionType = DispositionTypeNames.Attachment
            };
            S3UploadResponse s3UploadResponse = await this.oneBlinkApiClient.Upload<WorkflowAttachmentUploadRequest>(key, body, contentType, requestBody, disposition);
            EmailAttachmentData emailAttachmentData = new EmailAttachmentData
            {
                contentType = contentType,
                filename = filename,
                s3 = s3UploadResponse.s3
            };
            return emailAttachmentData;
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
        long? previousFormSubmissionApprovalId)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            OneBlinkHttpClient.AddItemToQuery(query, "access_key", token);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(externalId), externalId);
            OneBlinkHttpClient.AddItemToQuery(query, nameof(preFillFormDataId), preFillFormDataId);
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
