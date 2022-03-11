# OneBlink .Net SDK | JobsSearchParameters Model

## `JobsSearchParameters()`

### Constructor

| Parameter     | Required | Type      | Description                           | Default Value |
| ------------- | -------- | --------- | ------------------------------------- | ------------- |
| `username`    | No       | `string`  | The username to filter by.            | null          |
| `formId`      | No       | `long`    | The formId to filter by.              | null          |
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
