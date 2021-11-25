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
        public FormSubmissionEventConfiguration configuration
        {
            get; set;
        }
        public bool isDraft
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

        public static FormSubmissionEvent CreateCpPaySubmissionEvent(Guid elementId, Guid gatewayId, bool isDraft = false)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.gatewayId = gatewayId;
            FormSubmissionEvent cpPay = new FormSubmissionEvent();
            cpPay.type = "CP_PAY";
            cpPay.isDraft = isDraft;
            cpPay.configuration = fseconfig;
            return cpPay;
        }

        public static FormSubmissionEvent CreateBpointSubmissionEvent(Guid elementId, Guid environmentId, bool isDraft = false)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            FormSubmissionEvent bpoint = new FormSubmissionEvent();
            bpoint.type = "BPOINT";
            bpoint.isDraft = isDraft;
            bpoint.configuration = fseconfig;
            return bpoint;
        }

        public static FormSubmissionEvent CreateTrimSubmissionEvent(Guid environmentId,
            string recordTitle,
            FormSubmissionEventTrimUriOption container,
            FormSubmissionEventTrimUriOption recordType,
            FormSubmissionEventTrimUriOption actionDefinition,
            FormSubmissionEventTrimUriOption location,
            bool isDraft = false,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false,
            bool groupFiles = false,
            List<string> excludedElementIds = default(List<string>),
            bool? usePagesAsBreaks = null)
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
            FormSubmissionEvent trim = new FormSubmissionEvent();
            trim.type = "TRIM";
            trim.isDraft = isDraft;
            trim.conditionallyExecute = conditionallyExecute;
            trim.requiresAllConditionallyExecutePredicates = requiresAllConditionallyExecutePredicates;
            trim.configuration = fseconfig;
            if (conditionallyExecutePredicates != default(List<ConditionallyShowPredicate>))
            {
                trim.conditionallyExecutePredicates = conditionallyExecutePredicates;
            }
            return trim;
        }

        public static FormSubmissionEvent CreateWestpacQuickWebSubmissionEvent(Guid elementId, Guid environmentId, string customerReferenceNumber, bool isDraft = false)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            fseconfig.customerReferenceNumber = customerReferenceNumber;
            FormSubmissionEvent westpacQuickWeb = new FormSubmissionEvent();
            westpacQuickWeb.type = "WESTPAC_QUICK_WEB";
            westpacQuickWeb.isDraft = isDraft;
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
            bool isDraft = false,
            bool? usePagesAsBreaks = null,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false)
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.environmentId = environmentId;
            fseconfig.civicaCustomerContactMethod = civicaCustomerContactMethod;
            fseconfig.civicaCategory = civicaCategory;
            fseconfig.mapping = mapping;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.excludedElementIds = excludedElementIds;
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            FormSubmissionEvent civicaCrm = new FormSubmissionEvent();
            civicaCrm.type = "CIVICA_CRM";
            civicaCrm.configuration = fseconfig;
            civicaCrm.isDraft = isDraft;
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
            bool isDraft = false,
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
            schedulingEvent.isDraft = isDraft;
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
            bool isDraft = false,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>),
            bool conditionallyExecute = false,
            bool requiresAllConditionallyExecutePredicates = false
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.email = email;
            fseconfig.emailSubjectLine = emailSubjectLine;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.excludedElementIds = excludedElementIds;
            fseconfig.usePagesAsBreaks = usePagesAsBreaks;
            fseconfig.emailTemplate = emailTemplate;
            FormSubmissionEvent pdfEvent = new FormSubmissionEvent();
            pdfEvent.type = "PDF";
            pdfEvent.configuration = fseconfig;
            pdfEvent.isDraft = isDraft;
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
            bool isDraft = false,
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
            emailEvent.isDraft = isDraft;
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
            bool isDraft,
            List<FormSubmissionEventConfigurationMapping> mapping,
            bool conditionallyExecute,
            bool requiresAllConditionallyExecutePredicates,
            List<ConditionallyShowPredicate> conditionallyExecutePredicates = default(List<ConditionallyShowPredicate>)
        )
        {
            FormSubmissionEventConfiguration fseconfig = new FormSubmissionEventConfiguration();
            fseconfig.mapping = mapping;
            FormSubmissionEvent freshdeskCreateTicketEvent = new FormSubmissionEvent();
            freshdeskCreateTicketEvent.isDraft = isDraft;
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