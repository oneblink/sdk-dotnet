using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class VolunteersFormsApp : FormsAppBase
    {
        public VolunteersFormsApp()
        {
            this.type = "VOLUNTEERS";
        }
        public FormsAppStylesBase styles {get;set;}
        public List<VolunteersFormsAppCategories> categories {get;set;}
        public string waiverUrl {get;set;}
        public override string type {get;}
    }
}