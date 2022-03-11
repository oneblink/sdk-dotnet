# OneBlink .Net SDK | Job Model

## `Job()`

### Constructor

| Parameter    | Required | Type                          | Description                          | Default Value |
| ------------ | -------- | ----------------------------- | ------------------------------------ | ------------- |
| `username`   | No       | `string`                      | Username associated with the job.    | null          |
| `formId`     | No       | `long`                        | formId associated with the job.      | null          |
| `details`    | No       | [`JobDetail`](./jobDetail.md) | Instance of the job's details.       | null          |
| `externalId` | No       | `string`                      | external Id associated with the job. | null          |

### Example

```c#
OneBlink.SDK.Model.Job jobToCreate = new OneBlink.SDK.Model.Job(
  username: "developer@oneblink.io",
  formId: 4,
  details: jobToCreateDetails,
  externalId: "MyExternalId"
);

```

### Extra properties available on jobs returned from searchJobs (these will be null on your own instantiated jobs)

| Property            | Type       | Description                               | Default Value |
| ------------------- | ---------- | ----------------------------------------- | ------------- |
| `id`                | `string`   | The unique id of the job                  | null          |
| `isSumbitted`       | `string`   | Whether the job has been submitted or not | null          |
| `createdAt`         | `DateTime` | The time the job was created at           | null          |
| `prefillFormDataId` | `string`   | prefillFormDataId associated with the job | null          |
