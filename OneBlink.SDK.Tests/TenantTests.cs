using System;
using System.IO;
using Xunit;
using OneBlink.SDK.Model;
namespace OneBlink.SDK.Tests
{
    public class RegionTests {

        [Fact]
        public void can_get_region_urls()
        {
            Tenant tenant = new Tenant(TenantName.CIVICPLUS);
            Assert.Matches("https://auth-api.transform.civicplus.com", tenant.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf.transform.civicplus.com", tenant.oneBlinkPdfOrigin);

            tenant = new Tenant(TenantName.ONEBLINK);
            Assert.Matches("https://auth-api.blinkm.io", tenant.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf.blinkm.io", tenant.oneBlinkPdfOrigin);

        }

        [Fact]
        public void region_defaults_to_au()
        {
            Tenant tenant = new Tenant();
            Assert.Matches("https://auth-api.blinkm.io", tenant.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf.blinkm.io", tenant.oneBlinkPdfOrigin);
        }

        [Fact]
        public void can_override_region_urls()
        {
            Tenant tenant = new Tenant(
                TenantName.CIVICPLUS,
                apiOrigin: "https://auth-api-test.blinkm.io",
                pdfOrigin: "https://pdf-test.blinkm.io"
            );
            Console.WriteLine(tenant.oneBlinkAPIOrigin);
            Assert.Matches("https://auth-api-test.blinkm.io", tenant.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf-test.blinkm.io", tenant.oneBlinkPdfOrigin);
        }

    }

}
