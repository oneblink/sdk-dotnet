using System;

namespace OneBlink.SDK.Model
{
    public class FormUrlOptions
    {
        public long formId
        {
            get;
        }
        public long? formsAppId
        {
            get; set;
        }
        public int? expiryInSeconds
        {
            get;
        }
        public string externalId
        {
            get;
        }
        public dynamic preFillData
        {
            get;
        }
        public string username
        {
            get;
        }
        public long? previousFormSubmissionApprovalId
        {
            get;
        }

        public FormUrlOptions(
            long formId,
            long? formsAppId = null,
            int? expiryInSeconds = null,
            string externalId = null,
            dynamic preFillData = null,
            string username = null,
            long? previousFormSubmissionApprovalId = null
        )
        {
            this.formId = formId;
            this.formsAppId = formsAppId;
            this.expiryInSeconds = expiryInSeconds;
            this.externalId = externalId;
            this.preFillData = preFillData;
            this.username = username;
            this.previousFormSubmissionApprovalId = previousFormSubmissionApprovalId;
        }

    }

    public class FormUrlResult
    {
        public string formUrl
        {
            get; set;
        }
        public string expiry
        {
            get; set;
        }

    }
}
