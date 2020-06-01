using System;
using System.Linq;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionEvent
    {
        private string[] AllowedSubmissionEventTypes = new string[]
        {
            "PDF",
            "CALLBACK",
            "SPOTTO",
            "ONEBLINK_API",
            "TRIM",
            "CP_PAY",
            "CP_HCMS",
            "BPOINT"
        };
        public long id { get; set; }
        private string _Type;
        public string type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (!AllowedSubmissionEventTypes.Any(x => x == value))
                {
                    throw new ArgumentException(value + " not a valid submission event type");
                }
                _Type = value;
            }
        }
        public FormSubmissionEventConfigration configuration { get; set; }
        public bool isDraft { get; set; }
    }
}