using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsListFormsApp : FormsAppBase
    {
        public FormsListFormsApp()
        {
            this.type = "FORMS_LIST";
        }
        public string slug {get;set;}
        public List<long> formIds {get;set;}
        public FormsListStyles styles {get;set;}
        public override string type {get;}
    }
}