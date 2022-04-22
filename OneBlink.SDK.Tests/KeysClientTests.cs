using System;
using System.IO;
using System.Net;
using dotenv.net;
using OneBlink.SDK;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
    public class KeysClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;

        public KeysClientTests()
        {
            bool raiseException = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: raiseException, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new KeysClient("", ""));
        }

        [Fact]
        public void can_be_constructed()
        {
            KeysClient keysClient = new KeysClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(keysClient);
        }

        [Fact]
        public async void can_get_developer_key()
        {
            KeysClient keysClient = new KeysClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            DeveloperKey developerKey = await keysClient.GetDeveloperKey(ACCESS_KEY);
            Assert.NotNull(developerKey);
        }

        [Fact]
        public async void get_developer_key_should_throw_oneblink_exception()
        {
            OneBlinkAPIException oneBlinkAPIException = await Assert.ThrowsAsync<OneBlinkAPIException>(() =>
            {
                KeysClient keysClient = new KeysClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc", TenantName.ONEBLINK_TEST);
                return keysClient.GetDeveloperKey(ACCESS_KEY);
            });
            Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
        }

    }
}