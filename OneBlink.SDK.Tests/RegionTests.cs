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
            Region region = new Region(RegionCode.US);
            Assert.Matches("https://us-auth-api.blinkm.io", region.oneBlinkAPIOrigin);
            Assert.Matches("https://us-pdf.blinkm.io", region.oneBlinkPdfOrigin);

            region = new Region(RegionCode.AU);
            Assert.Matches("https://auth-api.blinkm.io", region.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf.blinkm.io", region.oneBlinkPdfOrigin);

        }

        [Fact]
        public void region_defaults_to_au()
        {
            Region region = new Region();
            Assert.Matches("https://auth-api.blinkm.io", region.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf.blinkm.io", region.oneBlinkPdfOrigin);
        }

        [Fact]
        public void can_override_region_urls()
        {
            Region region = new Region(
                RegionCode.US,
                apiOrigin: "https://auth-api-test.blinkm.io",
                pdfOrigin: "https://pdf-test.blinkm.io"
            );
            Console.WriteLine(region.oneBlinkAPIOrigin);
            Assert.Matches("https://auth-api-test.blinkm.io", region.oneBlinkAPIOrigin);
            Assert.Matches("https://pdf-test.blinkm.io", region.oneBlinkPdfOrigin);
        }

    }

}
