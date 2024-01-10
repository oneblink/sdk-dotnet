using System;
using System.Linq;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionEvent
    {
        public long id
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
        public FormSubmissionEventConfiguration configuration
        {
            get; set;
        }

        public List<ConditionallyShowPredicate> conditionallyExecutePredicates
        {
            get; set;
        }
        public bool conditionallyExecute
        {
            get; set;
        }
        public bool requiresAllConditionallyExecutePredicates
        {
            get; set;
        }

        public static FormSubmissionEvent CreateCpPaySubmissionEvent(Guid elementId, Guid gatewayId, string label = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.gatewayId = gatewayId;
            FormSubmissionEvent cpPay = new FormSubmissionEvent();
            cpPay.type = "CP_PAY";
            cpPay.configuration = fseconfig;
            cpPay.label = label;
            return cpPay;
        }

        public static FormSubmissionEvent CreateBpointSubmissionEvent(Guid elementId, Guid environmentId, string label = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            FormSubmissionEvent bpoint = new FormSubmissionEvent();
            bpoint.type = "BPOINT";
            bpoint.configuration = fseconfig;
            bpoint.label = label;
            return bpoint;
        }

        public static FormSubmissionEvent CreateGovPaySubmissionEvent(Guid elementId, Guid primaryAgencyId, string productDescription, string label = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.primaryAgencyId = primaryAgencyId;
            fseconfig.productDescription = productDescription;
            FormSubmissionEvent govPay = new FormSubmissionEvent();
            govPay.type = "NSW_GOV_PAY";
            govPay.configuration = fseconfig;
            govPay.label = label;
            return govPay;
        }

        public static FormSubmissionEvent CreateTrimSubmissionEvent(Guid environmentId,
            string recordTitle,
            FormSubmissionEventTrimUriOption container,
            FormSubmissionEventTrimUriOption recordType,
            FormSubmissionEventTrimUriOption actionDefinition = null,
            FormSubmissionEventTrimUriOption location = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            bool groupFiles = false,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null,
            string pdfFileName = null,
            bool? includeSubmissionIdInPdf = null,
            bool? includePaymentInPdf = null,
            string label = null,
            List<string> excludedCSSClasses = default(List<string>),
            bool? includeExternalIdInPdf = null,
            string pdfSize = null
            )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.environmentId = environmentId;
            fseconfig.recordTitle = recordTitle;
            fseconfig.container = container;
            fseconfig.recordType = recordType;
            fseconfig.actionDefinition = actionDefinition;
            fseconfig.location = location;
            fseconfig.groupFiles = groupFiles;
            if (excludedElementIds != default(List<string>))
            {
                fseconfig.excludedElementIds = excludedElementIds;
            }
            fseconfig.usePagesAsBreaks = true;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            if (excludedCSSClasses != default(List<string>))
            {
                fseconfig.excludedCSSClasses = excludedCSSClasses;
            }
            fseconfig.includeExternalIdInPdf = includeExternalIdInPdf;
            fseconfig.pdfSize = pdfSize;
            FormSubmissionEvent trim = new FormSubmissionEvent();
            trim.type = "TRIM";
            trim.conditionallyExecute = conditionallyExecute;
            trim.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            trim.configuration = fseconfig;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                trim.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            trim.label = label;
            return trim;
        }

        public static FormSubmissionEvent CreateWestpacQuickWebSubmissionEvent(Guid elementId, Guid environmentId, string customerReferenceNumber, string label = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            fseconfig.customerReferenceNumber = customerReferenceNumber;
            FormSubmissionEvent westpacQuickWeb = new FormSubmissionEvent();
            westpacQuickWeb.type = "WESTPAC_QUICK_WEB";
            westpacQuickWeb.configuration = fseconfig;
            westpacQuickWeb.label = label;
            return westpacQuickWeb;
        }

        public static FormSubmissionEvent CreateCivicaCrmSubmissionEvent(
            Guid environmentId,
            FormSubmissionEventCivicaCustomerContactMethod civicaCustomerContactMethod,
            FormSubmissionEventCivicaRecord civicaCategory,
            List<FormSubmissionEventConfigurationMapping> mapping,
            string pdfFileName = null, Boolean? includeSubmissionIdInPdf = null,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            Boolean? includePaymentInPdf = null,
            string label = null,
            List<string> excludedCSSClasses = default(List<string>),
            Boolean? includeExternalIdInPdf = null,
            string pdfSize = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.environmentId = environmentId;
            fseconfig.civicaCustomerContactMethod = civicaCustomerContactMethod;
            fseconfig.civicaCategory = civicaCategory;
            fseconfig.mapping = mapping;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            if (excludedElementIds != default(List<string>))
            {
                fseconfig.excludedElementIds = excludedElementIds;
            }
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            if (excludedCSSClasses != default(List<string>))
            {
                fseconfig.excludedCSSClasses = excludedCSSClasses;
            }
            fseconfig.includeExternalIdInPdf = includeExternalIdInPdf;
            fseconfig.pdfSize = pdfSize;
            FormSubmissionEvent civicaCrm = new FormSubmissionEvent();
            civicaCrm.type = "CIVICA_CRM";
            civicaCrm.configuration = fseconfig;
            civicaCrm.conditionallyExecute = conditionallyExecute;
            civicaCrm.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                civicaCrm.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            civicaCrm.label = label;
            return civicaCrm;
        }

        public static FormSubmissionEvent CreateSchedulingSubmissionEvent(
            string nylasAccountId,
            long nylasSchedulingPageId,
            Guid? nameElementId = null,
            Guid? emailElementId = null,
            string emailDescription = null,
            string label = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.nylasAccountId = nylasAccountId;
            fseconfig.nylasSchedulingPageId = nylasSchedulingPageId;
            fseconfig.nameElementId = nameElementId;
            fseconfig.emailElementId = emailElementId;
            fseconfig.emailDescription = emailDescription;
            FormSubmissionEvent schedulingEvent = new FormSubmissionEvent();
            schedulingEvent.type = "SCHEDULING";
            schedulingEvent.configuration = fseconfig;
            schedulingEvent.label = label;
            return schedulingEvent;
        }

        [Obsolete("Using CreatePDFSubmissionEvent() with the 'email' parameter is obsolete. Call CreatePDFSubmissionEvent() without the 'email' parameter instead.")]
        public static FormSubmissionEvent CreatePDFSubmissionEvent(
            string email,
            string emailSubjectLine = null,
            string pdfFileName = null,
            bool? includeSubmissionIdInPdf = null,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null,
            FormSubmissionEventEmailTemplate emailTemplate = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            bool? includePaymentInPdf = null,
            string label = null,
            List<string> toEmail = default(List<string>),
            List<string> ccEmail = default(List<string>),
            List<string> bccEmail = default(List<string>),
            bool? includeExternalIdInPdf = null,
            EndpointConfiguration emailAttachmentsEndpoint = null,
            string pdfSize = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.email = email;
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            fseconfig.excludedElementIds = excludedElementIds;
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            fseconfig.emailTemplate = emailTemplate;
            fseconfig.emailAttachmentsEndpoint = emailAttachmentsEndpoint;
            if (toEmail != default(List<string>))
            {
                fseconfig.toEmail = toEmail;
            }
            if (ccEmail != default(List<string>))
            {
                fseconfig.ccEmail = ccEmail;
            }
            if (bccEmail != default(List<string>))
            {
                fseconfig.bccEmail = bccEmail;
            }
            fseconfig.includeExternalIdInPdf = includeExternalIdInPdf;
            fseconfig.pdfSize = pdfSize;
            FormSubmissionEvent pdfEvent = new FormSubmissionEvent();
            pdfEvent.type = "PDF";
            pdfEvent.configuration = fseconfig;
            pdfEvent.conditionallyExecute = conditionallyExecute;
            pdfEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                pdfEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            pdfEvent.label = label;

            return pdfEvent;
        }

        public static FormSubmissionEvent CreatePDFSubmissionEvent(
            string emailSubjectLine = null,
            string pdfFileName = null,
            bool? includeSubmissionIdInPdf = null,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null,
            FormSubmissionEventEmailTemplate emailTemplate = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            bool? includePaymentInPdf = null,
            string label = null,
            List<string> toEmail = default(List<string>),
            List<string> ccEmail = default(List<string>),
            List<string> bccEmail = default(List<string>),
            List<string> excludedCSSClasses = default(List<string>),
            bool? includeExternalIdInPdf = null,
            EndpointConfiguration emailAttachmentsEndpoint = null,
            string pdfSize = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            if (excludedElementIds != default(List<string>))
            {
                fseconfig.excludedElementIds = excludedElementIds;
            }
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            fseconfig.emailTemplate = emailTemplate;
            if (excludedCSSClasses != default(List<string>))
            {
                fseconfig.excludedCSSClasses = excludedCSSClasses;
            }
            if (toEmail != default(List<string>))
            {
                fseconfig.toEmail = toEmail;
            }
            if (ccEmail != default(List<string>))
            {
                fseconfig.ccEmail = ccEmail;
            }
            if (bccEmail != default(List<string>))
            {
                fseconfig.bccEmail = bccEmail;
            }
            fseconfig.includeExternalIdInPdf = includeExternalIdInPdf;
            fseconfig.emailAttachmentsEndpoint = emailAttachmentsEndpoint;
            fseconfig.pdfSize = pdfSize;
            FormSubmissionEvent pdfEvent = new FormSubmissionEvent();
            pdfEvent.type = "PDF";
            pdfEvent.configuration = fseconfig;
            pdfEvent.conditionallyExecute = conditionallyExecute;
            pdfEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                pdfEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            pdfEvent.label = label;

            return pdfEvent;
        }

        [Obsolete("Using CreateEmailSubmissionEvent() with the 'email' parameter is obsolete. Call CreateEmailSubmissionEvent() without the 'email' parameter instead.")]
        public static FormSubmissionEvent CreateEmailSubmissionEvent(
            string email,
            string emailSubjectLine = null,
            FormSubmissionEventEmailTemplate emailTemplate = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            string label = null,
            List<string> toEmail = default(List<string>),
            List<string> ccEmail = default(List<string>),
            List<string> bccEmail = default(List<string>),
            EndpointConfiguration emailAttachmentsEndpoint = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.email = email;
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.emailTemplate = emailTemplate;
            if (toEmail != default(List<string>))
            {
                fseconfig.toEmail = toEmail;
            }
            if (ccEmail != default(List<string>))
            {
                fseconfig.ccEmail = ccEmail;
            }
            if (bccEmail != default(List<string>))
            {
                fseconfig.bccEmail = bccEmail;
            }
            fseconfig.emailAttachmentsEndpoint = emailAttachmentsEndpoint;
            FormSubmissionEvent emailEvent = new FormSubmissionEvent();
            emailEvent.type = "EMAIL";
            emailEvent.configuration = fseconfig;
            emailEvent.conditionallyExecute = conditionallyExecute;
            emailEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                emailEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            emailEvent.label = label;

            return emailEvent;
        }

        public static FormSubmissionEvent CreateEmailSubmissionEvent(
            string emailSubjectLine = null,
            FormSubmissionEventEmailTemplate emailTemplate = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            string label = null,
            List<string> toEmail = default(List<string>),
            List<string> ccEmail = default(List<string>),
            List<string> bccEmail = default(List<string>),
            EndpointConfiguration emailAttachmentsEndpoint = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.emailTemplate = emailTemplate;
            if (toEmail != default(List<string>))
            {
                fseconfig.toEmail = toEmail;
            }
            if (ccEmail != default(List<string>))
            {
                fseconfig.ccEmail = ccEmail;
            }
            if (bccEmail != default(List<string>))
            {
                fseconfig.bccEmail = bccEmail;
            }
            fseconfig.emailAttachmentsEndpoint = emailAttachmentsEndpoint;
            FormSubmissionEvent emailEvent = new FormSubmissionEvent();
            emailEvent.type = "EMAIL";
            emailEvent.configuration = fseconfig;
            emailEvent.conditionallyExecute = conditionallyExecute;
            emailEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                emailEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            emailEvent.label = label;

            return emailEvent;
        }

        public static FormSubmissionEvent CreateFreshdeskTicketSubmissionEvent(
            string type,
            List<FormSubmissionEventConfigurationMapping> mapping,
            bool conditionallyExecute,
            bool requiresAllConditionallyExecutePredicates,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            string label = null
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.mapping = mapping;
            FormSubmissionEvent freshdeskCreateTicketEvent = new FormSubmissionEvent();
            freshdeskCreateTicketEvent.configuration = fseconfig;
            freshdeskCreateTicketEvent.conditionallyExecute = conditionallyExecute;
            freshdeskCreateTicketEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                freshdeskCreateTicketEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            freshdeskCreateTicketEvent.label = label;

            return freshdeskCreateTicketEvent;
        }
    }
}