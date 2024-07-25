# OneBlink SDK | TeamMembersClient Class

## Instance Functions

- [`GetTeamMemberRole()`](#getteammemberrole)

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
TeamMembersClient teamMembersClient = new TeamMembersClient(accessKey, secretKey);
```

## `GetTeamMemberRole()`

### Example

```c#
string email = "email@domain.io";
OneBlink.SDK.Model.Role role = await teamMembersClient.GetTeamMemberRole(email);
if (role != null) {
    // Use role here
}
```

### Parameters

| Parameter | Required | Type     | Description                                     |
| --------- | -------- | -------- | ----------------------------------------------- |
| `email`   | Yes      | `string` | The email address the team member uses to login |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `OneBlink.SDK.Model.Role` class or `null`
