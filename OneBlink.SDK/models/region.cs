using System;


namespace OneBlink.SDK.Model
{
    public enum RegionCode {
        AU,
        US
    };
    internal class Region
    {
        public Region(
            RegionCode code = RegionCode.AU,
            string apiOrigin = null,
            string pdfOrigin = null
        )
        {
            this.code = code;
            this.apiOrigin = apiOrigin;
            this.pdfOrigin = pdfOrigin;
        }

        private RegionCode code;
        private string apiOrigin;
        private bool hasApiOrigin => !String.IsNullOrWhiteSpace(this.apiOrigin);
        private string pdfOrigin;
        private bool hasPdfOrigin => !String.IsNullOrWhiteSpace(this.pdfOrigin);
        public string oneBlinkAPIOrigin {
            get {
                if (this.hasApiOrigin) {
                    return this.apiOrigin;
                }
                switch(this.code) {
                    case RegionCode.AU:
                        return "https://auth-api.blinkm.io";
                    case RegionCode.US:
                        return "https://us-auth-api.blinkm.io";
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
                switch(this.code) {
                    case RegionCode.AU:
                        return "https://pdf.blinkm.io";
                    case RegionCode.US:
                        return "https://us-pdf.blinkm.io";
                    default:
                        return "https://pdf.blinkm.io";
                }
            }
        }

    }
}

