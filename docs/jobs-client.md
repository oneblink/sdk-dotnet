# OneBlink .Net SDK | JobsClient Class

## Instance Functions

-   [`CreateJob()`](#CreateJob)
-   [`DeleteJob()`](#DeleteJob)

## Constructor

| Parameter         | Required | Type     | Description                         | Default Value |
| ----------------- | -------- | -------- | ----------------------------------- | ------------- |
| `accessKey`       | Yes      | `string` | Access key provided by OneBlink.    |               |
| `secretKey`       | Yes      | `string` | Secret key provided by OneBlink.    |               |
| `expiryInSeconds` | No       | `int`    | Time in seconds until token expiry. | 300           |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
JobsClient jobsClient = new JobsClient(accessKey, secretKey);
```

## `CreateJob()`

### Example

```c#
OneBlink.SDK.Model.JobDetail jobDetail = new OneBlink.SDK.Model.JobDetail();

int formId = 1;

jobDetail.key = "KEY-01";
jobDetail.title = "TITLE-01";
jobDetail.description = "DESCRIPTION-01";
jobDetail.type = "TYPE-01";

OneBlink.SDK.Model.Job job = await jobsClient.CreateJob(jobDetail, "EXTERNAL_ID", formId, "aaron@oneblink.io");
```

### Parameters

| Parameter              | Required | Type                           | Description                                                                                                                                                                                           |
| ---------------------- | -------- | ------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `username`             | Yes      | `string`                       | The identifier of the User to assign the Job to                                                                                                                                                       |
| `formId`               | Yes      | `number`                       | The identifier of the Form the User must complete                                                                                                                                                     |
| `externalId`           | No       | `string`                       | The external identifier of the form submission you wish to use, this identifier will be returned to you with the `submissionId` after a successful submission to allow you to retrieve the data later |
| `details`              | Yes      | `OneBlink.SDK.Model.JobDetail` | Extra Job details that will be displayed to the User                                                                                                                                                  |
| `.details.key`         | No       | `string`                       | A key for the User to identify the Job                                                                                                                                                                |
| `.details.title`       | Yes      | `string`                       | A title for the User to identify the Job                                                                                                                                                              |
| `.details.description` | No       | `string`                       | A short description of what the job may entail                                                                                                                                                        |
| `.details.type`        | No       | `string`                       | A type for the User to categorise the Job                                                                                                                                                             |
| `preFillData`          | No       | `T (Generic)`                  | key/value pairs with the form field names as keys and the pre-fill data as the values                                                                                                                 |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.Job` class

## `DeleteJob()`

### Example

```c#
string jobId = 1;

await jobsClient.DeleteJob(jobId);
```

### Parameters

| Parameter | Required | Type     | Description                             |
| --------- | -------- | -------- | --------------------------------------- |
| `formId`  | Yes      | `number` | The identifier of the Job to be deleted |
|           |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

No return value (`void`)
