using System;


namespace OneBlink.SDK.Model
{
    public enum TenantName {
        ONEBLINK,
        ONEBLINK_TEST,
        CIVICPLUS,
        CIVICPLUS_TEST
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
                    case TenantName.CIVICPLUS:
                        return "https://auth-api.transform.civicplus.com";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://auth-api-test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://auth-api-test.blinkm.io";
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
                    case TenantName.CIVICPLUS:
                        return "https://pdf.transform.civicplus.com";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://pdf-test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://pdf-test.blinkm.io";
                    default:
                        return "https://pdf.blinkm.io";
                }
            }
        }

        public string jwtIssuer {
            get {
                switch(this.name) {
                    case TenantName.CIVICPLUS:
                        return "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_A92OPccYd";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_e2gd0LSVp";
                    case TenantName.ONEBLINK_TEST:
                        return "https://cognito-idp.ap-southeast-2.amazonaws.com/ap-southeast-2_E03xBaafT";
                    default:
                        return "https://cognito-idp.ap-southeast-2.amazonaws.com/ap-southeast-2_o1t3ntGWx";
                }
            }
        }

    }
}

