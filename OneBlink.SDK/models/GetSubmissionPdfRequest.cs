using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GetSubmissionPdfRequest : PDFConfiguration
    {
        public bool? isDraft
        {
            get; set;
        }
    }
}