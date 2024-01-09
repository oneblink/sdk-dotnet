# OneBlink .Net SDK | KeysClient Class

## Instance Functions

- [`GetDeveloperKey()`](#getdeveloperkey)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value         |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink.                                                                        |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink.                                                                        |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
KeysClient keysClient = new KeysClient(accessKey, secretKey);
```

## `GetDeveloperKey()`

### Example

```c#
string keyId = "2d6278w16swc9a85400000009";
OneBlink.SDK.Model.DeveloperKey developerKey = await keysClient.GetDeveloperKey(keyId);
```

### Parameters

| Parameter | Required | Type     | Description                         |
| --------- | -------- | -------- | ----------------------------------- |
| `id`      | Yes      | `string` | The identifier of the Developer Key |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.DeveloperKey` class
