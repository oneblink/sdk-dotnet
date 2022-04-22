using System;
using System.IO;
using System.Net;
using dotenv.net;
using OneBlink.SDK;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
    public class TeamMembersClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private string email = "developers@oneblink.io";

        public TeamMembersClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");

            string email = Environment.GetEnvironmentVariable("GET_TEAM_MEMBER_ROLE_EMAIL");
            if (!String.IsNullOrWhiteSpace(email))
            {
                this.email = email;
            }
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new TeamMembersClient("", ""));
        }

        [Fact]
        public void can_be_constructed()
        {
            TeamMembersClient teamMembersClient = new TeamMembersClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(teamMembersClient);
        }

        [Fact]
        public async void can_get_team_member_role()
        {
            TeamMembersClient teamMembersClient = new TeamMembersClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Role role = await teamMembersClient.GetTeamMemberRole(this.email);
            Assert.NotNull(role);
        }

        [Fact]
        public async void get_team_member_role_should_throw_oneblink_exception()
        {
            OneBlinkAPIException oneBlinkAPIException = await Assert.ThrowsAsync<OneBlinkAPIException>(() =>
            {
                TeamMembersClient teamMembersClient = new TeamMembersClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc", TenantName.ONEBLINK_TEST);
                return teamMembersClient.GetTeamMemberRole(this.email);
            });
            Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
        }

        [Fact]
        public async void get_team_member_role_return_null()
        {
            TeamMembersClient teamMembersClient = new TeamMembersClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Role role = await teamMembersClient.GetTeamMemberRole("fake-user@faker.com.au");
            Assert.Null(role);
        }
    }
}