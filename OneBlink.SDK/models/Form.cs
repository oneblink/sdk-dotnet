using System;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
  public class Form
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string organisationId { get; set; }
    public List<object> elements { get; set; }
    public bool isAuthenticated { get; set; }
    public List<object> submissionEvents { get; set; }
    public bool isPublished { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool isMultiPage { get; set; }
    public string postSubmissionAction { get; set; }
    public object redirectUrl { get; set; }
    public bool isInfoPage { get; set; }
    public List<int> formsAppIds { get; set; }
  }
}