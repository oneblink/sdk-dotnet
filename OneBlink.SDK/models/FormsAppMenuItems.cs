using System;
using System.Linq;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsAppMenuItems
    {
        private string[] AllowedMenuItemTypes = new string[]
        {
            "FORMS_LIST",
            "JOBS",
            "DRAFTS",
            "PENDING_SUBMISSIONS",
            "PROFILE",
            "HREF",
            "CONTAINER",
            "FORM"
        };
        public string label { get; set; }
        public string icon { get; set; }
        private string _Type;
        public string type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (!AllowedMenuItemTypes.Any(x => x == value))
                {
                    throw new ArgumentException(value + " not a valid menu item type");

                }
                _Type = value;
            }
        }
        public bool isHidden { get; set; }
        public bool isDefault { get; set; }
        public string href { get; set; }
        public List<long> formIds { get; set; }
        public long formId { get; set; }
    }
}