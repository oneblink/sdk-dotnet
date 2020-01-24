# OneBlink .Net SDK | Model Classes

## Models

-   [`Job()`](<#Job()>)
-   [`JobDetail()`](<#JobDetails()>)
-   [`JobsSearchParameters()`](<#JobsSearchParameters()>)

## `Job()`

### Constructor

| Parameter           | Required | Type                          | Description                               | Default Value |
| ------------------- | -------- | ----------------------------- | ----------------------------------------- | ------------- |
| `username`          | No       | `string`                      | Username associated with the job.         | null          |
| `formId`            | No       | `int`                         | formId associated with the job.           | null          |
| `details`           | No       | [`JobDetail`](<#JobDetail()>) | Instance of the job's details.            | null          |
| `externalId`        | No       | `string`                      | external Id associated with the job.      | null          |
| `prefillFormDataId` | No       | `string`                      | prefillFormDataId associated with the job | null          |

### Example

```c#
OneBlink.SDK.Model.Job jobToCreate = new OneBlink.SDK.Model.Job(
  username: "developer@oneblink.io",
  formId: 4,
  details: jobToCreateDetails,
  externalId: "MyExternalId",
  prefillFormDataId: "MyPrefillFormDataId"
);

```

### Extra properties available on jobs returned from searchJobs (these will be null on your own instantiated jobs)

| Property      | Type       | Description                               | Default Value |
| ------------- | ---------- | ----------------------------------------- | ------------- |
| `id`          | `string`   | The unique id of the job                  | null          |
| `isSumbitted` | `string`   | Whether the job has been submitted or not | null          |
| `createdAt`   | `DateTime` | The time the job was created at           | null          |

## `JobDetail()`

### Constructor

| Parameter     | Required | Type     | Description             | Default Value |
| ------------- | -------- | -------- | ----------------------- | ------------- |
| `title`       | Yes      | `string` | Title of the job.       |               |
| `key`         | No       | `string` | Key of the job.         | null          |
| `type`        | No       | `string` | Type of the job.        | null          |
| `description` | No       | `string` | Description of the job. | null          |

### Example

```c#
OneBlink.SDK.Model.JobDetail jobToCreateDetails = new OneBlink.SDK.Model.JobDetail(
  title: "My Job Title",
  key: "My Key",
  type: "My Job type",
  description: "My Job description"
);

```

## `JobsSearchParameters()`

### Constructor

| Parameter     | Required | Type      | Description                           | Default Value |
| ------------- | -------- | --------- | ------------------------------------- | ------------- |
| `username`    | No       | `string`  | The username to filter by.            | null          |
| `formId`      | No       | `int`     | The formId to filter by.              | null          |
| `isSubmitted` | No       | `Boolean` | Whether to search for submitted jobs. | null          |
| `externalId`  | No       | `string`  | The externalId to filter by.          | null          |
| `limit`       | No       | `int`     | limit to apply to results.            | null          |
| `offset`      | No       | `int`     | offset to apply to results.           | null          |

### Example

```c#
OneBlink.SDK.Model.JobsSearchParameters jobsSearchParameters = new OneBlink.SDK.Model.JobsSearchParameters(
  username: "user@oneblink.io",
  formId: 12,
  isSubmitted: true,
  externalId: "12345678",
  limit: 10,
  offset: 40
);

```
