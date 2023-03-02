using System;
using dotenv.net;
using Xunit;
using System.Collections.Generic;

namespace OneBlink.SDK.Tests
{
    public class TokenTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;

        public TokenTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        [Fact]
        public void generate_token_with_oneblink_access_claim()
        {
            string token = Token.GenerateJSONWebToken(ACCESS_KEY, SECRET_KEY, 28800, new DeveloperKeyAccess()
            {
                submissions = new DeveloperKeyAccessSubmissions()
                {
                    create = new DeveloperKeyAccessSubmissionsCreate()
                    {
                        formIds = new List<long>() { 1 }
                    }
                },
                forms = new DeveloperKeyAccessForms()
                {
                    read = new DeveloperKeyAccessFormsRead()
                    {
                        ids = new List<long>() { 1 }
                    }
                },
                prefillData = new DeveloperKeyAccessPrefillData()
                {
                    read = new DeveloperKeyAccessPrefillDataRead()
                    {
                        ids = new List<Guid>() { Guid.Parse("adb0d3e4-4d1c-41e3-9503-9b68473a3653") }
                    }
                }
            });
        }
    }
}
