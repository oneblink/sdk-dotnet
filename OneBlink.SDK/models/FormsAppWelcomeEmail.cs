using System;

namespace OneBlink.SDK.Model
{
    public class FormsAppWelcomeEmail
    {
        [Obsolete("Use emailTemplateId instead.")]
        public string body { get; set; }
        public string subject { get; set; }
        public long? emailTemplateId { get; set; }
    }
}