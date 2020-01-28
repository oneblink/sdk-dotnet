# OneBlink .Net SDK | JobDetail Model


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