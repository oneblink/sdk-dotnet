# OneBlink .Net SDK | FormsAppEnvironments Class

## Instance Functions

- [`Search()`](#search)
- [`Get()`](#get)
- [`Create()`](#create)
- [`Update()`](#update)
- [`Delete()`](#delete)

## Constructor

| Parameter    | Required | Type         | Description                                                                                                                       | Default Value         |
| ------------ | -------- | ------------ | --------------------------------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink, requires the `FORMS` permission.                                                                 |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink, requires the `FORMS` permission.                                                                 |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK`, `TenantName.ONEBLINK_US` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

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

| Parameter     | Required | Type    | Description                         |
| ------------- | -------- | ------- | ----------------------------------- |
| `limit`       | No       | `int?`  | The number of records to be fetch   |
| `offset`      | No       | `int?`  | The number of records to be skipped |
| `workspaceId` | No       | `long?` | Filter by workspaceId               |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppEnvironmentsSearchResult` class

**Minimum Role Permission**

Environments: _Read Only_

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

**Minimum Role Permission**

Environments: _Read Only_

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

**Minimum Role Permission**

Environments: _Manager_

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

**Minimum Role Permission**

Environments: _Manager_

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

**Minimum Role Permission**

Environments: _Manager_

## `SetSendingAddress()`

### Example

```c#
long formsAppEnvironmentId = 1;
OneBlink.SDK.Model.NewFormsAppEnvironmentSendingAddress newFormsAppEnvironmentSendingAddress = new OneBlink.SDK.Model.NewFormsAppEnvironmentSendingAddress(
    emailAddress: "user@oneblink.io",
    emailName: "User Name"
);

OneBlink.SDK.Model.FormsAppEnvironmentSendingAddressResponse sendingAddress = await formsAppEnvironmentsClient.SetSendingAddress(formsAppEnvironmentId, newFormsAppEnvironmentSendingAddress);
```

### Parameters

| Parameter                              | Required | Type                                                                                     | Description                                 |
| -------------------------------------- | -------- | ---------------------------------------------------------------------------------------- | ------------------------------------------- |
| `id`                                   | Yes      | `long`                                                                                   | The identifier of the Forms App Environment |
| `newFormsAppEnvironmentSendingAddress` | Yes      | [NewFormsAppEnvironmentSendingAddress](./models/NewFormsAppEnvironmentSendingAddress.md) | The Sending address information to set      |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.FormsAppEnvironmentSendingAddressResponse` class

**Minimum Role Permission**

Environments: _Manager_

## `DeleteSendingAddress()`

### Example

```c#
long formsAppEnvironmentId = 1;

await formsAppEnvironmentsClient.DeleteSendingAddress(formsAppEnvironmentId);
```

### Parameters

| Parameter | Required | Type   | Description                               |
| --------- | -------- | ------ | ----------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the FormsAppEnvironment |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

**Minimum Role Permission**

Environments: _Manager_

## `GetSendingAddress()`

### Example

```c#
long formsAppEnvironmentId = 1;

OneBlink.SDK.Model.FormsAppEnvironmentSendingAddressResponse sendingAddress = await formsAppEnvironmentsClient.GetSendingAddress(formsAppEnvironmentId);
```

### Parameters

| Parameter | Required | Type   | Description                               |
| --------- | -------- | ------ | ----------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the FormsAppEnvironment |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.FormsAppEnvironmentSendingAddressResponse` class

**Minimum Role Permission**

Environments: _Read Only_
