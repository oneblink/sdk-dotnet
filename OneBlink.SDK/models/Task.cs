#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class Task
    {
        public long id
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; internal set;
        }
        public DateTime updatedAt
        {
            get; internal set;
        }
        public string name
        {
            get; set;
        }
        public long formsAppEnvironmentId
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public long workspaceId
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
        public List<long> actionIds
        {
            get; set;
        }
        public long swipeLeftActionId
        {
            get; set;
        }
        public long swipeRightActionId
        {
            get; set;
        }
    }
}