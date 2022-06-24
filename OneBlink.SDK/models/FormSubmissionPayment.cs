using System;
namespace OneBlink.SDK.Model
{
    public class FormSubmissionPayment
    {
        public string type
        {
            get; set;
        }
        public Guid submissionId
        {
            get; set;
        }
        public long formId
        {
            get; set;
        }
        public string status
        {
            get; set;
        }
        public PaymentTransaction paymentTransaction
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