using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class EmailTemplateEnvironment
    {

        public string template
        {
            get; set;
        }

        public long formsAppEnvironmentId
        {
            get; set;
        }

    }

    public class EmailTemplate
    {
        public string name
        {
            get; set;
        }

        public List<EmailTemplateEnvironment> environments
        {
            get; set;
        }

        public string organisationId
        {
            get; set;
        }

        public string type
        {
            get; set;
        }

        public long id
        {
            get; set;
        }

        public DateTime? createdAt
        {
            get; set;
        }

        public DateTime? updatedAt
        {
            get; set;
        }
    }
}