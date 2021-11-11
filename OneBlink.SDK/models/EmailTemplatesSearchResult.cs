using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class EmailTemplatesSearchResult : SearchResult
    {
        public List<EmailTemplate> emailTemplates
        {
            get; set;
        }
    }
}