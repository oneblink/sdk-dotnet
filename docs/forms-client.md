# OneBlink .Net SDK | FormsClient Class

## Instance Functions

-   [`GetFormSubmission()`](#getformsubmission)
-   [`Search()`](#search)

## Constructor

| Parameter    | Required | Type         | Description                                                                    | Default Value       |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------ | ------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink.                                               |                     |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink.                                               |                     |
| `tenantName` | No       | `TenantName` | Sets the url to be used. Options are `RegionCode.AU` and `RegionCode.US`.      | TenantName.ONEBLINK |
| `originApi`  | No       | `string`     | Url to override the apiOrigin. Cannot be used in conjunction with `RegionCode` |                     |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
FormsClient formsClient = new FormsClient(accessKey, secretKey);
```

## `GetFormSubmission()`

### Example

```c#
int formId = 1;
string submissionId = "f33055e4-f8c1-49a6-8605-27f0d11854f0";
bool isDraft = false
OneBlink.SDK.Model.FormSubmission<object> formSubmission = await formsClient.GetFormSubmission<object>(formId, submissionId, isDraft);
Console.WriteLine("Submission as JSON string: " + formSubmission.submission);
```

### Parameters

| Parameter      | Required | Type     | Description                                                                                                                                               |
| -------------- | -------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `formId`       | Yes      | `int`    | The exact id of the form you wish to get submission data for                                                                                              |
| `submissionId` | Yes      | `string` | The submission identifier generated after a successful form submission, this will be return to you after a successful forms submission via a callback URL |
| `isDraft`      | Yes      | `bool`   | `true` if the submission is a draft submission, otherwise `false`                                                                                         |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmission<T>` class

## `Search()`

### Example

```c#
bool? isAuthenticated = null;
bool? isPublished = null;
string name = null;
OneBlink.SDK.Model.FormsSearchResult response = await formsClient.Search(isAuthenticated, isPublished, name);
```

### Parameters

| Parameter         | Required | Type     | Description                                                                                                                                  |
| ----------------- | -------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| `isAuthenticated` | Yes      | `bool?`  | Return authenticated forms or unauthenticated forms. If null provided, all forms will be returned.                                           |
| `isPublished`     | Yes      | `bool?`  | Return published forms or unpublished forms. If null provided, all forms will be returned.                                                   |
| `name`            | Yes      | `string` | Search on the name property of a form. Can be a prefix, suffix or partial match. If null or whitespace provided, all forms will be returned. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormsSearchResult` class

## `SearchSubmissions(int formId)`

Search for details on submissions that match the formId provided.
Then use the information to fetch the actual submission data, if it is still available

### Example

```c#

int? formId = 123;

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId);
```

### Parameters

| Parameter | Required | Type  | Description                                     |
| --------- | -------- | ----- | ----------------------------------------------- |
| `formId`  | Yes      | `int` | Search for Submissions for a particular form Id |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissions(int formId, DateTime submissionDateFrom, DateTime submissionDateTo)`

Search for details on submissions for a particular formId that occurred between the given dates.
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

int? formId = 123;

DateTime submissionDateTo = DateTime.Now;

TimeSpan week = new TimeSpan(7, 0, 0, 0);

DateTime submissionDateFrom = DateTime.Now.Subtract(week);

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateFrom, submissionDateTo);
```

### Parameters

| Parameter            | Required | Type        | Description                                                        |
| -------------------- | -------- | ----------- | ------------------------------------------------------------------ |
| `formId`             | Yes      | `int`       | Search for Submissions for a particular form Id                    |
| `submissionDateFrom` | No       | `DateTime?` | Limit results to submissions submitted **after** a date and time.  |
| `submissionDateTo`   | No       | `DateTime?` | Limit results to submissions submitted **before** a date and time. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissionsFromDate(int formId, DateTime submissionDateFrom)`

Search for details on submissions for a particular formId that occurred **after** a given date.
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

int? formId = 123;

TimeSpan week = new TimeSpan(7, 0, 0, 0);

DateTime submissionDateFrom = DateTime.Now.Subtract(week);

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateFrom);
```

### Parameters

| Parameter            | Required | Type        | Description                                                       |
| -------------------- | -------- | ----------- | ----------------------------------------------------------------- |
| `formId`             | Yes      | `int`       | Search for Submissions for a particular form Id                   |
| `submissionDateFrom` | No       | `DateTime?` | Limit results to submissions submitted **after** a date and time. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissionsToDate(int formId, DateTime submissionDateTo)`

Search for details on submissions for a particular formId that occurred **before** a given date.
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

int? formId = 123;

DateTime submissionDateTo = DateTime.Now;

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateTo);
```

### Parameters

| Parameter          | Required | Type        | Description                                                        |
| ------------------ | -------- | ----------- | ------------------------------------------------------------------ |
| `formId`           | Yes      | `int`       | Search for Submissions for a particular form Id                    |
| `submissionDateTo` | No       | `DateTime?` | Limit results to submissions submitted **before** a date and time. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class
