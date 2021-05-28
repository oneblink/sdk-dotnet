using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsListStyles : FormsAppStylesBase
    {
        public string logoUrl {get;set;}
        public List<FormsAppMenuItems> menuItems {get;set;}
        public FormsListStylesButtons buttons {get;set;}
    }
}