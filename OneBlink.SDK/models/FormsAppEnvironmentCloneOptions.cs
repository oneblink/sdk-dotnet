namespace OneBlink.SDK.Model
{
    public class FormsAppEnvironmentCloneOptions
    {
        public long sourceFormsAppEnvironmentId
        {
            get; set;
        }
        public bool isCloningFormElementOptionsSets
        {
            get; set;
        }
        public bool isCloningFormElementLookups
        {
            get; set;
        }
        public bool isCloningFormSubmissionEvents
        {
            get; set;
        }
        public bool isCloningFormPostSubmissionActions
        {
            get; set;
        }
        public bool isCloningFormServerValidation
        {
            get; set;
        }
        public bool isCloningFormExternalIdGenerationOnSubmit
        {
            get; set;
        }
        public bool isCloningFormPersonalisation
        {
            get; set;
        }
        public bool isCloningFormApprovalSteps
        {
            get; set;
        }
        public bool isCloningFormGoogleMapsIntegrationEnvironmentId
        {
            get; set;
        }
    }
}