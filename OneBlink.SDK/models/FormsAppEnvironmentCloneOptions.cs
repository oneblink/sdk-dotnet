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
        public bool isCloningFormExternalIdGeneration
        {
            get; set;
        }
    }
}