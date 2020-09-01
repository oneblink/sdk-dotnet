using System;
using dotenv.net;
using System.IO;
using Xunit;
using OneBlink.SDK.Model;

namespace OneBlink.SDK.Tests
{
    public class OrganisationsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;

        public OrganisationsClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        [Fact]
        public void can_be_constructed()
        {
            OrganisationsClient organisations = new OrganisationsClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(organisations);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            try
            {
                OrganisationsClient organisations = new OrganisationsClient(
                  "",
                  ""
                );
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void can_upload_asset()
        {
            OrganisationsClient organisationsClient = new OrganisationsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            var response = await organisationsClient.UploadAsset("data", "text/plain", "test.txt");
            Assert.NotNull(response);
        }
    }
}