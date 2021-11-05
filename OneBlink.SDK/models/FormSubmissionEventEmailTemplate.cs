using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionEventEmailTemplate
    {
        public long id
        {
            get; set;
        }
        public List<FormSubmissionEventEmailTemplateMapping> mapping
        {
            get; set;
        }
    }
}