using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class FormStoreFormsApp : FormsAppBase
    {
        public FormStoreFormsApp()
        {
            this.type = "FORM_STORE";
        }
        public FormsAppStylesBase styles
        {
            get; set;
        }
        public List<FormStoreForm> forms
        {
            get; set;
        }
    }
}