# OneBlink .Net SDK | NewFormsAppSendingAddress Model

## `NewFormsAppSendingAddress()`

### Constructor

| Parameter      | Required    | Type     | Description                                                                                       | Default Value |
| -------------- | ----------- | -------- | ------------------------------------------------------------------------------------------------- | ------------- |
| `emailAddress` | Conditional | `string` | The email address that emails will be sent from. One of `emailAddress` or `emailName` is required | null          |
| `emailName`    | Conditional | `string` | The name that emails will be sent from. One of `emailAddress` or `emailName` is required          | null          |

### Example

```c#
OneBlink.SDK.Model.NewFormsAppSendingAddress newFormsAppSendingAddress = new OneBlink.SDK.Model.NewFormsAppSendingAddress(
  emailAddress: "user@oneblink.io",
  emailName: "User Name",
);

```
