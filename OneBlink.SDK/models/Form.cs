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
            List<FormSubmissionEvent> submissionEvents = null,
            bool isMultiPage = false,
            string redirectUrl = null,
            bool isInfoPage = false
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
            this.formsAppIds = formsAppIds;
            this.formsAppEnvironmentId = formsAppEnvironmentId;
            this.isAuthenticated = isAuthenticated;
            this.submissionEvents = submissionEvents;
            this.isMultiPage = isMultiPage;
            this.redirectUrl = redirectUrl;
            this.isInfoPage = isInfoPage;
        }
        private string[] AllowedPostSubmissionActions = new string[] { "URL", "CLOSE", "FORMS_LIBRARY" };
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string organisationId { get; set; }
        public List<FormElement> elements { get; set; }
        public bool isAuthenticated { get; set; }
        public List<FormSubmissionEvent> submissionEvents { get; set; }
        public bool isPublished { get; set; }
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
    }
}