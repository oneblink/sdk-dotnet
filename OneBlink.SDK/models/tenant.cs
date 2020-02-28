using System;


namespace OneBlink.SDK.Model
{
    public enum TenantName {
        ONEBLINK,
        CIVICPLUS
    };
    internal class Tenant
    {
        public Tenant(
            TenantName name = TenantName.ONEBLINK,
            string apiOrigin = null,
            string pdfOrigin = null
        )
        {
            this.name = name;
            this.apiOrigin = apiOrigin;
            this.pdfOrigin = pdfOrigin;
        }

        private TenantName name;
        private string apiOrigin;
        private bool hasApiOrigin => !String.IsNullOrWhiteSpace(this.apiOrigin);
        private string pdfOrigin;
        private bool hasPdfOrigin => !String.IsNullOrWhiteSpace(this.pdfOrigin);
        public string oneBlinkAPIOrigin {
            get {
                if (this.hasApiOrigin) {
                    return this.apiOrigin;
                }
                switch(this.name) {
                    case TenantName.ONEBLINK:
                        return "https://auth-api.blinkm.io";
                    case TenantName.CIVICPLUS:
                        return "https://auth-api.transform.civicplus.com";
                    default:
                        return "https://auth-api.blinkm.io";
                }
            }
        }
        public string oneBlinkPdfOrigin {
            get {
                if (this.hasPdfOrigin) {
                    return this.pdfOrigin;
                }
                switch(this.name) {
                    case TenantName.ONEBLINK:
                        return "https://pdf.blinkm.io";
                    case TenantName.CIVICPLUS:
                        return "https://pdf.transform.civicplus.com";
                    default:
                        return "https://pdf.blinkm.io";
                }
            }
        }

    }
}

