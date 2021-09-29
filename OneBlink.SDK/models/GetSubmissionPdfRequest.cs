using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetSubmissionPdfRequest
    {
        public List<Guid> excludedElementIds
        {
            get; set;
        }
        public bool? usePagesAsBreaks
        {
            get; set;
        }
    }
}