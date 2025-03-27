using System;
using System.Collections.Generic;

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
            List<long> formsAppIds = default,
            List<FormElement> elements = default,
            long? id = null,
            string postSubmissionAction = "FORMS_LIBRARY",
            bool isAuthenticated = true,
            List<FormSubmissionEvent> draftEvents = default,
            List<FormSubmissionEvent> submissionEvents = default,
            List<FormSubmissionEvent> paymentEvents = default,
            List<FormSubmissionEvent> schedulingEvents = default,
            List<FormApprovalStep> approvalSteps = null,
            List<FormSubmissionEvent> approvalEvents = default,
            bool isMultiPage = false,
            string redirectUrl = null,
            List<string> tags = default,
            DateTime? publishStartDate = null,
            DateTime? publishEndDate = null,
            string unpublishedUserMessage = null,
            string cancelAction = "BACK",
            string cancelRedirectUrl = null,
            FormServerValidation serverValidation = null,
            FormExternalIdGeneration externalIdGenerationOnSubmit = null,
            FormPersonalisation personalisation = null,
            FormApprovalConfiguration approvalConfiguration = null,
            string submissionTitle = null,
            bool continueWithAutosave = false,
            List<string> customCssClasses = default,
            Guid? pointAddressEnvironmentId = null,
            bool? allowGeoscapeAddresses = null,
            FormEnableSubmission enableSubmission = null,
            bool? disableAutosave = null,
            bool? isArchived = null
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
            this.unpublishedUserMessage = unpublishedUserMessage;
            this.cancelAction = cancelAction;
            this.cancelRedirectUrl = cancelRedirectUrl;
            this.serverValidation = serverValidation;
            this.externalIdGenerationOnSubmit = externalIdGenerationOnSubmit;
            this.personalisation = personalisation;
            this.approvalConfiguration = approvalConfiguration;
            this.submissionTitle = submissionTitle;
            this.continueWithAutosave = continueWithAutosave;
            if (customCssClasses == default(List<string>))
            {
                this.customCssClasses = new List<string>();
            }
            else
            {
                this.customCssClasses = customCssClasses;
            }
            this.pointAddressEnvironmentId = pointAddressEnvironmentId ?? null;
            this.allowGeoscapeAddresses = allowGeoscapeAddresses ?? null;
            this.enableSubmission = enableSubmission;
            this.disableAutosave = disableAutosave;
            this.isArchived = isArchived;
        }
        public long id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string slug
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
        public string unpublishedUserMessage
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
        public FormExternalIdGeneration externalIdGenerationOnSubmit
        {
            get; set;
        }
        public FormPersonalisation personalisation
        {
            get; set;
        }
        public FormPostSubmissionReceipt postSubmissionReceipt
        {
            get; set;
        }
        public string submissionTitle
        {
            get; set;
        }
        public bool continueWithAutosave
        {
            get; set;
        }
        public List<string> customCssClasses
        {
            get; set;
        }
        public Guid? pointAddressEnvironmentId
        {
            get; set;
        }
        public Guid? sharepointIntegrationEntraApplicationId
        {
            get; set;
        }
        public bool? allowGeoscapeAddresses
        {
            get; set;
        }
        public FormEnableSubmission enableSubmission
        {
            get; set;
        }
        public bool? disableAutosave
        {
            get; set;
        }
        public bool? isArchived
        {
            get; set;
        }
        public List<FormCustomPDF> customPDFs
        {
            get; set;
        }
    }
}