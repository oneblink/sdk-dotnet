# OneBlink SDK | FormsApps Class

## Instance Functions

-   [`VerifyJWT()`](#veryjwt)
-   [`Get()`](#get)
-   [`Create()`](#create)
-   [`Update()`](#update)
-   [`Delete()`](#delete)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value       |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | ------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink.                                                                        |                     |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink.                                                                        |                     |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | TenantName.ONEBLINK |  |

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

-   `Exception`

### Result

A `OneBlink.SDK.Model.JWTPayload` class

## `Get()`

Retrieve a forms app by id

### Example

```c#
long id = 123;

OneBlink.SDK.Model.FormsApp formsApp = await formsAppsClient.Get(id);
```

### Parameters

| Parameter | Required | Type   | Description                     |
| --------- | -------- | ------ | ------------------------------- |
| `id`      | Yes      | `long` | Id of forms app to be retrieved |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormsApp` class

## `Create()`

Create a new forms app

### Example

```c#
FormsApp newFormsApp = {...};

OneBlink.SDK.Model.FormsApp savedFormsApps = await formsAppsClient.Create(newFormsApp);
```

### Parameters

| Parameter     | Required | Type       | Description         |
| ------------- | -------- | ---------- | ------------------- |
| `newFormsApp` | Yes      | `FormsApp` | New FormsApp object |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormsApp` class

## `Update()`

Update a existing forms app

### Example

```c#
FormsApp formsAppToUpdate = {...};

OneBlink.SDK.Model.FormsApp updatedFormsApp = await formsAppsClient.Update(formsAppToUpdate);
```

### Parameters

| Parameter          | Required | Type       | Description              |
| ------------------ | -------- | ---------- | ------------------------ |
| `formsAppToUpdate` | Yes      | `FormsApp` | Existing FormsApp object |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `FormsApp` class

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

-   `OneBlinkAPIException`
-   `Exception`

### Result

No return value (`void`)

## `SetSendingAddress()`

### Example

```c#
long formsAppId = 1;
OneBlink.SDK.Model.NewFormsAppSendingAddress newFormsAppSendingAddress = new OneBlink.SDK.Model.NewFormsAppSendingAddress(
    emailAddress: "user@oneblink.io",
    emailName: "User Name"
);

OneBlink.SDK.Model.FormsAppSendingAddress sendingAddress = await formsAppsClient.SetSendingAddress(formsAppId, newFormsAppSendingAddress);
```

### Parameters

| Parameter                   | Required | Type                                                               | Description                            |
| --------------------------- | -------- | ------------------------------------------------------------------ | -------------------------------------- |
| `id`                        | Yes      | `long`                                                             | The identifier of the FormsApp         |
| `newFormsAppSendingAddress` | Yes      | [NewFormsAppSendingAddress](./models/NewFormsAppSendingAddress.md) | The Sending address information to set |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.FormsAppSendingAddress` class
