#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class TaskGroupInstance
    {
        public DateTime createdAt
        {
            get; set;
        }
        public long taskGroupId
        {
            get; set;
        }
        public string taskGroupInstanceId
        {
            get; set;
        }
        public string label
        {
            get; set;
        }
    }
}