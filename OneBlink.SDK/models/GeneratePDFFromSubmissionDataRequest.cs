#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class GeneratePDFFromSubmissionDataRequest<T>
    {
        public FormSubmission<T> submissionData
        {
            get; set;
        }
        public long formsAppId
        {
            get; set;
        }
        public List<string> excludedElementIds
        {
            get; set;
        }
        public bool? usePagesAsBreaks
        {
            get; set;
        }
        public List<string> excludedCSSClasses
        {
            get; set;
        }
    }
}