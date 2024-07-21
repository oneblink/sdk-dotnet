# OneBlink .Net SDK | DataManagerClient Class

## Instance Functions

- [`GetFormDefinition()`](#getformdefinition)
- [`Search()`](#search)

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
DataManagerClient dataManagerClient = new DataManagerClient(accessKey, secretKey);
```

## `GetFormDefinition()`

### Example

```c#
long formId = 1;
FormStoreDefinition response = await approvalsClient.GetFormDefinition(formId);
```

### Parameters

| Parameter | Required | Type   | Description |
| --------- | -------- | ------ | ----------- |
| `formId`  | Yes      | `long` | The form id |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormStoreDefinition` Object

### Role Permissions Required

Form Submissions: `Manager` or `Read Only`

## `Search()`

### Example

```c#
private class SubmissionResult
{
    public long? just_a_number
    {
        get; set;
    }
}
long formId = 1;
FormStoreSearchRequest request = new FormStoreSearchRequest();
request.formId = formId;
request.filters = new FormStoreSearchFilter();
FormStoreSearchNumberFilter numberFilter = new FormStoreSearchNumberFilter();
numberFilter.eq = 3;
request.filters.submission = new Dictionary<string, IFormStoreInterface>();
request.filters.submission.Add("just_a_number", numberFilter);
FormStoreSearchResult<SubmissionResult> response = await dataManagerClient.Search<SubmissionResult>(request);
```

### Parameters

| Parameter | Required | Type                     | Description                                           |
| --------- | -------- | ------------------------ | ----------------------------------------------------- |
| `request` | Yes      | `FormStoreSearchRequest` | The object used to set the search criteria            |
| `<T>`     | Yes      | Object                   | The object used to deserialise the submission data to |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormStoreSearchResult<T>` Object

### Role Permissions Required

Form Submissions: `Manager` or `Read Only`
