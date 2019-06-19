# OneBlink .Net SDK | FormsClient Class

## Instance Functions

-   [`GetFormSubmission()`](#getformsubmission)
-   [`Search()`](#search)

## Constructor

| Parameter         | Required | Type     | Description                      | Default Value |
| ----------------- | -------- | -------- | -------------------------------- | ------------- |
| `accessKey`       | Yes      | `string` | Access key provided by OneBlink. |               |
| `secretKey`       | Yes      | `string` | Secret key provided by OneBlink. |               |
| `expiryInSeconds` | No       | `int`    | Secret key provided by OneBlink. | 300           |

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
