namespace OneBlink.SDK.Model
{
    public class FormSubmissionApprovalNote
    {
        public string id
        {
            get; set;
        }
        public string createdAt
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails createdBy
        {
            get; set;
        }
        public string updatedAt
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails updatedBy
        {
            get; set;
        }
        public string note
        {
            get; set;
        }
    }
}