# OneBlink SDK | TeamMembersClient Class

## Instance Functions

-   [`GetTeamMemberRole()`](#getteammemberrole)

## Constructor

| Parameter    | Required | Type         | Description                                                                    | Default Value |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------ | ------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink.                                               |               |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink.                                               |               |
| `regionCode` | No       | `RegionCode` | Sets the url to be used. Options are `RegionCode.AU` and `RegionCode.US`.      | RegionCode.AU |
| `originApi`  | No       | `string`     | Url to override the apiOrigin. Cannot be used in conjunction with `RegionCode` |               |

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

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `OneBlink.SDK.Model.Role` class or `null`
