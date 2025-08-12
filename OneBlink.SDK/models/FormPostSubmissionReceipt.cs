namespace OneBlink.SDK.Model
{
    public class FormPostSubmissionReceipt
    {
        public string html
        {
            get; set;
        }
        public PDFConfiguration allowPDFDownload
        {
            get; set;
        }
        public FormPersonalisation allowAttachmentsDownload
        {
            get; set;
        }
    }
}