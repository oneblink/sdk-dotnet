# OneBlink SDK | FormsApps Class

## Instance Functions

- [`VerifyJWT()`](#veryjwt)
- [`Get()`](#get)
- [`Create()`](#create)
- [`Update()`](#update)
- [`Delete()`](#delete)
- [`GetMyFormsApp()`](#getmyformsapp)
- [`SetSendingAddress()`](#setsendingaddress)
- [`DeleteSendingAddress()`](#deletesendingaddress)
- [`GetSendingAddress()`](#getsendingaddress)
- [`CreateUser()`](#createuser)
- [`DeleteUser()`](#deleteuser)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value         |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink, requires the `FORMS` permission.                                       |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK`, `TenantName.ONEBLINK_US` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
FormsAppsClient formsAppsClient = new FormsAppsClient(accessKey, secretKey);
```

## `VerifyJWT()`

### Example

```c#
using OneBlink.SDK.Models;
string jwt = "csf3234dweer234fdft76yw43rfsfgsw33r.234eswefkds3ksefmo34m2wrf.asddesrtij4345fd456";
// or
string jwt = "Bearer csf3234dweer234fdft76yw43rfsfgsw33r.234eswefkds3ksefmo34m2wrf.asddesrtij4345fd456";
JWTPayload result = await formsAppsClient.VerifyJWT(token);

// Will throw an exception if JWT was invalid
```

### Parameters

| Parameter | Required | Type     | Description                |
| --------- | -------- | -------- | -------------------------- |
| `token`   | Yes      | `string` | The JWT you wish to verify |

### Throws

- `Exception`

### Result

A `OneBlink.SDK.Model.JWTPayload` class

## `Get()`

Retrieve a forms app by id

### Example

```c#
long id = 123;

var formsApp = await formsAppsClient.Get<FormsListFormApp>(id);
```

### Parameters

| Parameter | Required | Type                                                                                 | Description                     |
| --------- | -------- | ------------------------------------------------------------------------------------ | ------------------------------- |
| `id`      | Yes      | `long`                                                                               | Id of forms app to be retrieved |
| `<T>`     | Yes      | `ApprovalsFormsApp`, `FormsListFormApp`, `FormStoreFormsApp` or `VolunteersFormsApp` | The type of Forms App           |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `T` class

**Minimum Role Permission**

Apps: _Read Only_

## `Create()`

Create a new forms app

### Example

```c#
FormsListFormApp newFormsApp = {...};

var savedFormsApps = await formsAppsClient.Create<FormsListFormApp>(newFormsApp);
```

### Parameters

| Parameter     | Required | Type                                                                                 | Description           |
| ------------- | -------- | ------------------------------------------------------------------------------------ | --------------------- |
| `newFormsApp` | Yes      | `FormsApp`                                                                           | New FormsApp object   |
| `<T>`         | Yes      | `ApprovalsFormsApp`, `FormsListFormApp`, `FormStoreFormsApp` or `VolunteersFormsApp` | The type of Forms App |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `T` class

**Minimum Role Permission**

Apps: _Manager_

## `Update()`

Update a existing forms app

### Example

```c#
FormsListFormApp formsAppToUpdate = {...};

FormsListFormApp updatedFormsApp = await formsAppsClient.Update<FormsListFormApp>(formsAppToUpdate);
```

### Parameters

| Parameter          | Required | Type                                                                                 | Description              |
| ------------------ | -------- | ------------------------------------------------------------------------------------ | ------------------------ |
| `formsAppToUpdate` | Yes      | `FormsApp`                                                                           | Existing FormsApp object |
| `<T>`              | Yes      | `ApprovalsFormsApp`, `FormsListFormApp`, `FormStoreFormsApp` or `VolunteersFormsApp` | The type of Forms App    |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsApp` class

**Minimum Role Permission**

Apps: _Manager_

## `Delete()`

### Example

```c#
long formsAppId = 1;

await formsAppsClient.Delete(formsAppId);
```

### Parameters

| Parameter | Required | Type   | Description                                  |
| --------- | -------- | ------ | -------------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the FormsApp to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

**Minimum Role Permission**

Apps: _Manager_

## `SetSendingAddress()`

### Example

```c#
long formsAppId = 1;
OneBlink.SDK.Model.NewFormsAppSendingAddress newFormsAppSendingAddress = new OneBlink.SDK.Model.NewFormsAppSendingAddress(
    emailAddress: "user@oneblink.io",
    emailName: "User Name"
);

OneBlink.SDK.Model.FormsAppSendingAddressResponse sendingAddress = await formsAppsClient.SetSendingAddress(formsAppId, newFormsAppSendingAddress);
```

### Parameters

| Parameter                   | Required | Type                                                               | Description                            |
| --------------------------- | -------- | ------------------------------------------------------------------ | -------------------------------------- |
| `id`                        | Yes      | `long`                                                             | The identifier of the FormsApp         |
| `newFormsAppSendingAddress` | Yes      | [NewFormsAppSendingAddress](./models/NewFormsAppSendingAddress.md) | The Sending address information to set |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.FormsAppSendingAddressResponse` class

**Minimum Role Permission**

App Users: _Manager_

## `DeleteSendingAddress()`

### Example

```c#
long formsAppId = 1;

await formsAppsClient.DeleteSendingAddress(formsAppId);
```

### Parameters

| Parameter | Required | Type   | Description                    |
| --------- | -------- | ------ | ------------------------------ |
| `id`      | Yes      | `long` | The identifier of the FormsApp |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

**Minimum Role Permission**

App Users: _Manager_

## `GetSendingAddress()`

### Example

```c#
long formsAppId = 1;

OneBlink.SDK.Model.FormsAppSendingAddressResponse sendingAddress = await formsAppsClient.GetSendingAddress(formsAppId);
```

### Parameters

| Parameter | Required | Type   | Description                    |
| --------- | -------- | ------ | ------------------------------ |
| `id`      | Yes      | `long` | The identifier of the FormsApp |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.FormsAppSendingAddressResponse` class

**Minimum Role Permission**

App Users: _Read Only_

## `GetMyFormsApp()`

Retrieve a forms app associated to a user token

### Example

```c#
string userToken = "bearerToken value";

OneBlink.SDK.Model.FormsApp formsApp = await formsAppsClient.GetMyFormsApp(userToken);
```

### Parameters

| Parameter | Required | Type     | Description            |
| --------- | -------- | -------- | ---------------------- |
| `token`   | Yes      | `string` | A forms app user token |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsApp` class

## `CreateUser()`

Create a new forms app user

### Example

```c#
FormsAppUser newFormsAppUser = {...};

OneBlink.SDK.Model.FormsAppUser savedUser = await formsAppsClient.CreateUser(newFormsAppUser);
```

### Parameters

| Parameter         | Required | Type           | Description             |
| ----------------- | -------- | -------------- | ----------------------- |
| `newFormsAppUser` | Yes      | `FormsAppUser` | New FormsAppUser object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `FormsAppUser` class

**Minimum Role Permission**

App Users: _Manager_

## `DeleteUser()`

### Example

```c#
long formsAppUserId = 1;

await formsAppsClient.DeleteUser(formsAppUserId);
```

### Parameters

| Parameter | Required | Type   | Description                                      |
| --------- | -------- | ------ | ------------------------------------------------ |
| `id`      | Yes      | `long` | The identifier of the FormsAppUser to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

**Minimum Role Permission**

App Users: _Manager_
