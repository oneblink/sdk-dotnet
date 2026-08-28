#pragma warning disable IDE1006 // Naming is dictated by OneBlink API

namespace OneBlink.SDK.Model
{
    public class SchedulingBooking
    {
        public string submissionId
        {
            get; set;
        }
        public long formId
        {
            get; set;
        }
        public string schedulingReceiptUrl
        {
            get; set;
        }
        public string schedulingCancelUrl
        {
            get; set;
        }
        public long nylasSchedulingPageId
        {
            get; set;
        }
        public string nylasCalendarId
        {
            get; set;
        }
        public string nylasEditHash
        {
            get; set;
        }
        public string nylasProposedEventId
        {
            get; set;
        }
        public string emailAddress
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string location
        {
            get; set;
        }
        public long? startTime
        {
            get; set;
        }
        public long? endTime
        {
            get; set;
        }
        public long? previousStartTime
        {
            get; set;
        }
        public long? previousEndTime
        {
            get; set;
        }
        public string timezone
        {
            get; set;
        }
        public string cancelledReason
        {
            get; set;
        }
        public string createdAt
        {
            get; set;
        }
        public string updatedAt
        {
            get; set;
        }
    }
}