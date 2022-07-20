using System;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionWorkflowEvent
    {
        public long id
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public DateTime startedAt
        {
            get; set;
        }
        public DateTime finishedAt
        {
            get; set;
        }
        public long formId
        {
            get; set;
        }
        public string status
        {
            get; set;
        }
        public string error
        {
            get; set;
        }
        public Guid submissionId
        {
            get; set;
        }
        public Guid draftId
        {
            get; set;
        }
        public string stage
        {
            get; set;
        }
        public FormEvent @event
        {
            get; set;
        }

    }
}