using System;

namespace OneBlink.SDK.Model
{
    public class SendingAddressBase
    {
        public string emailAddress
        {
            get; set;
        }
        public string emailName
        {
            get; set;
        }
        public SesVerificationAttributes sesVerificationAttributes
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
    }

    public class NewFormsAppSendingAddress
    {
        public NewFormsAppSendingAddress(string emailAddress = null, string emailName = null)
        {
            this.emailAddress = emailAddress;
            this.emailName = emailName;
        }
        public string emailAddress
        {
            get; set;
        }
        public string emailName
        {
            get; set;
        }
    }

    public class FormsAppSendingAddress : SendingAddressBase
    {
        public long formsAppId
        {
            get; set;
        }
    }

    public class SesVerificationAttributes
    {
        string VerificationStatus
        {
            get; set;
        }
    }
}