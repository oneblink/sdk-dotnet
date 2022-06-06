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
                        return "https://auth-api-test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://auth-api-test.blinkm.io";
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
                        return "https://auth-api-test.transform.civicplus.com";
                    case TenantName.ONEBLINK_TEST:
                        return "https://auth-api-test.blinkm.io";
                    default:
                        return "https://auth-api.blinkm.io";
                }
            }
        }

        public string jwtIssuer
        {
            get
            {
                switch (this.name)
                {
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

