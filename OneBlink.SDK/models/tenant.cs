using System;
using Amazon;

namespace OneBlink.SDK.Model
{
    public enum TenantName
    {
        ONEBLINK,
        ONEBLINK_TEST,
        CIVICPLUS,
        CIVICPLUS_TEST,
        ONEBLINK_US,
        ONEBLINK_US_TEST
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
                    case TenantName.ONEBLINK_US:
                        return "https://auth-api.us.oneblink.io";
                    case TenantName.ONEBLINK_US_TEST:
                        return "https://auth-api.test.us.oneblink.io";
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
                    case TenantName.ONEBLINK_US:
                        return "https://auth-api.us.oneblink.io";
                    case TenantName.ONEBLINK_US_TEST:
                        return "https://auth-api.test.us.oneblink.io";
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
                        return "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_PmyuuhfWj";
                    case TenantName.CIVICPLUS_TEST:
                        return "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_rvIeXcSue";
                    case TenantName.ONEBLINK_TEST:
                        return "https://cognito-idp.ap-southeast-2.amazonaws.com/ap-southeast-2_AfFQWsYIH";
                    case TenantName.ONEBLINK_US:
                        return "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_TBD"; // update when available
                    case TenantName.ONEBLINK_US_TEST:
                        return "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_x2AYHCleu";
                    default:
                        return "https://cognito-idp.ap-southeast-2.amazonaws.com/ap-southeast-2_7kAsz3n3x";
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
                    case TenantName.ONEBLINK_US:
                    case TenantName.ONEBLINK_US_TEST:
                        return RegionEndpoint.USEast1;
                    default:
                        return RegionEndpoint.APSoutheast2;
                }
            }
        }

    }
}

