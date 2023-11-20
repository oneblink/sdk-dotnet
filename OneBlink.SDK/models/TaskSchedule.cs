#pragma warning disable IDE1006 // Naming is dictated by OneBlink API

namespace OneBlink.SDK.Model
{
    public class TaskSchedule
    {
        public string startDate
        {
            get; set;
        }
        public string endDate
        {
            get; set;
        }
        public TaskScheduleRecurrence recurrence
        {
            get; set;
        }

    }
}