using System;

namespace OneBlink.SDK.Model
{
    public class SchedulingBooking
    {
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
        public long startTime
        {
            get; set;
        }
        public long endTime
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
        public string timezone
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