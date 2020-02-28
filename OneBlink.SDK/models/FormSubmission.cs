using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
  public class FormSubmissionUser
  {
    [JsonProperty]
    public string userId { get; internal set; }
    [JsonProperty]
    public string email { get; internal set; }
    [JsonProperty]
    public string firstName { get; internal set; }
    [JsonProperty]
    public string lastName { get; internal set; }
    [JsonProperty]
    public string fullName { get; internal set; }
    [JsonProperty]
    public string picture { get; internal set; }
    [JsonProperty]
    public string providerType { get; internal set; }
    [JsonProperty]
    public string providerUserId { get; internal set; }
  }

  public enum FormSubmissionDeviceType
  {
    BROWSER,
    CORDOVA,
    PWA
  }

  public class FormSubmissionDevice
  {
    /// <summary>
    /// The type of device used to submit form
    /// </summary>
    [JsonProperty]
    public FormSubmissionDeviceType type { get; internal set; }

    /// <summary>
    /// The version of Cordova running on the device.
    /// </summary>
    [JsonProperty]
    public string cordova { get; internal set; }

    /// <summary>
    /// The name of the device's model or product. The value is set by the device manufacturer and may be different across versions of the same product.
    /// </summary>
    [JsonProperty]
    public string model { get; internal set; }

    /// <summary>
    /// The device's operating system name.
    /// </summary>
    [JsonProperty]
    public string platform { get; internal set; }

    /// <summary>
    /// The device's Universally Unique Identifier
    /// </summary>
    [JsonProperty]
    public string uuid { get; internal set; }

    /// <summary>
    /// The operating system version.
    /// </summary>
    [JsonProperty]
    public string version { get; internal set; }

    /// <summary>
    /// The device's manufacturer.
    /// </summary>
    [JsonProperty]
    public string manufacturer { get; internal set; }

    /// <summary>
    /// Whether the device is running on a simulator.
    /// </summary>
    [JsonProperty]
    public bool? isVirtual { get; internal set; }

    /// <summary>
    /// The device hardware serial number
    /// </summary>
    [JsonProperty]
    public string serial { get; internal set; }

    /// <summary>
    /// The internal "code" name of the browser.
    /// </summary>
    [JsonProperty]
    public string appCodeName { get; internal set; }

    /// <summary>
    /// The official name of the browser.
    /// </summary>
    [JsonProperty]
    public string appName { get; internal set; }

    /// <summary>
    /// The version of the browser.
    /// </summary>
    [JsonProperty]
    public string appVersion { get; internal set; }

    /// <summary>
    /// Whether cookies were enabled on the browser.
    /// </summary>
    [JsonProperty]
    public bool? cookieEnabled { get; internal set; }

    /// <summary>
    /// The number of logical processors available to run threads on the user's computer.
    /// </summary>
    [JsonProperty]
    public int? hardwareConcurrency { get; internal set; }

    /// <summary>
    /// The preferred language of the user, usually the language of the browser UI.
    /// </summary>
    [JsonProperty]
    public string language { get; internal set; }

    /// <summary>
    /// The maximum number of simultaneous touch contact points are supported by the device.
    /// </summary>
    [JsonProperty]
    public int? maxTouchPoints { get; internal set; }

    /// <summary>
    /// The user agent string for the browser.
    /// </summary>
    [JsonProperty]
    public string userAgent { get; internal set; }

    /// <summary>
    /// The vendor name of the browser
    /// </summary>
    [JsonProperty]
    public string vendor { get; internal set; }

    /// <summary>
    /// The vendor version of the browser
    /// </summary>
    [JsonProperty]
    public string vendorSub { get; internal set; }

    /// <summary>
    /// Whether the user agent was controlled by automation
    /// </summary>
    [JsonProperty]
    public bool? webdriver { get; internal set; }
  }

  public class FormSubmission<T>
  {
    [JsonProperty]
    public Form definition { get; internal set; }

    [JsonProperty]
    public T submission { get; internal set; }

    [JsonProperty]
    public DateTime submissionTimestamp { get; internal set; }

    [JsonProperty]
    public string keyId { get; internal set; }

    [JsonProperty]
    public int formsAppId { get; internal set; }

    [JsonProperty]
    public FormSubmissionUser user { get; internal set; }

    /// <summary>
    /// Information about the device used to submit form
    /// </summary>
    [JsonProperty]
    public FormSubmissionDevice device { get; internal set; }
  }

  public class FormSubmissionSupervisor
  {
    [JsonProperty]
    public string email { get; internal set; }
    [JsonProperty]
    public string fullName { get; internal set; }
    [JsonProperty]
    public string providerUserId { get; internal set; }
  }

  public class FormSubmissionMetaUserDetails : FormSubmissionUser
  {
    [JsonProperty]
    public FormSubmissionSupervisor supervisor { get; internal set; }

  }

  public class FormSubmissionMetaKey
  {
    [JsonProperty]
    public string id { get; internal set; }
    [JsonProperty]
    public string name { get; internal set; }
  }

  public class FormSubmissionMetadata
  {
    [JsonProperty]
    public string submissionId { get; internal set; }
    [JsonProperty]
    public int formId { get; internal set; }
    [JsonProperty]
    public string formName { get; internal set; }
    [JsonProperty]
    public string dateTimeSubmitted { get; internal set; }
    [JsonProperty]
    public FormSubmissionMetaUserDetails user { get; internal set; }
    [JsonProperty]
    public FormSubmissionMetaKey key { get; internal set; }
  }

  public class FormSubmissionSearchResult : SearchResult
  {
    [JsonProperty]
    public List<FormSubmissionMetadata> formSubmissionMeta { get; internal set; }
  }
}
