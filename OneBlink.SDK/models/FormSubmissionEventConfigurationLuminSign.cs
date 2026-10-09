using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionEventConfigurationLuminSign
    {
        public FormSubmissionEventConfigurationLuminSignTemplate template
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationLuminSignSigner> signers
        {
            get; set;
        }
        public FormSubmissionEventConfigurationMapping title
        {
            get; set;
        }
        public FormSubmissionEventConfigurationMapping expiresAt
        {
            get; set;
        }
        public FormSubmissionEventConfigurationMapping emailSubject
        {
            get; set;
        }
        public FormSubmissionEventConfigurationMapping emailTitle
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationMapping> mergeTagMapping
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationMapping> fieldMapping
        {
            get; set;
        }
        public List<FormSubmissionEventConfigurationMapping> variableMapping
        {
            get; set;
        }
    }
}
