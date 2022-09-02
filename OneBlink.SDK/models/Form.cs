using System;
using System.Collections.Generic;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class Form
    {
        public Form()
        {
        }

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
            List<FormSubmissionEvent> draftEvents = default(List<FormSubmissionEvent>),
            List<FormSubmissionEvent> submissionEvents = default(List<FormSubmissionEvent>),
            List<FormSubmissionEvent> paymentEvents = default(List<FormSubmissionEvent>),
            List<FormSubmissionEvent> schedulingEvents = default(List<FormSubmissionEvent>),
            List<FormApprovalStep> approvalSteps = null,
            List<FormSubmissionEvent> approvalEvents = default(List<FormSubmissionEvent>),
            bool isMultiPage = false,
            string redirectUrl = null,
            bool isInfoPage = false,
            List<string> tags = default(List<string>),
            DateTime? publishStartDate = null,
            DateTime? publishEndDate = null,
            string cancelAction = "BACK",
            string cancelRedirectUrl = null,
            FormServerValidation serverValidation = null,
            FormServerValidation externalIdGeneration = null,
            FormApprovalConfiguration approvalConfiguration = null
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
            this.description = description;
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
            if (draftEvents == default(List<FormSubmissionEvent>))
            {
                this.draftEvents = new List<FormSubmissionEvent>();
            }
            else
            {
                this.draftEvents = draftEvents;
            }
            if (paymentEvents == default(List<FormSubmissionEvent>))
            {
                this.paymentEvents = new List<FormSubmissionEvent>();
            }
            else
            {
                this.paymentEvents = paymentEvents;
            }
            if (schedulingEvents == default(List<FormSubmissionEvent>))
            {
                this.schedulingEvents = new List<FormSubmissionEvent>();
            }
            else
            {
                this.schedulingEvents = schedulingEvents;
            }
            if (approvalEvents == default(List<FormSubmissionEvent>))
            {
                this.approvalEvents = new List<FormSubmissionEvent>();
            }
            else
            {
                this.approvalEvents = approvalEvents;
            }
            if (approvalSteps != null)
            {
                this.approvalSteps = approvalSteps;
            }
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
            this.serverValidation = serverValidation;
            this.externalIdGeneration = externalIdGeneration;
            this.approvalConfiguration = approvalConfiguration;
        }
        public long id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public List<FormElement> elements
        {
            get; set;
        }
        public bool isAuthenticated
        {
            get; set;
        }
        public List<FormSubmissionEvent> draftEvents
        {
            get; set;
        }
        public List<FormSubmissionEvent> schedulingEvents
        {
            get; set;
        }
        public List<FormSubmissionEvent> paymentEvents
        {
            get; set;
        }
        public List<FormApprovalStep> approvalSteps
        {
            get; set;
        }
        public List<FormSubmissionEvent> approvalEvents
        {
            get; set;
        }
        public FormApprovalConfiguration approvalConfiguration
        {
            get; set;
        }
        public List<FormSubmissionEvent> submissionEvents
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public DateTime updatedAt
        {
            get; set;
        }
        public bool isMultiPage
        {
            get; set;
        }
        public string postSubmissionAction
        {
            get; set;
        }
        public string redirectUrl
        {
            get; set;
        }
        public bool isInfoPage
        {
            get; set;
        }
        public List<long> formsAppIds
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public List<string> tags
        {
            get; set;
        }
        public DateTime? publishStartDate
        {
            get; set;
        }
        public DateTime? publishEndDate
        {
            get; set;
        }
        public string cancelAction
        {
            get; set;
        }
        public string cancelRedirectUrl
        {
            get; set;
        }
        public FormServerValidation serverValidation
        {
            get; set;
        }
        public FormServerValidation externalIdGeneration
        {
            get; set;
        }
    }
}