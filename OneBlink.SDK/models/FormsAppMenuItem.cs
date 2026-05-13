using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormsAppMenuItemTaskAllocation
    {
        public string taskId { get; set; }
    }

    public class FormsAppMenuItemTaskGroupInstanceAllocation
    {
        public string taskGroupInstanceId { get; set; }
        public string allocatedAt { get; set; }
    }

    public class FormsAppMenuItemListDisplayAttribute
    {
        public string type { get; set; }
        public string attribute { get; set; }
        public Guid? formElementId { get; set; }
    }

    public class FormsAppMenuItem
    {
        public string label { get; set; }
        public string icon { get; set; }
        public string imageUrl { get; set; }
        public string type { get; set; }
        public bool? isHidden { get; set; }
        public bool? isDefault { get; set; }
        public string href { get; set; }
        public List<long> formIds { get; set; }
        public long? formId { get; set; }
        public bool? alwaysSubmitViaPendingQueue { get; set; }
        public List<FormsAppMenuItemTaskAllocation> taskAllocations { get; set; }
        public List<FormsAppMenuItemTaskGroupInstanceAllocation> taskGroupInstanceAllocations { get; set; }
        public string slug { get; set; }
        public bool? allowAdhocTasks { get; set; }
        public FormsAppMenuItemListDisplayAttributes listDisplayAttributes { get; set; }
    }
}
