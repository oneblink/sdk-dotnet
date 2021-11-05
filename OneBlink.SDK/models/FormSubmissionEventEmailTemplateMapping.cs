using System;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionEventEmailTemplateMapping
    {
        public string mustacheTag
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public Guid? formElementId
        {
            get; set;
        }
        public string text
        {
            get; set;
        }
    }
}