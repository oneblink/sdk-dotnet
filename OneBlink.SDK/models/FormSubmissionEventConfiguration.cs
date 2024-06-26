using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    //Being kept right now due to backwards compatability, will be deleted upon next breaking change.
    public class FormSubmissionEventConfigration : FormSubmissionEventConfiguration
    {
    }

    public class FormSubmissionEventConfiguration : PDFConfiguration
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
        [Obsolete("secret is deprecated and will always be null.")]
        public string secret
        {
            get; set;
        }
        public long? organisationManagedSecretId
        {
            get; set;
        }
        [Obsolete("use toEmail instead")]
        public string email
        {
            get; set;
        }
        public string emailSubjectLine
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
        public List<string> encryptedElementIds
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
        public FormSubmissionEventEmailTemplate emailTemplate
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
        public Guid? primaryAgencyId
        {
            get; set;
        }
        public string productDescription
        {
            get; set;
        }
        public string customerReference
        {
            get; set;
        }
        public string subAgencyCode
        {
            get; set;
        }
        public EndpointConfiguration emailAttachmentsEndpoint
        {
            get; set;
        }
        public string notificationElementId
        {
            get; set;
        }
        public List<Guid> excludedAttachmentElementIds
        {
            get; set;
        }
    }
}