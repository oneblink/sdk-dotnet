# OneBlink SDK | FormsApps Class

## Instance Functions

-   [`VerifyJWT()`](#veryjwt)

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
