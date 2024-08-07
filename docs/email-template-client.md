# OneBlink .Net SDK | EmailTemplatesClient Class

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
EmailTemplatesClient emailTemplatesClient = new EmailTemplatesClient(accessKey, secretKey);
```

## `Search()`

### Example

```c#
int? limit = null;
int? offset = null;

OneBlink.SDK.Model.EmailTemplatesSearchResult response = await emailTemplatesClient.Search(limit, offset);
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

A `EmailTemplatesSearchResult` class

**Minimum Role Permission**

Email Templates: _Read Only_

## `Get()`

Retrieve an email template by id

### Example

```c#
long id = 123;

OneBlink.SDK.Model.EmailTemplate emailTemplate = await emailTemplatesClient.Get(id);
```

### Parameters

| Parameter | Required | Type   | Description                          |
| --------- | -------- | ------ | ------------------------------------ |
| `id`      | Yes      | `long` | Id of email template to be retrieved |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `EmailTemplate` class

**Minimum Role Permission**

Email Templates: _Read Only_

## `Create()`

Create a new email template

### Example

```c#
EmailTemplate newEmailTemplate = {...};

OneBlink.SDK.Model.EmailTemplate savedEmailTemplate = await emailTemplatesClient.Create(newEmailTemplate);
```

### Parameters

| Parameter          | Required | Type            | Description               |
| ------------------ | -------- | --------------- | ------------------------- |
| `newEmailTemplate` | Yes      | `EmailTemplate` | New email template object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `EmailTemplate` class

**Minimum Role Permission**

Email Templates: _Manager_

## `Update()`

Update a email template

### Example

```c#
EmailTemplate emailTemplateToUpdate = {...};

OneBlink.SDK.Model.EmailTemplate updatedEmailTemplate = await emailTemplatesClient.Update(emailTemplateToUpdate);
```

### Parameters

| Parameter               | Required | Type            | Description                    |
| ----------------------- | -------- | --------------- | ------------------------------ |
| `emailTemplateToUpdate` | Yes      | `EmailTemplate` | Existing email template object |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `EmailTemplate` class

**Minimum Role Permission**

Email Templates: _Manager_

## `Delete()`

### Example

```c#
long emailTemplateId = 1;

await emailTemplatesClient.Delete(emailTemplateId);
```

### Parameters

| Parameter | Required | Type   | Description                                        |
| --------- | -------- | ------ | -------------------------------------------------- |
| `id`      | Yes      | `long` | The identifier of the email template to be deleted |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

No return value (`void`)

**Minimum Role Permission**

Email Templates: _Manager_
