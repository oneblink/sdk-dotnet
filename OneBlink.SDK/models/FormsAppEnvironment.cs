using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormsAppEnvironment
    {
        public long id
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public DateTime updatedAt
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public string slug
        {
            get; set;
        }
        public List<string> notificationEmailAddresses
        {
            get; set;
        }
        public FormsAppEnvironmentCloneOptions cloneOptions
        {
            get; set;
        }
        public FormsAppEnvironmentStyles styles
        {
            get; set;
        }
    }
}