using System;
using System.Collections.Generic;
namespace OneBlink.SDK.Model
{
    public class PDFConfiguration
    {
        public string pdfFileName
        {
            get; set;
        }
        public Boolean? includeSubmissionIdInPdf
        {
            get; set;
        }
        public Boolean? includePaymentInPdf
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
        public ApprovalFormsInclusionConfiguration approvalFormsInclusion
        {
            get; set;
        }
    }
}