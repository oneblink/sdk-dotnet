namespace OneBlink.SDK.Model
{
    public class FormMigrationOptions
    {
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public long sourceFormId
        {
            get; set;
        }
        public long? targetFormId
        {
            get; set;
        }
        public bool elements
        {
            get; set;
        }
        public bool submissionEvents
        {
            get; set;
        }
        public bool serverValidation
        {
            get; set;
        }
        public bool externalIdGenerationOnSubmit
        {
            get; set;
        }
        public bool personalisation
        {
            get; set;
        }
        public bool postSubmissionAction
        {
            get; set;
        }
        public bool approvalSteps
        {
            get; set;
        }
        public long? versionId
        {
            get; set;
        }
    }
}