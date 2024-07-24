# OneBlink .Net SDK | FormsAppEnvironments Class

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
FormsAppEnvironmentsClient formsAppEnvironmentsClient = new FormsAppEnvironmentsClient(accessKey, secretKey);
```

## `Search()`

### Example

```c#

int? limit = null;
int? offset = null;

OneBlink.SDK.Model.FormsAppEnvironmentsSearchResult response = await formsAppEnvironmentsClient.Search(limit, offset);
```

### Parameters

| Parameter | Required | Type   | Description                         |
| --------- | -------- | ------ | ----------------------------------- |
| `limit`   | No       | `int?` | The number of records to be fetch   |
| `offset`  | No       | `int?` | The number of records to be skipped |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppEnvironmentsSearchResult` class

### Role Permissions Required

Environments: `Manager` or `Read Only`

## `Get()`

Retrieve a forms app environment by id

### Example

```c#
long id = 123;

OneBlink.SDK.Model.FormsAppEnvironment formsAppEnvironment = await formsAppEnvironmentsClient.Get(id);
```

### Parameters

| Parameter | Required | Type   | Description                                 |
| --------- | -------- | ------ | ------------------------------------------- |
| `id`      | Yes      | `long` | Id of forms app environment to be retrieved |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppEnvironments` class

### Role Permissions Required

Environments: `Manager` or `Read Only`

## `Create()`

Create a new forms app environment

### Example

```c#
FormsAppEnvironment newFormsAppEnvironment = {...};

OneBlink.SDK.Model.FormsAppEnvironment savedFormsAppEnvironment = await formsAppsEnvironmentsClient.Create(newFormsAppEnvironment);
```

### Parameters

| Parameter                | Required | Type                  | Description                      |
| ------------------------ | -------- | --------------------- | -------------------------------- |
| `newFormsAppEnvironment` | Yes      | `FormsAppEnvironment` | New Forms App Environment object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppEnvironment` class

### Role Permissions Required

Environments: `Manager`

## `Update()`

Update a forms app environment

### Example

```c#
FormsAppEnvironment formsAppEnvironmentToUpdate = {...};

OneBlink.SDK.Model.FormsAppEnvironment updatedFormsAppEnvironment = await formsAppEnvironmentClient.Update(formsAppEnvironmentToUpdate);
```

### Parameters

| Parameter                     | Required | Type                  | Description                           |
| ----------------------------- | -------- | --------------------- | ------------------------------------- |
| `formsAppEnvironmentToUpdate` | Yes      | `FormsAppEnvironment` | Existing Forms App Environment object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppEnvironment` class

### Role Permissions Required

Environments: `Manager`

## `Delete()`

### Example

```c#
long formsAppEnvironmentId = 1;

await formsClient.Delete(formsAppEnvironmentId);
```

### Parameters

| Parameter | Required | Type   | Description                                               |
| --------- | -------- | ------ | --------------------------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the forms app environment to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

### Role Permissions Required

Environments: `Manager`
