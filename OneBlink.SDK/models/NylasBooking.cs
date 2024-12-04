using System;

namespace OneBlink.SDK.Model
{
    public class NylasBooking
    {
        public string bookingRef
        {
            get; set;
        }
        public string bookingId
        {
            get; set;
        }
        public string calendarId
        {
            get; set;
        }
        public string grantId
        {
            get; set;
        }
        public string proposedEventId
        {
            get; set;
        }
        public long startTime
        {
            get; set;
        }
        public long endTime
        {
            get; set;
        }

        public string timezone
        {
            get; set;
        }
        public string location
        {
            get; set;
        }
        public long previousStartTime
        {
            get; set;
        }
        public long previousEndTime
        {
            get; set;
        }

        public string cancelledReason
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
}