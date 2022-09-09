using System;
using dotenv.net;
using OneBlink.SDK.Model;
using Xunit;
using System.Collections.Generic;

namespace OneBlink.SDK.Tests
{
    public class DataManagerClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;

        private const long FORM_ID = 8321;

        public DataManagerClientTests()
        {
            bool ignoreExceptions = true;
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: ignoreExceptions, probeForEnv: true, probeLevelsToSearch: 5));
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            Assert.Throws<ArgumentException>(() => new DataManagerClient("", ""));
        }

        [Fact]
        public void can_be_constructed()
        {
            DataManagerClient dataManagerClient = new DataManagerClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            Assert.NotNull(dataManagerClient);
        }

        [Fact]
        public async void can_get_form_definition()
        {
            DataManagerClient dataManagerClient = new DataManagerClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormStoreDefinition response = await dataManagerClient.GetFormDefinition(FORM_ID);
            Assert.NotNull(response);
            Assert.Equal(FORM_ID, response.formId);
            Assert.Single(response.formElements);
            Assert.Equal("number", response.formElements[0].type);
        }

        [Fact]
        public async void can_search()
        {
            DataManagerClient dataManagerClient = new DataManagerClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
            FormStoreSearchRequest request = new FormStoreSearchRequest();
            request.formId = FORM_ID;
            request.filters = new FormStoreSearchFilter();
            FormStoreSearchNumberFilter numberFilter = new FormStoreSearchNumberFilter();
            numberFilter.eq = 3;
            request.filters.submission = new Dictionary<string, IFormStoreInterface>();
            request.filters.submission.Add("just_a_number", numberFilter);
            FormStoreSearchResult<SubmissionResult> searchResult = await dataManagerClient.Search<SubmissionResult>(request);
            Assert.NotNull(searchResult);
            Assert.Single(searchResult.submissions);
            Assert.NotNull(searchResult.submissions[0]);
            Assert.Equal("72832a1b-7ee2-4ec9-a0a9-a4aa107f9061", searchResult.submissions[0].submissionId.ToString());
            Assert.NotNull(searchResult.submissions[0].submission);
            Assert.Equal(3, searchResult.submissions[0].submission.just_a_number);
        }

        private class SubmissionResult
        {
            public long? just_a_number
            {
                get; set;
            }
        }
    }
}