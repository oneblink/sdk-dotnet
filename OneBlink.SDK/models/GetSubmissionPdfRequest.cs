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
        public bool? isDraft
        {
            get; set;
        }
        public bool? includeSubmissionIdInPdf
        {
            get; set;
        }
        public bool? includePaymentInPdf
        {
            get; set;
        }
        public bool? includeCalendarBookingInPdf
        {
            get; set;
        }
        public List<string> excludedCSSClasses
        {
            get; set;
        }
        public bool? includeExternalIdInPdf
        {
            get; set;
        }
        public string pdfSize
        {
            get; set;
        }
    }
}