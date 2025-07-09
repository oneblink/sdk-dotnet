using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsListStyles : FormsAppEnvironmentStyles
    {
        public List<FormsAppMenuItems> menuItems
        {
            get; set;
        }
        public FormsAppFooter footer
        {
            get; set;
        }
    }
}