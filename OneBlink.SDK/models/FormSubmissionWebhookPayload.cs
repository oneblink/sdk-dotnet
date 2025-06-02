using System;

namespace OneBlink.SDK.Model
{
  public class FormSubmissionWebhookPayload
  {
    /// <summary>
    /// The identifier of the App (`null` for submissions that were not initiated from an app).
    /// </summary>
    public long? formsAppId
    {
      get; set;
    }

    /// <summary>
    /// The identifier of the Form.
    /// </summary>
    public long formId
    {
      get; set;
    }

    /// <summary>
    /// Your identifier provided via the URL or receipt generation when opening the form.
    /// </summary>
    public string externalId
    {
      get; set;
    }

    /// <summary>
    /// Set to true if it was a draft submission.
    /// </summary>
    public bool isDraft
    {
      get; set;
    }

    /// <summary>
    /// The secret you entered in the form workflow event configuration.
    /// </summary>
    public string secret
    {
      get; set;
    }

    /// <summary>
    /// The identifier for the submission.
    /// </summary>
    public string submissionId
    {
      get; set;
    }

    /// <summary>
    /// An ISO 8601 timestamp at the time of submission.
    /// </summary>
    public DateTime submissionTimestamp
    {
      get; set;
    }

    /// <summary>
    /// The username of the logged in user that submitted the form (`null` for anonymous submissions).
    /// </summary>
    public string username
    {
      get; set;
    }

    /// <summary>
    /// The identifier for the job if the submission was for a job.
    /// </summary>
    public string jobId
    {
      get; set;
    }
  }
}
