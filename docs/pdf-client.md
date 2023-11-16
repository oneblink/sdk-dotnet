# OneBlink .Net SDK | FormsClient Class

## Instance Functions

-   [`GetSubmissionPdf()`](#getSubmissionpdf)
-   [`GeneratePdf()`](#generatepdf)
-   [`GeneratePdfFromSubmissionData()`](#generatepdffromsubmissiondata)

## Constructor

| Parameter    | Required | Type         | Description                                                                                             | Default Value         |
| ------------ | -------- | ------------ | ------------------------------------------------------------------------------------------------------- | --------------------- |
| `accessKey`  | Yes      | `string`     | Access key provided by OneBlink, requires the `PDF` and `FORMS` permission.                             |                       |
| `secretKey`  | Yes      | `string`     | Secret key provided by OneBlink, requires the `PDF` and `FORMS` permission.                             |                       |
| `tenantName` | No       | `TenantName` | Sets the configuration values to be used. Options are `TenantName.ONEBLINK` and `TenantName.CIVICPLUS`. | `TenantName.ONEBLINK` |

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
long formId = 1;
string submissionId = "f33055e4-f8c1-49a6-8605-27f0d11854f0";
PdfClient pdfClient = new PdfClient(ACCESS_KEY, SECRET_KEY);
Stream response = await pdfClient.GetSubmissionPdf(formId, submissionId);
```

### Parameters

| Parameter                  | Required | Type           | Description                                                                                                                                               |
| -------------------------- | -------- | -------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `formId`                   | Yes      | `long`         | The exact id of the form you wish to get submission PDF for                                                                                               |
| `submissionId`             | Yes      | `string`       | The submission identifier generated after a successful form submission, this will be return to you after a successful forms submission via a callback URL |
| `isDraft`                  | No       | `bool?`        | `true` if the submission is a draft submission, otherwise `false`                                                                                         |
| `includeSubmissionIdInPdf` | No       | `bool?`        | `true` to include the submission identifier in the PDF, otherwise `false`                                                                                 |
| `excludedElementIds`       | No       | `List<string>` | Optional list of element id's to be excluded from the pdf document                                                                                        |
| `usePagesAsBreaks`         | No       | `bool?`        | `true` to use Pages as page breaks in the PDF, otherwise `false`                                                                                          |
| `excludedCSSClasses`       | No       | `List<string>` | Optional list of CSS Classes to be excluded from the pdf document                                                                                         |
| `includeExternalIdInPdf`   | No       | `bool?`        | `true` to include the external submission identifier in the PDF, otherwise `false`                                                                        |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Stream` object

## `GeneratePdf()`

### Example

```c#
GeneratePdfOptionsRequest pdfOptionsRequest = new GeneratePdfOptionsRequest();
Html body = new Html();
body.html = "<body>PDF Test</body>";
pdfOptionsRequest.body = body;
PdfClient pdfClient = new PdfClient(ACCESS_KEY, SECRET_KEY);
Stream response = await pdfClient.GeneratePdf(pdfOptionsRequest);
```

### Parameters

| Parameter           | Required | Type                        | Description                                                      |
| ------------------- | -------- | --------------------------- | ---------------------------------------------------------------- |
| `pdfOptionsRequest` | Yes      | `GeneratePdfOptionsRequest` | Options include page and html to be rendered in the PDF document |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Stream` object

## `GeneratePdfFromSubmissionData()`

### Example

```c#
MySubmissionDataType submission = new MySubmissionDataType();
FormSubmission<MySubmissionDataType> submissionData = new FormSubmission<MySubmissionDataType>();
submissionData.submission = submission;
// populuate rest of submissionData here
GeneratePDFFromSubmissionDataRequest<MySubmissionDataType> options = new GeneratePDFFromSubmissionDataRequest<MySubmissionDataType>();
options.submissionData = submissionData;
options.formsAppId = formsAppId;
PdfClient pdfClient = new PdfClient(ACCESS_KEY, SECRET_KEY);
Stream response = await pdfClient.GeneratePdfFromSubmissionData<MySubmissionDataType>(options);
```

### Parameters

| Parameter | Required | Type                                   | Description                                                                              |
| --------- | -------- | -------------------------------------- | ---------------------------------------------------------------------------------------- |
| `options` | Yes      | `GeneratePDFFromSubmissionDataRequest` | Includes various PDF configuration options and the submission data to be used in the PDF |

### Throws

-   `OneBlinkAPIException`
-   `Exception`

### Result

A `Stream` object
