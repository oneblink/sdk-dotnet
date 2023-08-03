# OneBlink .Net SDK | FormsClient Class

## Static Functions

-   [`DecryptUserToken()`](#DecryptUserToken)
-   [`EncryptUserToken()`](#EncryptUserToken)

## `DecryptUserToken()`

### Example

```c#
string username = FormsClient.DecryptUserToken(
    userToken: userToken,
    secret: secret
);
```

### Parameters

| Parameter   | Required | Type   | Description                                        |
| ----------- | -------- | ------ | -------------------------------------------------- |
| `userToken` | Yes      | string | The `userToken` to decrypt                         |
| `secret`    | Yes      | string | The secret that the `userToken` was encrypted with |

### Throws

-   `Exception`

### Result

A `string`

## `EncryptUserToken()`

### Example

```c#
string userToken = FormsClient.EncryptUserToken(
    username: userToken,
    secret: secret
);
```

### Parameters

| Parameter  | Required | Type   | Description                               |
| ---------- | -------- | ------ | ----------------------------------------- |
| `username` | Yes      | string | The `username` to encrypt                 |
| `secret`   | Yes      | string | The secret to encrypt the `username` with |

### Throws

-   `Exception`

### Result

A `string`

## Instance Functions

-   [`GetFormSubmission()`](#getformsubmission)
-   [`Search()`](#search)
-   [`Get()`](#get)
-   [`Create()`](#create)
-   [`Update()`](#update)
-   [`Delete()`](#delete)
-   [`GenerateFormUrl()`](#generateformurl)
-   [`GenerateSubmissionDataUrl()`](#generatesubmissiondataurl)
-   [`GetFormSubmissionAttachment()`](#getformsubmissionattachment)
-   [`GetFormSubmissionAttachmentMeta()`](#getformsubmissionattachmentmeta)
-   [`CreateSubmissionAttachment()`](#createsubmissionattachment)
-   [`GenerateSubmissionAttachmentUrl()`](#generatesubmissionattachmenturl)
-   [`GenerateWorkflowAttachmentLink()`](#generateworkflowattachmentlink)
-   [`GetFormSubmissionMeta()`](#getformsubmissionmeta)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value         |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

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
long formId = 1;
string submissionId = "f33055e4-f8c1-49a6-8605-27f0d11854f0";
bool isDraft = false
OneBlink.SDK.Model.FormSubmission<object> formSubmission = await formsClient.GetFormSubmission<object>(formId, submissionId, isDraft);
Console.WriteLine("Submission as JSON string: " + formSubmission.submission);
```

### Parameters

| Parameter      | Required | Type     | Description                                                                                                                                               |
| -------------- | -------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `formId`       | Yes      | `long`   | The exact id of the form you wish to get submission data for                                                                                              |
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
long? formsAppEnvironmentId  = null;

OneBlink.SDK.Model.FormsSearchResult response = await formsClient.Search(isAuthenticated, isPublished, name, formsAppEnvironmentId, 200, 0);
```

### Parameters

| Parameter                | Required | Type     | Description                                                                                                                                  |
| ------------------------ | -------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| `isAuthenticated`        | Yes      | `bool?`  | Return authenticated forms or unauthenticated forms. If null provided, all forms will be returned.                                           |
| `isPublished`            | Yes      | `bool?`  | Return published forms or unpublished forms. If null provided, all forms will be returned.                                                   |
| `name`                   | Yes      | `string` | Search on the name property of a form. Can be a prefix, suffix or partial match. If null or whitespace provided, all forms will be returned. |
| `formsAppEnvironmentId ` | No       | `long?`  | Return only forms for a specific app environment.                                                                                            |
| `formsAppId`             | No       | `long?`  | Return only forms for a specific app.                                                                                                        |
| `limit`                  | no       | `int?`   | Limit the number of results returned. Used with `offset` to control pagination. Defaults to `200`. Cannot exceed `200`.                      |
| `offset`                 | no       | `int?`   | Offset the results returned by the value specified. Used with `limit` to control pagination. Defaults to `0`.                                |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormsSearchResult` class

## `SearchSubmissions(long formId)`

Search for details on submissions that match the formId provided.
Then use the information to fetch the actual submission data, if it is still available

### Example

```c#

long formId = 123;

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId);
```

### Parameters

| Parameter | Required | Type   | Description                                                                                         |
| --------- | -------- | ------ | --------------------------------------------------------------------------------------------------- |
| `formId`  | Yes      | `long` | Search for Submissions for a particular form Id                                                     |
| `limit`   | no       | `int`  | Limit the number of results returned. Can be used with `offset` to enforce pagination.              |
| `offset`  | no       | `int`  | Offset the results returned by the value specified. Can be used with `limit` to enforce pagination. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissions(long formId, DateTime submissionDateFrom, DateTime submissionDateTo, int limit, int offset, bool? isValid, string submissionTitle`

Search for details on submissions for a particular formId with various criteria
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

long formId = 123;

DateTime submissionDateTo = DateTime.Now;

TimeSpan week = new TimeSpan(7, 0, 0, 0);

DateTime submissionDateFrom = DateTime.Now.Subtract(week);

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateFrom, submissionDateTo);
```

### Parameters

| Parameter            | Required | Type        | Description                                                                                         |
| -------------------- | -------- | ----------- | --------------------------------------------------------------------------------------------------- |
| `formId`             | Yes      | `long`      | Search for Submissions for a particular form Id                                                     |
| `submissionDateFrom` | No       | `DateTime?` | Limit results to submissions submitted **after** a date and time.                                   |
| `submissionDateTo`   | No       | `DateTime?` | Limit results to submissions submitted **before** a date and time.                                  |
| `limit`              | no       | `int`       | Limit the number of results returned. Can be used with `offset` to enforce pagination.              |
| `offset`             | no       | `int`       | Offset the results returned by the value specified. Can be used with `limit` to enforce pagination. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissionsFromDate(long formId, DateTime submissionDateFrom)`

Search for details on submissions for a particular formId that occurred **after** a given date.
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

long formId = 123;

TimeSpan week = new TimeSpan(7, 0, 0, 0);

DateTime submissionDateFrom = DateTime.Now.Subtract(week);

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateFrom);
```

### Parameters

| Parameter            | Required | Type        | Description                                                                                         |
| -------------------- | -------- | ----------- | --------------------------------------------------------------------------------------------------- |
| `formId`             | Yes      | `long`      | Search for Submissions for a particular form Id                                                     |
| `submissionDateFrom` | No       | `DateTime?` | Limit results to submissions submitted **after** a date and time.                                   |
| `limit`              | no       | `int`       | Limit the number of results returned. Can be used with `offset` to enforce pagination.              |
| `offset`             | no       | `int`       | Offset the results returned by the value specified. Can be used with `limit` to enforce pagination. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `SearchSubmissionsToDate(long formId, DateTime submissionDateTo)`

Search for details on submissions for a particular formId that occurred **before** a given date.
Then use the information to fetch the actual submission data, if it is still available.

### Example

```c#

long formId = 123;

DateTime submissionDateTo = DateTime.Now;

OneBlink.SDK.Model.FormSubmissionSearchResult response = await formsClient.SearchSubmissions(formId, submissionDateTo);
```

### Parameters

| Parameter          | Required | Type        | Description                                                                                         |
| ------------------ | -------- | ----------- | --------------------------------------------------------------------------------------------------- |
| `formId`           | Yes      | `long`      | Search for Submissions for a particular form Id                                                     |
| `submissionDateTo` | No       | `DateTime?` | Limit results to submissions submitted **before** a date and time.                                  |
| `limit`            | no       | `int`       | Limit the number of results returned. Can be used with `offset` to enforce pagination.              |
| `offset`           | no       | `int`       | Offset the results returned by the value specified. Can be used with `limit` to enforce pagination. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionSearchResult` class

## `Get()`

Retrieve a form by id and optionally include the details of any child form elements

### Example

```c#
long id = 123;

OneBlink.SDK.Model.Form form = await formsClient.Get(id, false);
```

### Parameters

| Parameter     | Required | Type       | Description                                               |
| ------------- | -------- | ---------- | --------------------------------------------------------- |
| `id`          | Yes      | `long`     | Id of form to be retrieved                                |
| `injectForms` | No       | `Boolean?` | Optionally include the details of any child form elements |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Form` class

## `Create()`

Create a new form

### Example

```c#
Form newForm = {...};

OneBlink.SDK.Model.Form savedForm = await formsClient.Create(newForm);
```

### Parameters

| Parameter | Required | Type   | Description     |
| --------- | -------- | ------ | --------------- |
| `newForm` | Yes      | `Form` | New Form object |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Form` class

## `Update()`

Update a form

### Example

```c#
Form formToUpdate = {...};

OneBlink.SDK.Model.Form updatedForm = await formsClient.Update(formToUpdate);
```

### Parameters

| Parameter      | Required | Type      | Description                                                                                             |
| -------------- | -------- | --------- | ------------------------------------------------------------------------------------------------------- |
| `formToUpdate` | Yes      | `Form`    | Existing Form object                                                                                    |
| `overrideLock` | No       | `boolean` | Defaults to false. Set to true to force updating of the form if the form is locked via the form builder |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Form` class

## `Delete()`

### Example

```c#
long formId = 1;

await formsClient.Delete(formId);
```

### Parameters

| Parameter      | Required | Type      | Description                                                                                             |
| -------------- | -------- | --------- | ------------------------------------------------------------------------------------------------------- |
| `id`           | Yes      | `long`    | The identifier of the Form to be deleted                                                                |
| `overrideLock` | No       | `boolean` | Defaults to false. Set to true to force deleting of the form if the form is locked via the form builder |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

No return value (`void`)

## `GenerateFormUrl()`

### Example

```c#
FormUrlResult result = await formsClient.GenerateFormUrl(
    new FormUrlOptions(
        formId: 5,
        username: "user@oneblink.io",
        secret: "secret",
        previousFormSubmissionApprovalId: 1
    )
);
```

### Parameters

| Parameter    | Required | Type                                 | Description                             |
| ------------ | -------- | ------------------------------------ | --------------------------------------- |
| `parameters` | Yes      | [FormUrlOptions](./models/FormUrlmd) | The parameters used to generate the url |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.FormUrlResult` class

## `GenerateSubmissionDataUrl()`

### Example

```c#
SubmissionDataUrl submissionDataUrl = await formsClient.GenerateSubmissionDataUrl(formId,submissionId, 1000);
```

### Parameters

| Parameter         | Required | Type   | Description              |
| ----------------- | -------- | ------ | ------------------------ |
| `formId`          | Yes      | long   |                          |
| `submissionId`    | Yes      | string |                          |
| `expiryInSeconds` | Yes      | long   | Must be greater than 900 |

### Throws

-   `OneBlinkAPIException`
-   `Exception`
-   `ArgumentOutOfRangeException`

### Result

A `OneBlink.SDK.Model.SubmissionDataUrl` class

## `GetFormSubmissionAttachment()`

### Example

```c#
Stream attachmentStream = await formsClient.GetFormSubmissionAttachment(formId, attachmentId);
```

### Parameters

| Parameter      | Required | Type   | Description |
| -------------- | -------- | ------ | ----------- |
| `formId`       | Yes      | long   |             |
| `attachmentId` | Yes      | string |             |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `System.IO.Stream` class

## `GetFormSubmissionAttachmentMeta()`

### Example

```c#
FormAttachmentMeta meta = await formsClient.GetFormSubmissionAttachmentMeta(formId, attachmentId);
```

### Parameters

| Parameter      | Required | Type   | Description |
| -------------- | -------- | ------ | ----------- |
| `formId`       | Yes      | long   |             |
| `attachmentId` | Yes      | string |             |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormAttachmentMetam` class

## `CreateSubmissionAttachment()`

### Example

```c#
AttachmentData attachmentData = await formsClient.CreateSubmissionAttachment(formId, fileStream,"file.txt", "plain/text", true, "username");
```

### Parameters

| Parameter     | Required | Type   | Description                                                                 |
| ------------- | -------- | ------ | --------------------------------------------------------------------------- |
| `formId`      | Yes      | long   |                                                                             |
| `fileStream`  | Yes      | Stream |                                                                             |
| `fileName`    | Yes      | string |                                                                             |
| `contentType` | Yes      | string |                                                                             |
| `isPrivate`   | Yes      | string | Sets if the file will be private (accessible with credentials) or public    |
| `username`    | Yes      | string | An optional username to allow a single user to download the attachment file |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.AttachmentData` class

## `GenerateSubmissionAttachmentUrl()`

### Example

```c#
SubmissionDataUrl submissionDataUrl = await formsClient.GenerateSubmissionAttachmentUrl(formId, attachmentId, 1000);
```

### Parameters

| Parameter         | Required | Type   | Description                          |
| ----------------- | -------- | ------ | ------------------------------------ |
| `formId`          | Yes      | long   |                                      |
| `attachmentId`    | Yes      | string |                                      |
| `expiryInSeconds` | Yes      | long   | Must be greater than or equal to 900 |

### Throws

-   `OneBlinkAPIException`
-   `Exception`
-   `ArgumentOutOfRangeException`

### Result

A `OneBlink.SDK.Model.SubmissionDataUrl` class

## `GenerateWorkflowAttachmentLink()`

### Example

```c#
SubmissionDataUrl submissionDataUrl = await formsClient.GenerateWorkflowAttachmentLink(formId, submissionId, attachmentId);
```

### Parameters

| Parameter      | Required | Type   | Description                                             |
| -------------- | -------- | ------ | ------------------------------------------------------- |
| `formId`       | Yes      | long   | The exact id of the form you wish to generate a URL for |
| `submissionId` | Yes      | string | The submission identifier for the the form submission   |
| `attachmentId` | Yes      | string | The attachment identifier from the form submission data |

### Throws

-   `OneBlinkAPIException`
-   `Exception`
-   `ArgumentOutOfRangeException`

### Result

A `OneBlink.SDK.Model.SubmissionDataUrl` class

## `Migrate()`

### Example

```c#
FormMigrationOptions formMigrationOptions = new FormMigrationOptions();
// assign formMigrationOptions properties
// ...
// ...
await formsClient.Migrate(formMigrationOptions);
```

### Parameters

| Parameter              | Required | Type                 | Description                |
| ---------------------- | -------- | -------------------- | -------------------------- |
| `formMigrationOptions` | yes      | FormMigrationOptions | The form migration options |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

No return value (`void`)

## `GetFormSubmissionMeta()`

Retrieve the Form Submission metadata for by submission id. This will include the approval associated with the submission if the form had an approval flow setup.

### Example

```c#
string submissionId = "7145544d-853a-47e8-873c-1e849698e414";
OneBlink.SDK.Model.FormSubmissionMetadataResponse formSubmissionMetadataResponse = await formsClient.GetFormSubmissionMeta(id);
```

### Parameters

| Parameter      | Required | Type     | Description                      |
| -------------- | -------- | -------- | -------------------------------- |
| `submissionId` | Yes      | `string` | Id of submission to be retrieved |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormSubmissionMetadataResponse` class
