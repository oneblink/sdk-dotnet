using System;
using System.IO;
using System.Net;
using dotenv.net;
using OneBlink.SDK;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
    public class ApprovalsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;

        public ApprovalsClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            try
            {
                ApprovalsClient ApprovalsClient = new ApprovalsClient("", "");
                Assert.NotNull(null);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public void can_be_constructed()
        {
            ApprovalsClient ApprovalsClient = new ApprovalsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(ApprovalsClient);
        }

        [Fact]
        public async void can_get_approvals()
        {
            ApprovalsClient ApprovalsClient = new ApprovalsClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            GetFormSubmissionAdministrationApprovalsResponse response = await ApprovalsClient.GetFormSubmissionAdministrationApprovals(
                formsAppId: 1640,
                limit: 50,
                offset: 0,
                formId: 1,
                externalId: "external-id",
                submissionId: "0b6cadc6-2cea-4b78-bccd-a035843f42e9",
                submittedAfterDateTime: "2020-01-01",
                submittedBeforeDateTime: "2020-12-01",
                statuses: new System.Collections.Generic.List<string>()
                {
                    "APPROVED"
                },
                updatedAfterDateTime: "2020-01-01",
                updatedBeforeDateTime: "2020-12-01",
                lastUpdatedBy: new System.Collections.Generic.List<string>()
                {
                    "developers@oneblink.io"
                }
            );
            Assert.NotNull(response);
        }
    }
}