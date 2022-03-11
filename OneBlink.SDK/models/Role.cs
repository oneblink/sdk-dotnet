using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class RolePrivilege
    {
        public string AUTH
        {
            get; set;
        }
        public string KEYS
        {
            get; set;
        }
        public string FORMS
        {
            get; set;
        }
        public string BUILDBOT
        {
            get; set;
        }
        public string ANALYTICS
        {
            get; set;
        }
        public string FORMS_APPS
        {
            get; set;
        }
        public string API_HOSTING
        {
            get; set;
        }
        public string FORMS_APP_USERS
        {
            get; set;
        }
        public string WEB_APP_HOSTING
        {
            get; set;
        }
        public string FORMS_APP_STYLES
        {
            get; set;
        }
        public string FORM_SUBMISSIONS
        {
            get; set;
        }
        public string FORM_OPTIONS_SETS
        {
            get; set;
        }
    }

    public class Role
    {
        public long id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public string description
        {
            get; set;
        }
        public string organisationId
        {
            get; set;
        }
        public RolePrivilege privilege
        {
            get; set;
        }
    }

    internal class PermissionLinks
    {
        public string organisations
        {
            get; set;
        }
        public string users
        {
            get; set;
        }
        public Role role
        {
            get; set;
        }
    }

    internal class Permission
    {
        public long id
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public DateTime createdAt
        {
            get; set;
        }
        public DateTime updatedAt
        {
            get; set;
        }
        public RolePrivilege privilege
        {
            get; set;
        }
        public PermissionLinks links
        {
            get; set;
        }
    }

    internal class PermissionSearchResult : SearchResult
    {
        public List<Permission> permissions
        {
            get; set;
        }
    }
}