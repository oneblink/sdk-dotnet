# OneBlink .Net SDK | FormUrlOptions Model

## `FormUrlOptions()`

### Constructor

| Parameter                          | Required                          | Type      | Description                                                                                                |
| ---------------------------------- | --------------------------------- | --------- | ---------------------------------------------------------------------------------------------------------- |
| `formId`                           | Yes                               | `long`    | The identifier of the Form                                                                                 |
| `formsAppId`                       | No                                | `long`    | The identifier of the Forms App                                                                            |
| `expiryInSeconds`                  | No                                | `int`     | The time until expiry of the generated access token                                                        |
| `externalId`                       | No                                | `string`  | The external id to add to the generated url                                                                |
| `preFillData`                      | No                                | `dynamic` | The data to prefill the form with                                                                          |
| `username`                         | No                                | `string`  | The username to encrypt in the `userToken`, for submission authentication                                  |
| `secret`                           | No (Yes, if username is provided) | `string`  | The secret string to encrypt the userToken with. This will also be required for decrypting the `userToken` |
| `previousFormSubmissionApprovalId` | No                                | `long?`   | The exact id of the previous form submission approval this submission will be associated to                |

### Example

```c#
OneBlink.SDK.Model.FormUrlOptions formUrlOptions = new OneBlink.SDK.Model.FormUrlOptions(
    formId: 5,
    expiryInSeconds: 120,
    externalId: "externalId",
    username: "user@oneblink.io",
    secret: "secret",
    previousFormSubmissionApprovalId: 1
);

```
