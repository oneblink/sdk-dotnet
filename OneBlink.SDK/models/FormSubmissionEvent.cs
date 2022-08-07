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

        public static FormSubmissionEvent CreateCpPaySubmissionEvent(Guid elementId, Guid gatewayId)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.gatewayId = gatewayId;
            FormSubmissionEvent cpPay = new FormSubmissionEvent();
            cpPay.type = "CP_PAY";
            cpPay.configuration = fseconfig;
            return cpPay;
        }

        public static FormSubmissionEvent CreateBpointSubmissionEvent(Guid elementId, Guid environmentId)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            FormSubmissionEvent bpoint = new FormSubmissionEvent();
            bpoint.type = "BPOINT";
            bpoint.configuration = fseconfig;
            return bpoint;
        }

        public static FormSubmissionEvent CreateTrimSubmissionEvent(Guid environmentId,
            string recordTitle,
            FormSubmissionEventTrimUriOption container,
            FormSubmissionEventTrimUriOption recordType,
            FormSubmissionEventTrimUriOption actionDefinition,
            FormSubmissionEventTrimUriOption location,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            bool groupFiles = false,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null,
            string pdfFileName = null,
            bool? includeSubmissionIdInPdf = null,
            bool? includePaymentInPdf = null
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
            fseconfig.excludedElementIds = excludedElementIds;
            fseconfig.usePagesAsBreaks = true;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            FormSubmissionEvent trim = new FormSubmissionEvent();
            trim.type = "TRIM";
            trim.conditionallyExecute = conditionallyExecute;
            trim.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            trim.configuration = fseconfig;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                trim.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            return trim;
        }

        public static FormSubmissionEvent CreateWestpacQuickWebSubmissionEvent(Guid elementId, Guid environmentId, string customerReferenceNumber)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            fseconfig.customerReferenceNumber = customerReferenceNumber;
            FormSubmissionEvent westpacQuickWeb = new FormSubmissionEvent();
            westpacQuickWeb.type = "WESTPAC_QUICK_WEB";
            westpacQuickWeb.configuration = fseconfig;
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
            bool requiresAllConditionallyExecutePredicates = false, Boolean? includePaymentInPdf = null)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.environmentId = environmentId;
            fseconfig.civicaCustomerContactMethod = civicaCustomerContactMethod;
            fseconfig.civicaCategory = civicaCategory;
            fseconfig.mapping = mapping;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.includePaymentInPdf = includePaymentInPdf;
            fseconfig.excludedElementIds = excludedElementIds;
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            FormSubmissionEvent civicaCrm = new FormSubmissionEvent();
            civicaCrm.type = "CIVICA_CRM";
            civicaCrm.configuration = fseconfig;
            civicaCrm.conditionallyExecute = conditionallyExecute;
            civicaCrm.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                civicaCrm.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            return civicaCrm;
        }

        public static FormSubmissionEvent CreateSchedulingSubmissionEvent(
            string nylasAccountId,
            long nylasSchedulingPageId,
            Guid? nameElementId = null,
            Guid? emailElementId = null,
            string emailDescription = null
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
            return schedulingEvent;
        }

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
            bool? includePaymentInPdf = null
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
            FormSubmissionEvent pdfEvent = new FormSubmissionEvent();
            pdfEvent.type = "PDF";
            pdfEvent.configuration = fseconfig;
            pdfEvent.conditionallyExecute = conditionallyExecute;
            pdfEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                pdfEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }

            return pdfEvent;
        }

        public static FormSubmissionEvent CreateEmailSubmissionEvent(
            string email,
            string emailSubjectLine = null,
            FormSubmissionEventEmailTemplate emailTemplate = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.email = email;
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.emailTemplate = emailTemplate;
            FormSubmissionEvent emailEvent = new FormSubmissionEvent();
            emailEvent.type = "EMAIL";
            emailEvent.configuration = fseconfig;
            emailEvent.conditionallyExecute = conditionallyExecute;
            emailEvent.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                emailEvent.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }

            return emailEvent;
        }

        public static FormSubmissionEvent CreateFreshdeskTicketSubmissionEvent(
            string type,
            List<FormSubmissionEventConfigurationMapping> mapping,
            bool conditionallyExecute,
            bool requiresAllConditionallyExecutePredicates,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>)
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

            return freshdeskCreateTicketEvent;
        }
    }
}