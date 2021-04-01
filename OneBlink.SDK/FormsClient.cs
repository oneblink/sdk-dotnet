using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
using OneBlink.SDK.Model;

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

        public async Task<FormsSearchResult> Search(bool? isAuthenticated, bool? isPublished, string name)
        {
            string queryString = string.Empty;
            if (isAuthenticated.HasValue)
            {
                queryString += "isAuthenticated=" + isAuthenticated.Value.ToString();
            }
            if (isPublished.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "isPublished=" + isPublished.Value.ToString();
            }
            if (String.IsNullOrWhiteSpace(name))
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "name=" + name;
            }
            string url = "/forms?" + queryString;
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

        public async Task<FormSubmissionSearchResult> SearchSubmissions(long formId, DateTime? submissionDateFrom, DateTime? submissionDateTo, int limit = 0, int offset = 0)
        {
            string queryString = "formId=" + formId;

            if (submissionDateFrom.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }
                queryString += "submissionDateFrom=" + ((DateTime)submissionDateFrom).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            if (submissionDateTo.HasValue)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }

                queryString += "submissionDateTo=" + ((DateTime)submissionDateTo).ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            if (limit != 0)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }

                queryString += "limit=" + limit;
            }

            if (offset != 0)
            {
                if (queryString != string.Empty)
                {
                    queryString += "&";
                }

                queryString += "offset=" + offset;
            }

            string url = "/form-submission-meta?" + queryString;
            return await this.oneBlinkApiClient.GetRequest<FormSubmissionSearchResult>(url);
        }

        public async Task<Form> Get(long id, Boolean? injectForms)
        {
            string queryString = string.Empty;
            if (injectForms.HasValue)
            {
                queryString += "injectForms" + injectForms.ToString();
            }
            string url = "/forms/" + id.ToString() + "?" + queryString;
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
            string url = "/forms/" + formToUpdate.id.ToString();
            if (overrideLock) {
                url = url + "?overrideLock=true";
            }

            Form form = await this.oneBlinkApiClient.PutRequest<Form, Form>(url, formToUpdate);
            return form;
        }

        public async Task Delete(long id, bool overrideLock = false)
        {
            string url = "/forms/" + id.ToString();
            if (overrideLock) {
                url = url + "?overrideLock=true";
            }
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
        public static string EncryptUserToken(string username, string secret) {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(secret)) {
                throw new Exception("Must pass a valid username and secret");
            }
            AesUserToken aesUserToken = new AesUserToken(secret);
            return aesUserToken.encrypt(username);
        }
        public static string DecryptUserToken(string userToken, string secret) {
            if (String.IsNullOrEmpty(userToken) || String.IsNullOrEmpty(secret)) {
                throw new Exception("Must pass a valid userToken and secret");
            }
            AesUserToken aesUserToken = new AesUserToken(secret);
            return aesUserToken.decrypt(userToken);
        }

        public async Task<FormUrlResult> GenerateFormUrl(FormUrlOptions parameters) {
            if (parameters == null) {
                throw new Exception("parameters not provided");
            }
            if (parameters.formsAppId == null) {
                Form form = await oneBlinkApiClient.GetRequest<Form>($"/forms/{parameters.formId}");

                parameters.formsAppId = form.formsAppIds[0];
            }

            if (parameters.formsAppId == null) {
                throw new Exception("This form has not been added to a forms app yet.");
            }
            FormsApp formsApp = await oneBlinkApiClient.GetRequest<FormsApp>($"/forms-apps/{parameters.formsAppId}");

            string preFillFormDataId = null;
            if (parameters.preFillData != null) {
                PrefillClient prefillClient = new PrefillClient(oneBlinkApiClient);
                PreFillMeta preFillMeta = await prefillClient.GetPreFillMeta((int) parameters.formId);
                string preFillMetaId = await prefillClient.PutPreFillData<dynamic>(parameters.preFillData, preFillMeta);
                preFillFormDataId = preFillMeta.preFillFormDataId;
            }

            string userToken = null;
            if (parameters.username != null) {
                AesUserToken aesUserToken = new AesUserToken(parameters.secret);
                userToken = aesUserToken.encrypt(parameters.username);
            }

            // Default expiry for token is 8 hours
            int jwtExpiry = parameters.expiryInSeconds ?? 28800;
            string token = Token.GenerateJSONWebToken(accessKey: oneBlinkApiClient.accessKey, oneBlinkApiClient.secretKey, jwtExpiry);

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
            return new FormUrlResult() {
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
            string url = "/forms/" + formId.ToString() +"/retrieval-url/" + submissionId + "?expirySeconds=" + expiryInSeconds.ToString();
            SubmissionDataUrl submissionDataUrl = await this.oneBlinkApiClient.PostRequest<SubmissionDataUrl>(url);
            return submissionDataUrl;
        }

        private string _generateFormUrl(
        long formId,
        FormsApp formsApp,
        string token,
        string externalId,
        string preFillFormDataId,
        string userToken,
        long? previousFormSubmissionApprovalId )
        {
            // SEARCH PARAMS
            List<string> searchParams = new List<string>();
            searchParams.Add($"access_key={token}");
            if (externalId != null) {
                searchParams.Add($"externalId={externalId}");
            }
            if (preFillFormDataId != null) {
                searchParams.Add($"preFillFormDataId={preFillFormDataId}");
            }
            if (userToken != null) {
                searchParams.Add($"userToken={userToken}");
            }
            if (previousFormSubmissionApprovalId != null) {
                searchParams.Add($"previousFormSubmissionApprovalId={previousFormSubmissionApprovalId.ToString()}");
            }
            string url = $"https://{formsApp.hostname}/forms/{formId}";
            for (int i = 0; i < searchParams.Count; i++)
            {
                if (i == 0) url += "?";
                url += searchParams[i];
                if (i != searchParams.Count - 1) url += "&";
            }
            return url;
        }
    }
}
