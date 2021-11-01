using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionEventPdfEmailTemplate
    {
        public long id
        {
            get; set;
        }
        public List<FormSubmissionEventPdfEmailTemplateMapping> mapping
        {
            get; set;
        }
    }
}