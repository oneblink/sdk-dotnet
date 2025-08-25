using System;

namespace OneBlink.SDK.Model
{
    public class NewFormsAppEnvironmentSendingAddress : NewFormsAppSendingAddress
    {

    }

    public class FormsAppEnvironmentSendingAddress : SendingAddressBase
    {
        public long formsAppEnvironmentId
        {
            get; set;
        }
    }
}