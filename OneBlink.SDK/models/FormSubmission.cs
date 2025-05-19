#pragma warning disable IDE1006 // Naming is dictated by OneBlink API
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBlink.SDK.Model
{
    public class FormSubmissionUser
    {
        [JsonProperty]
        public string userId
        {
            get; set;
        }
        [JsonProperty]
        public string username
        {
            get; set;
        }
        [JsonProperty]
        public string email
        {
            get; set;
        }
        [JsonProperty]
        public bool? emailVerified
        {
            get; set;
        }
        [JsonProperty]
        public string firstName
        {
            get; set;
        }
        [JsonProperty]
        public string lastName
        {
            get; set;
        }
        [JsonProperty]
        public string fullName
        {
            get; set;
        }
        [JsonProperty]
        public string picture
        {
            get; set;
        }
        [JsonProperty]
        public string providerType
        {
            get; set;
        }
        [JsonProperty]
        public string providerUserId
        {
            get; set;
        }
        [JsonProperty]
        public string role
        {
            get; set;
        }
        public bool? isSAMLUser
        {
            get; set;
        }
        public string phoneNumber
        {
            get; set;
        }
        [JsonProperty]
        public bool? phoneNumberVerified
        {
            get; set;
        }
        public List<string> groups
        {
            get; set;
        }
        public string areaCode
        {
            get; set;
        }
        public string address
        {
            get; set;
        }
        public string city
        {
            get; set;
        }
        public string state
        {
            get; set;
        }
        public string country
        {
            get; set;
        }
        public string countryCallingCode
        {
            get; set;
        }
        public string department
        {
            get; set;
        }
        public string division
        {
            get; set;
        }
        public string bargain
        {
            get; set;
        }
        public string employeeNumber
        {
            get; set;
        }
        public string departmentHeadFullName
        {
            get; set;
        }
        public string departmentHeadEmail
        {
            get; set;
        }
        public string zipCode
        {
            get; set;
        }
        public string postalCode
        {
            get; set;
        }
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
        public FormSubmissionDeviceType type
        {
            get; set;
        }

        /// <summary>
        /// The version of Cordova running on the device.
        /// </summary>
        [JsonProperty]
        public string cordova
        {
            get; set;
        }

        /// <summary>
        /// The name of the device's model or product. The value is set by the device manufacturer and may be different across versions of the same product.
        /// </summary>
        [JsonProperty]
        public string model
        {
            get; set;
        }

        /// <summary>
        /// The device's operating system name.
        /// </summary>
        [JsonProperty]
        public string platform
        {
            get; set;
        }

        /// <summary>
        /// The device's Universally Unique Identifier
        /// </summary>
        [JsonProperty]
        public string uuid
        {
            get; set;
        }

        /// <summary>
        /// The operating system version.
        /// </summary>
        [JsonProperty]
        public string version
        {
            get; set;
        }

        /// <summary>
        /// The device's manufacturer.
        /// </summary>
        [JsonProperty]
        public string manufacturer
        {
            get; set;
        }

        /// <summary>
        /// Whether the device is running on a simulator.
        /// </summary>
        [JsonProperty]
        public bool? isVirtual
        {
            get; set;
        }

        /// <summary>
        /// The device hardware serial number
        /// </summary>
        [JsonProperty]
        public string serial
        {
            get; set;
        }

        /// <summary>
        /// The internal "code" name of the browser.
        /// </summary>
        [JsonProperty]
        public string appCodeName
        {
            get; set;
        }

        /// <summary>
        /// The official name of the browser.
        /// </summary>
        [JsonProperty]
        public string appName
        {
            get; set;
        }

        /// <summary>
        /// The version of the browser.
        /// </summary>
        [JsonProperty]
        public string appVersion
        {
            get; set;
        }

        /// <summary>
        /// Whether cookies were enabled on the browser.
        /// </summary>
        [JsonProperty]
        public bool? cookieEnabled
        {
            get; set;
        }

        /// <summary>
        /// The number of logical processors available to run threads on the user's computer.
        /// </summary>
        [JsonProperty]
        public int? hardwareConcurrency
        {
            get; set;
        }

        /// <summary>
        /// The preferred language of the user, usually the language of the browser UI.
        /// </summary>
        [JsonProperty]
        public string language
        {
            get; set;
        }

        /// <summary>
        /// The maximum number of simultaneous touch contact points are supported by the device.
        /// </summary>
        [JsonProperty]
        public int? maxTouchPoints
        {
            get; set;
        }

        /// <summary>
        /// The user agent string for the browser.
        /// </summary>
        [JsonProperty]
        public string userAgent
        {
            get; set;
        }

        /// <summary>
        /// The vendor name of the browser
        /// </summary>
        [JsonProperty]
        public string vendor
        {
            get; set;
        }

        /// <summary>
        /// The vendor version of the browser
        /// </summary>
        [JsonProperty]
        public string vendorSub
        {
            get; set;
        }

        /// <summary>
        /// Whether the user agent was controlled by automation
        /// </summary>
        [JsonProperty]
        public bool? webdriver
        {
            get; set;
        }
    }

    public class FormSubmission<T>
    {
        [JsonProperty]
        public Form definition
        {
            get; set;
        }

        [JsonProperty]
        public T submission
        {
            get; set;
        }

        [JsonProperty]
        public DateTime submissionTimestamp
        {
            get; set;
        }

        [JsonProperty]
        public string ipAddress
        {
            get; set;
        }

        [JsonProperty]
        public string keyId
        {
            get; set;
        }

        [JsonProperty]
        public long formsAppId
        {
            get; set;
        }

        [JsonProperty]
        public FormSubmissionUser user
        {
            get; set;
        }

        /// <summary>
        /// Information about the device used to submit form
        /// </summary>
        [JsonProperty]
        public FormSubmissionDevice device
        {
            get; set;
        }

        [JsonProperty]
        public FormElement lastElementUpdated
        {
            get; set;
        }
        [JsonProperty]
        public string externalId
        {
            get; set;
        }
        [JsonProperty]
        public Task task
        {
            get; set;
        }
        [JsonProperty]
        public TaskGroup taskGroup
        {
            get; set;
        }
        [JsonProperty]
        public TaskGroupInstance taskGroupInstance
        {
            get; set;
        }
    }

    public class FormSubmissionSupervisor
    {
        [JsonProperty]
        public string email
        {
            get; set;
        }
        [JsonProperty]
        public string fullName
        {
            get; set;
        }
        [JsonProperty]
        public string providerUserId
        {
            get; set;
        }
    }

    public class FormSubmissionMetaUserDetails : FormSubmissionUser
    {
        [JsonProperty]
        public FormSubmissionSupervisor supervisor
        {
            get; internal set;
        }

    }

    public class FormSubmissionMetaKey
    {
        [JsonProperty]
        public string id
        {
            get; internal set;
        }
        [JsonProperty]
        public string name
        {
            get; internal set;
        }
    }

    public class FormSubmissionMetaValidationResult
    {
        [JsonProperty]
        public bool isInvalid
        {
            get; internal set;
        }
        [JsonProperty]
        public string error
        {
            get; internal set;
        }
    }

    public class FormSubmissionMetadata
    {
        [JsonProperty]
        public string submissionId
        {
            get; internal set;
        }
        [JsonProperty]
        public long formId
        {
            get; internal set;
        }
        [JsonProperty]
        public string formName
        {
            get; internal set;
        }
        [JsonProperty]
        public string dateTimeSubmitted
        {
            get; internal set;
        }
        [JsonProperty]
        public FormSubmissionMetaUserDetails user
        {
            get; internal set;
        }
        [JsonProperty]
        public FormSubmissionMetaKey key
        {
            get; internal set;
        }
        [JsonProperty]
        public string externalId
        {
            get; set;
        }
        public string jobId
        {
            get; set;
        }
        public FormSubmissionMetaValidationResult validationResult
        {
            get; set;
        }
        public string submissionTitle
        {
            get; set;
        }
    }

    public class FormSubmissionSearchResult : SearchResult
    {
        [JsonProperty]
        public List<FormSubmissionMetadata> formSubmissionMeta
        {
            get; internal set;
        }
    }
}
