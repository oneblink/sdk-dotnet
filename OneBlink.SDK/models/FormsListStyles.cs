using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsListStyles : FormsAppEnvironmentStyles
    {
        public List<FormsAppMenuItem> menuItems
        {
            get; set;
        }
        public FormsAppFooter footer
        {
            get; set;
        }
    }
}