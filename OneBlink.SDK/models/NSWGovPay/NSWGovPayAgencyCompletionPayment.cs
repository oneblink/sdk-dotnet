namespace OneBlink.SDK.Model
{
    public class NSWGovPayAgencyCompletionPayment
    {
        public string paymentMethod
        {
            get; set;
        }
        public string paymentReference
        {
            get; set;
        }
        public string paymentCompletionReference
        {
            get; set;
        }
        public string bankReference
        {
            get; set;
        }
        public double? amount
        {
            get; set;
        }
        public double? surcharge
        {
            get; set;
        }
        public double? surchargeGst
        {
            get; set;
        }
        public string agencyTransactionId
        {
            get; set;
        }
        public string accountToken
        {
            get; set;
        }
        public string emailAddress
        {
            get; set;
        }
        public NSWGovPayCard card
        {
            get; set;
        }
        public NSWGovPayBPay bPay
        {
            get; set;
        }
    }
}
