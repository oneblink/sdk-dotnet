using System;

namespace OneBlink.SDK.Model
{
    public class CPPayTransactionDetails
    {
        public string type
        {
            get; set;
        }
        public string id
        {
            get; set;
        }
        public string token
        {
            get; set;
        }
        public string state
        {
            get; set;
        }
        public string externalReferenceId
        {
            get; set;
        }
        public string merchantCode
        {
            get; set;
        }
        public string paymentMethodType
        {
            get; set;
        }
        public string lastFour
        {
            get; set;
        }
        public int? expMonth
        {
            get; set;
        }
        public int? expYear
        {
            get; set;
        }
        public string paymentType
        {
            get; set;
        }
        public double? amount
        {
            get; set;
        }
        public string responseType
        {
            get; set;
        }
        public string errorCode
        {
            get; set;
        }
        public string customerReceipt
        {
            get; set;
        }
        public string merchantReceipt
        {
            get; set;
        }
        public string customerSignatureFormat
        {
            get; set;
        }
        public string customerSignature
        {
            get; set;
        }
        public string savedPaymentMethodToken
        {
            get; set;
        }
        public bool isSuccessSavedPaymentMethod
        {
            get; set;
        }
        public DateTime? createdOnUtc
        {
            get; set;
        }
        public DateTime? lastModifiedOnUtc
        {
            get; set;
        }
    }
}
