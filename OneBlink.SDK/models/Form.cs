using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class Form
    {
        public Form() { }

        public Form(
            string name,
            string description,
            string organisationId,
            long formsAppEnvironmentId,
            List<long> formsAppIds = default(List<long>),
            List<FormElement> elements = default(List<FormElement>),
            long? id = null,
            string postSubmissionAction = "FORMS_LIBRARY",
            bool isAuthenticated = true,
            List<FormSubmissionEvent> submissionEvents = default(List<FormSubmissionEvent>),
            bool isMultiPage = false,
            string redirectUrl = null,
            bool isInfoPage = false,
            List<string> tags = default(List<string>),
            DateTime? publishStartDate = null,
            DateTime? publishEndDate = null,
            string cancelAction = "BACK",
            string cancelRedirectUrl = null
            )
        {
            if (id.HasValue)
            {
                this.id = id.Value;
            }
            if (formsAppIds == default(List<long>))
            {
                this.formsAppIds = new List<long>();
            }
            else
            {
                this.formsAppIds = formsAppIds;
            }
            if (elements == default(List<FormElement>))
            {
                this.elements = new List<FormElement>();
            }
            else
            {
                this.elements = elements;
            }
            this.name = name;
            this.organisationId = organisationId;
            this.postSubmissionAction = postSubmissionAction;
            this.formsAppEnvironmentId = formsAppEnvironmentId;
            this.isAuthenticated = isAuthenticated;
            if (submissionEvents == default(List<FormSubmissionEvent>))
            {
                this.submissionEvents = new List<FormSubmissionEvent>();
            }
            else
            {
                this.submissionEvents = submissionEvents;
            }
            this.submissionEvents = submissionEvents;
            this.isMultiPage = isMultiPage;
            this.redirectUrl = redirectUrl;
            this.isInfoPage = isInfoPage;
            if (tags == default(List<string>))
            {
                this.tags = new List<string>();
            }
            else
            {
                this.tags = tags;
            }
            if (publishStartDate.HasValue)
            {
                this.publishStartDate = publishStartDate.Value;
            }
            if (publishEndDate.HasValue)
            {
                this.publishEndDate = publishEndDate.Value;
            }
            this.cancelAction = cancelAction;
            this.cancelRedirectUrl = cancelRedirectUrl;
        }
        private string[] AllowedPostSubmissionActions = new string[] { "BACK", "URL", "CLOSE", "FORMS_LIBRARY" };
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string organisationId { get; set; }
        public List<FormElement> elements { get; set; }
        public bool isAuthenticated { get; set; }
        public List<FormSubmissionEvent> submissionEvents { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isMultiPage { get; set; }
        private string _PostSubmissionAction;
        public string postSubmissionAction
        {
            get
            {
                return _PostSubmissionAction;
            }
            set
            {
                if (!AllowedPostSubmissionActions.Any(x => x == value))
                {
                    throw new ArgumentException(value + " not a valid post submission action");
                }
                _PostSubmissionAction = value;
            }
        }
        public string redirectUrl { get; set; }
        public bool isInfoPage { get; set; }
        public List<long> formsAppIds { get; set; }
        public long formsAppEnvironmentId { get; set; }
        public List<string> tags { get; set; }
        public DateTime? publishStartDate { get; set; }
        public DateTime? publishEndDate { get; set; }
        private string _CancelAction;
        public string cancelAction
        {
            get
            {
                return _CancelAction;
            }
            set
            {
                if (!AllowedPostSubmissionActions.Any(x => x == value))
                {
                    throw new ArgumentException(value + " not a valid cancel action");
                }
                _CancelAction = value;
            }
        }
        public string cancelRedirectUrl { get; set; }
    }
}