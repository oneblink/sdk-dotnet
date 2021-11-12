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
            Assert.Throws<ArgumentException>(() => new OrganisationsClient("", ""));
        }

        [Fact]
        public async void can_upload_asset()
        {
            OrganisationsClient organisationsClient = new OrganisationsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);

            using (var stream = GenerateStreamFromString("data"))
            {
                var response = await organisationsClient.UploadAsset(stream, "text/plain", "test.txt");
                Assert.NotNull(response);
            }
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}