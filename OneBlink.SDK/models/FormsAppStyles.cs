using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsAppStyles
    {
        public string foregroundColour { get; set; }
        public string highlightColour { get; set; }
        public string contrastColour { get; set; }
        public string logoUrl { get; set; }
        public string customCss { get; set; }
        public List<FormsAppMenuItems> menuItems { get; set; }
    }
}