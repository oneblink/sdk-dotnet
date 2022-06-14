using System;
namespace OneBlink.SDK.Model
{

    public class FormSubmissionEventConfigurationMapping
    {
        public dynamic value
        {
            get; set;
        }

        public long civicaCategoryItemNumber
        {
            get; set;
        }
        public Guid formElementId
        {
            get; set;
        }
        public bool isDescription
        {
            get; set;
        }
        public FormSubmissionEventConfigurationMappingDependentFieldValue dependentFieldValue
        {
            get; set;
        }
    }
    //Kept here for backwards compatability, remove with next breaking change.
    public class FormSubmissionEventCivicaElementMapping : FormSubmissionEventConfigurationMapping
    {
    }
}