#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
namespace OneBlink.SDK.Model
{
    public class TaskScheduleRecurrence
    {
        public string interval
        {
            get; set;
        }
        public string day
        {
            get; set;
        }
        public int days
        {
            get; set;
        }
    }
}