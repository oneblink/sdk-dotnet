namespace OneBlink.SDK.Model
{
    public class BPointFraudScreeningResponse
    {
        public bool TxnRejected
        {
            get; set;
        }
        public string ResponseCode
        {
            get; set;
        }
        public string ResponseMessage
        {
            get; set;
        }
        public BPointReDResponse ReDResponse
        {
            get; set;
        }
    }
}