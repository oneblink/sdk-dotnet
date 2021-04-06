using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsListFormsApp : FormsAppBase
    {
        public string slug {get;set;}
        public List<long> formIds {get;set;}
        public FormsListStyles styles {get;set;}
    }
}