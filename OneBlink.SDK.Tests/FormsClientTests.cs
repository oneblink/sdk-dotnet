using System;
using System.IO;
using System.Net;
using dotenv.net;
using OneBlink.SDK;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
  public class FormsClientTests
  {
    private string ACCESS_KEY;
    private string SECRET_KEY;
    private int formId = 475;
    private string submissionId = "5ab3d950-253a-4d22-8ae6-c9eae82f58ba";
    public FormsClientTests()
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
      string submissionId = Environment.GetEnvironmentVariable("GET_SUBMISSION_DATA_SUBMISSION_ID");
      if (!String.IsNullOrWhiteSpace(submissionId))
      {
        this.submissionId = submissionId;
      }
    }

    [Fact]
    public void can_be_constructed()
    {
      FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
      Assert.NotNull(forms);
    }

    [Fact]
    public void throws_error_if_keys_empty()
    {
      try
      {
        FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
      }
      catch (Exception ex)
      {
        Assert.NotNull(ex);
      }
    }

    [Fact]
    public async void can_search_forms()
    {
      FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
      FormsSearchResult response = await forms.Search(null, null, null);
      Assert.NotNull(response);
    }

    [Fact]
    public async void can_search_forms_with_all_params()
    {
      FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
      FormsSearchResult response = await forms.Search(true, true, "Location test");
      Assert.NotNull(response);
    }

    [Fact]
    public async void can_get_submission_data()
    {
      FormsClient forms = new FormsClient(ACCESS_KEY, SECRET_KEY);
      FormSubmission<object> formSubmission = await forms.GetFormSubmission<object>(this.formId, this.submissionId);
      Assert.NotNull(formSubmission);
    }

    [Fact]
    public async void get_submission_data_should_throw_oneblink_exception()
    {
      FormsClient forms = new FormsClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc");
      try
      {
        FormSubmission<object> formSubmission = await forms.GetFormSubmission<object>(this.formId, this.submissionId);
        Assert.NotNull(null);
      }
      catch (OneBlinkAPIException oneBlinkAPIException)
      {
        Assert.NotNull(oneBlinkAPIException);
        Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
        Console.WriteLine(oneBlinkAPIException);
      }
    }
  }
}