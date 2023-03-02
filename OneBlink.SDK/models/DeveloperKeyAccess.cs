using System;
using System.Collections.Generic;

namespace OneBlink.SDK {
    internal class DeveloperKeyAccessPrefillDataRead
    {
        public List<Guid> ids
        {
            get; set;
        }
    }

    internal class DeveloperKeyAccessPrefillData
    {
        public DeveloperKeyAccessPrefillDataRead read
        {
            get; set;
        }
    }

    internal class DeveloperKeyAccessSubmissionsCreate
    {
        public List<long> formIds
        {
            get; set;
        }
    }

    internal class DeveloperKeyAccessSubmissions
    {
        public DeveloperKeyAccessSubmissionsCreate create
        {
            get; set;
        }
    }
    internal class DeveloperKeyAccessFormsRead
    {
        public List<long> ids
        {
            get; set;
        }
    }
    internal class DeveloperKeyAccessForms
    {
        public DeveloperKeyAccessFormsRead read
        {
            get; set;
        }
    }

    internal class DeveloperKeyAccess
    {
        public DeveloperKeyAccessSubmissions submissions
        {
            get; set;
        }
        public DeveloperKeyAccessForms forms
        {
            get; set;
        }
        public DeveloperKeyAccessPrefillData prefillData
        {
            get; set;
        }
    }

}