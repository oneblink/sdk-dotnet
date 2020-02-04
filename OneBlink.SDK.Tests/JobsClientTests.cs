using System;
using System.IO;
using dotenv.net;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
    public class TestJobPrefillData
    {
        public string fieldA
        {
            get; set;
        }
        public string fieldB
        {
            get; set;
        }
        public string fieldC
        {
            get; set;
        }
    }

    public class JobsClientTests
    {
        private string ACCESS_KEY;
        private string SECRET_KEY;
        private int formId = 476;
        public JobsClientTests()
        {
            bool raiseException = false;
            DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
            ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
            SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");

            string formId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_FORM_ID");
            if (!String.IsNullOrWhiteSpace(formId))
            {
                this.formId = Int16.Parse(formId);
            }
        }

        [Fact]
        public void can_be_constructed()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);
            Assert.NotNull(jobs);
        }

        [Fact]
        public void throws_error_if_keys_empty()
        {
            try
            {
                JobsClient jobs = new JobsClient("", "");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void can_create_job_with_prefill()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobDetail jobDetail = new JobDetail("TITLE-01");

            jobDetail.key = "KEY-01";
            jobDetail.description = "DESCRIPTION-01";
            jobDetail.type = "TYPE-01";

            TestJobPrefillData preFill = new TestJobPrefillData();

            preFill.fieldA = "abc";
            preFill.fieldB = "def";
            preFill.fieldC = "ghi";

            Job newJob = new Job(
                details: jobDetail,
                formId: formId,
                username: "developers@oneblink.io"
            );

            Job response = await jobs.CreateJob<TestJobPrefillData>(newJob, preFill);

            Assert.NotNull(response);
            Assert.NotNull(response.id);

            await jobs.DeleteJob(response.id);
        }

        [Fact]
        public async void can_create_job_without_prefill()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobDetail jobDetail = new JobDetail("TITLE-01");

            jobDetail.key = "KEY-01";
            jobDetail.description = "DESCRIPTION-01";
            jobDetail.type = "TYPE-01";

            Job newJob = new Job(
                details: jobDetail,
                formId: formId,
                username: "developers@oneblink.io"
            );
            Job response = await jobs.CreateJob(newJob);

            Assert.NotNull(response);
            Assert.NotNull(response.id);

            await jobs.DeleteJob(response.id);
        }

        [Fact]
        public async void can_create_job_with_externalId()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobDetail jobDetail = new JobDetail("TITLE-01");

            Job newJob = new Job(details: jobDetail, formId: formId, username: "developers@oneblink.io", externalId: "EXT-01");

            Job response = await jobs.CreateJob(newJob);

            Assert.NotNull(response);
            Assert.NotNull(response.id);

            await jobs.DeleteJob(response.id);
        }

        [Fact]
        public async void can_create_job_with_priority()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobDetail jobDetail = new JobDetail(title: "TITLE-01", priority: 1);

            Job newJob = new Job(details: jobDetail, formId: formId, username: "developers@oneblink.io");

            Job response = await jobs.CreateJob(newJob);

            Assert.NotNull(response);
            Assert.NotNull(response.id);

            await jobs.DeleteJob(response.id);
        }

        [Fact]
        public async void can_delete_job()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobDetail jobDetail = new JobDetail("TITLE-01");

            Job newJob = new Job(
                details: jobDetail,
                formId: formId,
                username: "developers@oneblink.io"
            );

            Job job = await jobs.CreateJob(newJob);

            await jobs.DeleteJob(job.id);
        }

        [Fact]
        public async void throws_error_if_username_empty()
        {
            try
            {
                JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

                JobDetail jobDetail = new JobDetail("TITLE-01");

                Job newJob = new Job(
                    details: jobDetail,
                    formId: formId,
                    username: ""
                );

                Job job = await jobs.CreateJob(newJob);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void throws_error_if_title_empty()
        {
            try
            {
                JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

                JobDetail jobDetail = new JobDetail("");

                Job newJob = new Job(
                    details: jobDetail,
                    formId: formId,
                    username: "developers@oneblink.io"
                );

                Job job = await jobs.CreateJob(newJob);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async void can_search_with_multiple_fields()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            JobsSearchParameters searchParams = new JobsSearchParameters()
            {
                externalId = "EXT-01",
                username = "developers@oneblink.io",
                formId = 476
            };

            JobsSearchResult response = await jobs.SearchJobs(searchParams);

            Assert.NotNull(response);
        }

        [Fact]
        public async void can_search_by_form_id()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            int formId = 476;

            JobsSearchResult response = await jobs.SearchByFormId(formId);

            Assert.NotNull(response);
        }

        [Fact]
        public async void can_search_by_username()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            string username = "developers@oneblink.io";

            JobsSearchResult response = await jobs.SearchByUsername(username);

            Assert.NotNull(response);
        }

        [Fact]
        public async void can_search_by_external_id()
        {
            JobsClient jobs = new JobsClient(ACCESS_KEY, SECRET_KEY);

            string externalId = "EXT-01";

            JobsSearchResult response = await jobs.SearchByExternalId(externalId);

            Assert.NotNull(response);
        }
    }
}