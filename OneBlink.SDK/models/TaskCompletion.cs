#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class CompletedTask
    {
        public string id
        {
            get; set;
        }
        public long formsAppId
        {
            get; set;
        }
        public long taskVersionId
        {
            get; set;
        }
        public long? taskGroupVersionId
        {
            get; set;
        }
        public long? taskActionVersionId
        {
            get; set;
        }
        public long? taskGroupInstanceVersionId
        {
            get; set;
        }
        public string submissionId
        {
            get; set;
        }
        public FormSubmissionMetaUserDetails completedBy
        {
            get; set;
        }
        public FormSubmissionMetaKey completedByKey
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public DateTime savedAt
        {
            get; set;
        }
        public bool? isAdhoc
        {
            get; set;
        }
    }

    public class TaskAction
    {
        public string taskActionId
        {
            get; set;
        }
        public long versionId
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
        public string icon
        {
            get; set;
        }
        public string type
        {
            get; set;
        }
        public long? formId
        {
            get; set;
        }
        public string status
        {
            get; set;
        }
    }

    public class TaskCompletionTask
    {
        public string taskId
        {
            get; set;
        }
        public long versionId
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public TaskSchedule schedule
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public List<string> actionIds
        {
            get; set;
        }
        public string swipeLeftActionId
        {
            get; set;
        }
        public string swipeRightActionId
        {
            get; set;
        }
    }

    public class TaskCompletionTaskGroup
    {
        public string taskGroupId
        {
            get; set;
        }
        public long versionId
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public List<object> taskIds
        {
            get; set;
        }
    }

    public class TaskCompletionTaskGroupInstance
    {
        public string taskGroupInstanceId
        {
            get; set;
        }
        public string taskGroupId
        {
            get; set;
        }
        public long versionId
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
    }

    public class TaskCompletion
    {
        public CompletedTask completedTask
        {
            get; set;
        }
        public TaskCompletionTask task
        {
            get; set;
        }
        public TaskAction taskAction
        {
            get; set;
        }
        public TaskCompletionTaskGroup taskGroup
        {
            get; set;
        }
        public TaskCompletionTaskGroupInstance taskGroupInstance
        {
            get; set;
        }
    }
}