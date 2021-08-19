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
        public FormSubmissionEventConfigration configuration
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
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
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
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
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
            bool requiresAllConditionallyExecutePredicates = false)
        {
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
            fseconfig.environmentId = environmentId;
            fseconfig.recordTitle = recordTitle;
            fseconfig.container = container;
            fseconfig.recordType = recordType;
            fseconfig.actionDefinition = actionDefinition;
            fseconfig.location = location;
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
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
            fseconfig.elementId = elementId;
            fseconfig.environmentId = environmentId;
            fseconfig.customerReferenceNumber = customerReferenceNumber;
            FormSubmissionEvent westpacQuickWeb = new FormSubmissionEvent();
            westpacQuickWeb.type = "WESTPAC_QUICK_WEB";
            westpacQuickWeb.isDraft = isDraft;
            westpacQuickWeb.configuration = fseconfig;
            return westpacQuickWeb;
        }

        public static FormSubmissionEvent CreateCivicaCrmSubmissionEvent(Guid environmentId,
            FormSubmissionEventCivicaCustomerContactMethod civicaCustomerContactMethod, FormSubmissionEventCivicaRecord civicaCategory,
            List<FormSubmissionEventCivicaElementMapping> mapping,
            string pdfFileName = null, Boolean? includeSubmissionIdInPdf = null,
            List<string> excludedElementIds = default(List<string>), bool isDraft = false)
        {
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
            fseconfig.environmentId = environmentId;
            fseconfig.civicaCustomerContactMethod = civicaCustomerContactMethod;
            fseconfig.civicaCategory = civicaCategory;
            fseconfig.mapping = mapping;
            fseconfig.pdfFileName = pdfFileName;
            fseconfig.includeSubmissionIdInPdf = includeSubmissionIdInPdf;
            fseconfig.excludedElementIds = excludedElementIds;
            FormSubmissionEvent civicaCrm = new FormSubmissionEvent();
            civicaCrm.type = "CIVICA_CRM";
            civicaCrm.configuration = fseconfig;
            civicaCrm.isDraft = isDraft;
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
            FormSubmissionEventConfigration fseconfig = new FormSubmissionEventConfigration();
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
    }
}