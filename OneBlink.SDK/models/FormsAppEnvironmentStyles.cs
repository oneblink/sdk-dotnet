namespace OneBlink.SDK.Model
{
    public class FormsAppEnvironmentStyles : FormsAppEnvironmentStylesBase
    {
        public string logoUrl
        {
            get; set;
        }
        public FormsListStylesButtons buttons
        {
            get; set;
        }
        public FormsAppEnvironmentValidationIcon validationIcon
        {
            get; set;
        }
    }

    public class FormsAppEnvironmentValidationIcon
    {

        public string icon
        {
            get; set;
        }
        public string accessibleLabel
        {
            get; set;
        }

    }
}