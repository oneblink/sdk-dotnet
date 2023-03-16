using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionEventConfiguration
    {
        public string url
        {
            get; set;
        }
        public string recordTitle
        {
            get; set;
        }
        public FormSubmissionEventTrimUriOption container
        {
            get; set;
        }
        public string username
        {
            get; set;
        }
        public string password
        {
            get; set;
        }
        public FormSubmissionEventTrimUriOption recordType
        {
            get; set;
        }
        public FormSubmissionEventTrimUriOption actionDefinition
        {
            get; set;
        }
        public FormSubmissionEventTrimUriOption location
        {
            get; set;
        }
        public string secret
        {
            get; set;
        }
        public string emailSubjectLine
        {
            get; set;
        }
        public string pdfFileName
        {
            get; set;
        }
        public string apiId
        {
            get; set;
        }
        public string apiEnvironment
        {
            get; set;
        }
        public string apiEnvironmentRoute
        {
            get; set;
        }
        public Guid? elementId
        {
            get; set;
        }
        public string contentTypeName
        {
            get; set;
        }
        public Guid? gatewayId
        {
            get; set;
        }
        public Guid? environmentId
        {
            get; set;
        }
        public string crn2
        {
            get; set;
        }
        public string crn3
        {
            get; set;
        }
        public Boolean? includeSubmissionIdInPdf
        {
            get; set;
        }
        public Boolean? includePaymentInPdf
        {
            get; set;
        }

        public List<string> encryptedElementIds
        {
            get; set;
        }
        public List<string> excludedElementIds
        {
            get; set;
        }
        public FormSubmissionEventTrimUriOption author
        {
            get; set;
        }
        public bool? encryptPdf
        {
            get; set;
        }
        public string customerReferenceNumber
        {
            get; set;
        }
        public FormSubmissionEventCivicaCustomerContactMethod civicaCustomerContactMethod
        {
            get; set;
        }
        public FormSubmissionEventCivicaRecord civicaCategory
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationMapping> mapping
        {
            get; set;
        }
        public string nylasAccountId
        {
            get; set;
        }
        public long? nylasSchedulingPageId
        {
            get; set;
        }
        public Guid? nameElementId
        {
            get; set;
        }
        public Guid? emailElementId
        {
            get; set;
        }
        public string emailDescription
        {
            get; set;
        }
        public bool? groupFiles
        {
            get; set;
        }
        public bool? usePagesAsBreaks
        {
            get; set;
        }
        public FormSubmissionEventEmailTemplate emailTemplate
        {
            get; set;
        }

        public ApprovalFormsInclusionConfiguration approvalFormsInclusion
        {
            get; set;
        }

        public List<string> toEmail
        {
            get; set;
        }
        public List<string> ccEmail
        {
            get; set;
        }
        public List<string> bccEmail
        {
            get; set;
        }
    }
}