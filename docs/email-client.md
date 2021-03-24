# OneBlink .Net SDK | EmailClient Class

## Static Functions

-   [`SendEmail()`](#SendEmail)

## `SendEmail()`

### Example

```c#
string body = "<html><body>Some text</body></html>";
string subject = "The subject";
EmailAddress from = new EmailAddress("From Name", "from@email.com");
EmailAddress to = new EmailAddress("To Name", "to@email.com");
EmailAddress[] toAddresses = new EmailAddress[]{to};
string messageId = await EmailClient.SendEmail(body, null, from, toAddresses, null, null, subject, Model.TenantName.ONEBLINK_TEST);
```

### Parameters

| Parameter     | Required | Type           | Description                                               |
| ------------- | -------- | -------------- | --------------------------------------------------------- |
| `body`        | No       | string         | The body used in the email                                |
| `attachments` | No       | Attachment[]   | Array of attachments to included (name and full path)     |
| `from`        | Yes      | EmailAddress   | From address, including name and email addresss           |
| `to`          | No       | EmailAddress[] | Array of to Addresses, including name and email addresss  |
| `cc`          | No       | EmailAddress[] | Array of Cc Addresses, including name and email addresss  |
| `bcc`         | No       | EmailAddress[] | Array of Bcc Addresses, including name and email addresss |
| `tenantName`  | No       | TenantName     | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`, defaults to `TenantName.ONEBLINK` |

### Throws

-   `Exception`

### Result

A `Task<string>`