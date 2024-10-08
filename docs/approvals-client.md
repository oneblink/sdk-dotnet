# OneBlink .Net SDK | ApprovalsClient Class

## Instance Functions

- [`GetFormSubmissionAdministrationApprovals()`](#getformsubmissionadministrationapprovals)
- [`GetFormSubmissionApproval()`](#getformsubmissionapproval)
- [`GetFormApprovalFlowInstance()`](#getformapprovalflowinstance)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value         |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

### Example

```c#
using OneBlink.SDK;
string accessKey = "123455678901ABCDEFGHIJKL";
string secretKey = "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
ApprovalsClient approvalsClient = new ApprovalsClient(accessKey, secretKey);
```

## `GetFormSubmissionAdministrationApprovals()`

### Example

```c#
long formsAppId = 1;
long limit = 1;
long offset = 1;
GetFormSubmissionAdministrationApprovalsResponse response = await approvalsClient.GetFormSubmissionAdministrationApprovals(formsAppId, limit, offset);
```

### Parameters

| Parameter                    | Required | Type           | Description                                         |
| ---------------------------- | -------- | -------------- | --------------------------------------------------- |
| `formsAppId`                 | Yes      | `long`         | The approvals app id                                |
| `limit`                      | Yes      | `long`         | The number of records to be fetch                   |
| `offset`                     | Yes      | `long`         | The number of records to be skipped                 |
| `formId`                     | No       | `long?`        | The id of the form to be filtered by                |
| `externalId`                 | No       | `string`       | A submission externalId to be filtered by           |
| `submissionId`               | No       | `string`       | A submission submissionId to be filtered by         |
| `submittedAfterDateTime`     | No       | `string`       | Submission timestamp after to be filtered by        |
| `submittedBeforeDateTime`    | No       | `string`       | Submission timestamp before to be filtered by       |
| `statuses`                   | No       | `List<string>` | List of approval status's to be filtered by         |
| `updatedAfterDateTime`       | No       | `string`       | Approval updated timestamp after to be filtered by  |
| `updatedBeforeDateTime`      | No       | `string`       | Approval updated timestamp before to be filtered by |
| `lastUpdatedBy`              | No       | `List<string>` | Last updated by user to be filtered by              |
| `formApprovalFlowInstanceId` | No       | `long`         | The form approval flow instance id                  |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `GetFormSubmissionAdministrationApprovalsResponse` Object

**Submission Data Key Supported**

Results will be restricted to approvals associated with forms that have been assigned to the Key.

**Minimum Role Permission**

Submission Data: _Read Only_

## `GetFormSubmissionApproval()`

### Example

```c#
long formSubmissionApprovalId = 1;
GetFormSubmissionApprovalResponse response = await approvalsClient.GetFormSubmissionApproval(formSubmissionApprovalId);
```

### Parameters

| Parameter                  | Required | Type   | Description                     |
| -------------------------- | -------- | ------ | ------------------------------- |
| `formSubmissionApprovalId` | Yes      | `Guid` | The form submission approval id |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `GetFormSubmissionApprovalResponse` Object

**Submission Data Key Supported**

Key must be assigned to the form that was submitted for approval.

**Minimum Role Permission**

Submission Data: _Read Only_

## `GetFormApprovalFlowInstance()`

### Example

```c#
long formApprovalFlowInstanceId = 1;
GetFormApprovalFlowInstanceResponse response = await approvalsClient.GetFormApprovalFlowInstance(formApprovalFlowInstanceId);
```

### Parameters

| Parameter                    | Required | Type   | Description                        |
| ---------------------------- | -------- | ------ | ---------------------------------- |
| `formApprovalFlowInstanceId` | Yes      | `long` | The form approval flow instance id |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `GetFormApprovalFlowInstanceResponse` Object

**Submission Data Key Supported**

Key must be assigned to the form that was submitted for approval.

**Minimum Role Permission**

Submission Data: _Read Only_
