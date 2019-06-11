# OneBlink .Net SDK | FormsClient Class

## Instance Functions

- [`GetSubmissionPdf()`](#getSubmissionpdf)

## Constructor

| Parameter         | Required | Type     | Description                      | Default Value |
| ----------------- | -------- | -------- | -------------------------------- | ------------- |
| `accessKey`       | Yes      | `string` | Access key provided by OneBlink. |               |
| `secretKey`       | Yes      | `string` | Secret key provided by OneBlink. |               |
| `expiryInSeconds` | No       | `int`    | Secret key provided by OneBlink. | 300           |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
PdfClient pdfClient = new PdfClient(accessKey, secretKey);
```

## `GetSubmissionPdf()`

### Example

```c#
int formId = 1;
string submissionId = "f33055e4-f8c1-49a6-8605-27f0d11854f0";
PdfClient pdf = new PdfClient(ACCESS_KEY, SECRET_KEY);
Stream response = await pdf.GetSubmissionPdf(formId, submissionId);
```

### Parameters

| Parameter      | Required | Type     | Description                                                                                                                                               |
| -------------- | -------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `formId`       | Yes      | `int`    | The exact id of the form you wish to get submission PDF for                                                                                               |
| `submissionId` | Yes      | `string` | The submission identifier generated after a successful form submission, this will be return to you after a successful forms submission via a callback URL |

### Throws

- `OneBlinkAPIException`
- `Exception`

### Result

A `Stream` object
