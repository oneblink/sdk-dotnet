# OneBlink .Net SDK | FormElementLookupsClient Class

## Instance Functions

- [`Search()`](#search)
- [`Get()`](#get)
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
FormElementLookupsClient formElementLookupsClient = new FormElementLookupsClient(accessKey, secretKey);
```

## `Search()`

### Example

```c#
int? limit = null;
int? offset = null;
string organisationId = null;

OneBlink.SDK.Model.FormElementLookupSearchResult response = await formElementLookupsClient.Search(limit, offset, organisationId);
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

A `FormElementLookupSearchResult` class

### Role Permissions Required

No Permissions Required

## `Get()`

Retrieve a form element lookup by id

### Example

```c#
long id = 123;

OneBlink.SDK.Model.FormElementLookup formElementLookup = await formElementLookupsClient.Get(id);
```

### Parameters

| Parameter | Required | Type   | Description                               |
| --------- | -------- | ------ | ----------------------------------------- |
| `id`      | Yes      | `long` | Id of form element lookup to be retrieved |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementLookup` class

### Role Permissions Required

Form Element Lookups: `Manager` or `Read Only`

## `Create()`

Create a new form element lookup

### Example

```c#
FormElementLookup newFormElementLookup = {...};

OneBlink.SDK.Model.FormElementLookup savedFormElementLookup = await formElementLookupsClient.Create(newFormElementLookup);
```

### Parameters

| Parameter              | Required | Type                | Description                    |
| ---------------------- | -------- | ------------------- | ------------------------------ |
| `newFormElementLookup` | Yes      | `FormElementLookup` | New form element lookup object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementLookup` class

### Role Permissions Required

Form Element Lookups: `Manager`

## `Update()`

Update a form element lookup

### Example

```c#
FormElementLookup formElementLookupToUpdate = {...};

OneBlink.SDK.Model.FormElementLookup updatedFormElementLookup = await formElementLookupsClient.Update(formElementLookupToUpdate);
```

### Parameters

| Parameter                   | Required | Type                | Description                         |
| --------------------------- | -------- | ------------------- | ----------------------------------- |
| `formElementLookupToUpdate` | Yes      | `FormElementLookup` | Existing form element lookup object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormElementLookup` class

### Role Permissions Required

Form Element Lookups: `Manager`

## `Delete()`

### Example

```c#
long formElementLookupId = 1;

await formElementLookupsClient.Delete(formElementLookupId);
```

### Parameters

| Parameter | Required | Type   | Description                                             |
| --------- | -------- | ------ | ------------------------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the form element lookup to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

### Role Permissions Required

Form Element Lookups: `Manager`
