namespace OneBlink.SDK.Model
{
    public class FormsAppEnvironmentStylesBase
    {
        public string foregroundColour
        {
            get; set;
        }
        public string highlightColour
        {
            get; set;
        }
        public string contrastColour
        {
            get; set;
        }
        public string customCss
        {
            get; set;
        }
    }

    public class FormsAppStylesBase : FormsAppEnvironmentStylesBase
    {

    }
}