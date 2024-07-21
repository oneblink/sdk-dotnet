# OneBlink .Net SDK | FormElementListsClient Class

## Instance Functions

- [`Search()`](#search)
- [`Create()`](#create)
- [`Update()`](#update)
- [`Delete()`](#delete)

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
FormElementListsClient formElementListsClient = new FormElementListsClient(accessKey, secretKey);
```

## `Search()`

### Example

```c#
int? limit = null;
int? offset = null;
string organisationId = null;

OneBlink.SDK.Model.FormElementListsSearchResult response = await formElementListsClient.Search(limit, offset, organisationId);
```

### Parameters

| Parameter        | Required | Type     | Description                                               |
| ---------------- | -------- | -------- | --------------------------------------------------------- |
| `limit`          | No       | `int?`   | The number of records to be fetch                         |
| `offset`         | No       | `int?`   | The number of records to be skipped                       |
| `organisationId` | No       | `string` | The organisationId of the organisation you want to search |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementListSearchResult` class

### Role Permissions Required

No Permissions Required

## `Create()`

Create a new form element list

### Example

```c#
FormElementList newFormElementList = {...};

OneBlink.SDK.Model.FormElementList savedFormElementList = await formElementListsClient.Create(newFormElementList);
```

### Parameters

| Parameter            | Required | Type              | Description                  |
| -------------------- | -------- | ----------------- | ---------------------------- |
| `newFormElementList` | Yes      | `FormElementList` | New form element list object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementList` class

### Role Permissions Required

Form Element Lists: `Manager`

## `Update()`

Update a form element list

### Example

```c#
FormElementList formElementListToUpdate = {...};

OneBlink.SDK.Model.FormElementList updatedFormElementList = await formElementListsClient.Update(formElementListToUpdate);
```

### Parameters

| Parameter                 | Required | Type              | Description                       |
| ------------------------- | -------- | ----------------- | --------------------------------- |
| `formElementListToUpdate` | Yes      | `FormElementList` | Existing form element list object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementList` class

### Role Permissions Required

Form Element Lists: `Manager`

## `Delete()`

### Example

```c#
long formElementListId = 1;

await formElementListsClient.Delete(formElementListId);
```

### Parameters

| Parameter | Required | Type   | Description                                           |
| --------- | -------- | ------ | ----------------------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the form element list to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

### Role Permissions Required

Form Element Lists: `Manager`
