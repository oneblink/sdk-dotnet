namespace OneBlink.SDK.Model
{
    public class CPPayTransactionLinks
    {
        public CPPayActionLink details
        {
            get; set;
        }
        public CPPayActionLink capture
        {
            get; set;
        }
        public CPPayActionLink @void
        {
            get; set;
        }
        public CPPayActionLink refund
        {
            get; set;
        }
    }
}
