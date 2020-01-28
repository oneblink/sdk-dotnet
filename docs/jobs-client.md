# OneBlink .Net SDK | JobsClient Class

## Instance Functions

-   [`CreateJob(job)`](<#CreateJob(job)>)
-   [`CreateJob(job, <T>)`](<#CreateJob(job, T)>)
-   [`DeleteJob(jobId)`](#DeleteJob)
-   [`Search(searchParams)`](<#Search(searchParams)>)
-   [`SearchByExternalId(externalId)`](<#SearchByExternalId(externalId)>)
-   [`SearchByFormId(formId)`](<#SearchByFormId(formId)>)
-   [`SearchByUsername(username)`](<#SearchByUsername(username)>)

## Constructor

| Parameter   | Required | Type     | Description                      | Default Value |
| ----------- | -------- | -------- | -------------------------------- | ------------- |
| `accessKey` | Yes      | `string` | Access key provided by OneBlink. |               |
| `secretKey` | Yes      | `string` | Secret key provided by OneBlink. |               |

### Example

```c#
using OneBlink.SDK;
string accessKey = "123455678901ABCDEFGHIJKL";
string secretKey = "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
JobsClient jobsClient = new JobsClient(accessKey, secretKey);
```

## `CreateJob(job)`

### Example

```c#
OneBlink.SDK.Model.JobDetail jobDetail = new OneBlink.SDK.Model.JobDetail("TITLE-01");

// Further details about the job can be added optionally to the jobDetail object
jobDetail.key = "KEY-01";
jobDetail.description = "DESCRIPTION-01";
jobDetail.type = "TYPE-01";

int formId = 1;

string username = "developers@oneblink.io";

// Construct the Job object
OneBlink.SDK.Model.Job job = new Job(jobDetail, formId, username);

OneBlink.SDK.Model.Job job = await jobsClient.CreateJob(job);
```

### Parameters

| Parameter                    | Required | Type                           | Description                                                                                                                                                                                           |
| ---------------------------- | -------- | ------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `job`                     | Yes      | `OneBlink.SDK.Model.Job`    | An object containing the data to be used to create the new Job                                                                                                                                    |
| `job.formId`              | Yes      | `number`                       | The identifier of the Form the User must complete                                                                                                                                                     |
| `job.externalId`          | No       | `string`                       | The external identifier of the form submission you wish to use, this identifier will be returned to you with the `submissionId` after a successful submission to allow you to retrieve the data later |
| `job.username`            | Yes      | `string`                       | The identifier of the User to assign the Job to                                                                                                                                                       |
| `job.details`             | Yes      | `OneBlink.SDK.Model.JobDetail` | Extra Job details that will be displayed to the User                                                                                                                                                  |
| `job.details.key`         | No       | `string`                       | A key for the User to identify the Job                                                                                                                                                                |
| `job.details.title`       | Yes      | `string`                       | A title for the User to identify the Job                                                                                                                                                              |
| `job.details.description` | No       | `string`                       | A short description of what the job may entail                                                                                                                                                        |
| `job.details.type`        | No       | `string`                       | A type for the User to categorise the Job                                                                                                                                                             |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.Job` Object

## `CreateJob(job, T)`

### Example

```c#
OneBlink.SDK.Model.JobDetail jobDetail = new OneBlink.SDK.Model.JobDetail("TITLE-01");

// Further details about the job can be added optionally to the jobDetail object
jobDetail.key = "KEY-01";
jobDetail.description = "DESCRIPTION-01";
jobDetail.type = "TYPE-01";

int formId = 1;

string username = "developers@oneblink.io";

string externalId = "MY_EXTERNAL_ID";

// Construct the Job object
OneBlink.SDK.Model.Job job = new Job(jobDetail, formId, username, externalId);

// "Pre fill data" - key/value object matching the fields in the form that the job is being created for
MyPreFillDataType preFillData = new MyPreFillDataType();
preFillData.field1 = "ABC";
preFillData.field2 = "DEF";

OneBlink.SDK.Model.Job job = await jobsClient.CreateJob<MyPreFillDataType>(job, preFillData);
```

### Parameters

| Parameter                    | Required | Type                           | Description                                                                                                                                                                                           |
| ---------------------------- | -------- | ------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `job`                     | Yes      | `OneBlink.SDK.Model.Job`    | An object containing the new job data to be used to create the Job                                                                                                                                    |
| `job.formId`              | Yes      | `number`                       | The identifier of the Form the User must complete                                                                                                                                                     |
| `job.externalId`          | No       | `string`                       | The external identifier of the form submission you wish to use, this identifier will be returned to you with the `submissionId` after a successful submission to allow you to retrieve the data later |
| `job.username`            | Yes      | `string`                       | The identifier of the User to assign the Job to                                                                                                                                                       |
| `job.details`             | Yes      | `OneBlink.SDK.Model.JobDetail` | Extra Job details that will be displayed to the User                                                                                                                                                  |
| `job.details.key`         | No       | `string`                       | A key for the User to identify the Job                                                                                                                                                                |
| `job.details.title`       | Yes      | `string`                       | A title for the User to identify the Job                                                                                                                                                              |
| `job.details.description` | No       | `string`                       | A short description of what the job may entail                                                                                                                                                        |
| `job.details.type`        | No       | `string`                       | A type for the User to categorise the Job                                                                                                                                                             |
| `preFillData`                | No       | `T (Generic)`                  | key/value pairs with the form field names as keys and the pre-fill data as the values                                                                                                                 |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.Job` Object

## `DeleteJob(jobId)`

### Example

```c#
string jobId = 1;

await jobsClient.DeleteJob(jobId);
```

### Parameters

| Parameter | Required | Type     | Description                             |
| --------- | -------- | -------- | --------------------------------------- |
| `jobId`   | Yes      | `number` | The identifier of the Job to be deleted |
|           |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

No return value (`void`)

## `Search(searchParams)`

### Example

```c#
JobsSearchParameters searchParams = new JobsSearchParameters()
{
  formId = 1,
  externalId = "1234abcd"
};

JobsSearchResult results = await jobsClient.Search(searchParams);
```

### Parameters

| Parameter                          | Required | Type                                      | Description                                                                                       |
| ---------------------------------- | -------- | ----------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `JobsSearchParameters`             | Yes      | `OneBlink.SDK.Model.JobsSearchParameters` | Object containing search parameters described below.                                              |
| `JobsSearchParameters.formId`      | no       | `number`                                  | Search on the `formId` property of a Job.                                                         |
| `JobsSearchParameters.isSubmitted` | no       | `boolean`                                 | Search on the `isSubmitted` property of a Job. Must be either `true` or `false` or not specified. |
| `JobsSearchParameters.externalId`  | no       | `string`                                  | Search on the `externalId` property of a Job. Must be a string, or not specified                  |
| `JobsSearchParameters.username`    | no       | `string`                                  | Search on the `username` property of a Job.                                                       |
| `JobsSearchParameters.limit`       | no       | `number`                                  | Limit the number of results returned                                                              |
| `JobsSearchParameters.offset`      | no       | `number`                                  | Skip a specific number of results, used in conjunction with `limit` to enforce paging             |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

Returns a `OneBlink.SDK.Model.JobsSearchResult` object.

## `SearchByExternalId(externalId)`

### Example

```c#
string externalId = "1234";

JobsSearchResult results = await jobsClient.SearchByExternalId(externalId);
```

### Parameters

| Parameter    | Required | Type     | Description                                                                      |
| ------------ | -------- | -------- | -------------------------------------------------------------------------------- |
| `externalId` | yes      | `string` | Search on the `externalId` property of a Job. Must be a string, or not specified |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

Returns a `OneBlink.SDK.Model.JobsSearchResult` object.

## `SearchByFormId(formId)`

### Example

```c#
int formId = 10;

JobsSearchResult results = await jobsClient.SearchByFormId(formId);
```

### Parameters

| Parameter | Required | Type     | Description                               |
| --------- | -------- | -------- | ----------------------------------------- |
| `formId`  | yes      | `number` | Search on the `formId` property of a Job. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

Returns a `OneBlink.SDK.Model.JobsSearchResult` object.

## `SearchByUsername(username)`

### Example

```c#
string username = "developers@oneblink.io";

JobsSearchResult results = await jobsClient.SearchByUsername(username);
```

### Parameters

| Parameter  | Required | Type     | Description                                 |
| ---------- | -------- | -------- | ------------------------------------------- |
| `username` | yes      | `string` | Search on the `username` property of a Job. |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

Returns a `OneBlink.SDK.Model.JobsSearchResult` object.
