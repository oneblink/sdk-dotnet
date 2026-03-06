#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class TaskGroup
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
        public List<long> taskIds
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
    }
}