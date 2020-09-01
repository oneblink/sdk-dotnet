# OneBlink .Net SDK | OrganisationsClient Class

## Instance Functions

-   [`UploadAsset()`](#getformsubmission)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value       |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | ------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink.                                                                        |                     |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink.                                                                        |                     |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | TenantName.ONEBLINK |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
OrganisationsClient organisationsClient = new OrganisationsClient(accessKey, secretKey);
```

## `UploadAsset()`

### Example

```c#
string assetData = "data";
string contentType = "text/plain";
string assetFileName = "file.text";
string publicUrl = await organisationsClient.UploadAsset(assetData, contentType, assetFileName);
```

### Parameters

| Parameter       | Required | Type     | Description                         |
| --------------- | -------- | -------- | ----------------------------------- |
| `assetData`     | Yes      | `string` | The file data                       |
| `contentType`   | Yes      | `string` | The content type for the asset data |
| `assetFileName` | Yes      | `string` | The name to use for the asset file  |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `string` with the public url to the asset
