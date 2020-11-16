# OneBlink .Net SDK | NewFormsAppSendingAddress Model

## `NewFormsAppSendingAddress()`

### Constructor

| Parameter      | Required | Type     | Description                                      | Default Value |
| -------------- | -------- | -------- | ------------------------------------------------ | ------------- |
| `emailAddress` | Yes      | `string` | The email address that emails will be sent from. | null          |
| `emailName`    | No       | `string` | The name that emails will be sent from.          | null          |

### Example

```c#
OneBlink.SDK.Model.NewFormsAppSendingAddress newFormsAppSendingAddress = new OneBlink.SDK.Model.NewFormsAppSendingAddress(
  emailAddress: "user@oneblink.io",
  emailName: "User Name",
);

```
