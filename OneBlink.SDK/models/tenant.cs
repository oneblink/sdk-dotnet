using System;
using Amazon;

namespace OneBlink.SDK.Model
{
    public enum TenantName
    {
        ONEBLINK,
        ONEBLINK_TEST,
        CIVICPLUS,
        CIVICPLUS_TEST
    };
    internal class Tenant
    {
        public Tenant(
            TenantName name = TenantName.ONEBLINK
        )
        {
            this.name = name;
        }

        private TenantName name;
        public string oneBlinkAPIOrigin
        {
            get
            {
                switch (this.name)
                {
                    case TenantName.CIVICPLUS:
                        return "https://auth-api.transform.civicplus.com";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://auth-api.test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://auth-api.test.blinkm.io";
                    default:
                        return "https://auth-api.blinkm.io";
                }
            }
        }
        public string oneBlinkPdfOrigin
        {
            get
            {
                switch (this.name)
                {
                    case TenantName.CIVICPLUS:
                        return "https://auth-api.transform.civicplus.com";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://auth-api.test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://auth-api.test.blinkm.io";
                    default:
                        return "https://auth-api.blinkm.io";
                }
            }
        }

        public RegionEndpoint AwsRegion
        {
            get
            {
                switch (this.name)
                {
                    case TenantName.CIVICPLUS:
                    case TenantName.CIVICPLUS_TEST:
                        return RegionEndpoint.USEast2;
                    case TenantName.ONEBLINK:
                    case TenantName.ONEBLINK_TEST:
                        return RegionEndpoint.APSoutheast2;
                    default:
                        return RegionEndpoint.APSoutheast2;
                }
            }
        }

    }
}

