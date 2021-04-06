# Changelog

## Unreleased

### Added

- `GenerateSubmissionDataUrl` to `FormsClient`
- `KeysClient` class
- `GetMyFormsApp`, `CreateUser` and `DeleteUser` to `FormsAppClient`
- `Get` to `OrganisationsClient`
- `pointAddress` element type to `FormElement`

### Changed

- Updated `FormsApp` to `ApprovalsFormsApp`, `FormsListFormsApp` and `VolunteersFormsApp`

## 1.17.0 (2021-03-23)

### Added

- `GeneratePdf` function to `PdfClient`
- `SendEmail` function to `EmailClient`

### Changed

- Added `isDraft` and `includeSubmissionIdInPdf` parameters to `PdfClient.GetSubmissionPdf()`

## 1.16.0 (2021-03-23)

### Added

- `compliance` form element
- `hint` property to form elements with labels

## 1.15.0 (2021-03-03)

### Added

 - `previousFormSubmissionApprovalId` to `FormUrlOptions`

## 1.14.0 (2021-02-09)

### Added

 - Added `type`, `categories` and `waiverUrl` to `FormsApp`, `CONTAINER` and `FORM` to `AllowedMenuItemTypes`, `formIds` and `formId` to `FormsAppMenuItems`

## 1.13.0 (2021-01-18)

### Added

-   [`GenerateFormUrl()`](./docs/forms-client.md#GenerateFormUrl) method
-   [`EncryptUserToken()`](./docs/forms-client.md#EncryptUserToken) method
-   [`DecryptUserToken()`](./docs/forms-client.md#DecryptUserToken) method
-   `crn2` and `crn3` to `FormSubmissionEventConfigration`
-   `includeSubmissionIdInPdf` to `FormSubmissionEventConfigration`
-   `encryptedElementIds` and `excludedElementIds` to `FormSubmissionEventConfigration`
-   [`CreateGeoscapeAddressElement()`](./docs/models/FormElement.md#geoscape-address-element) method

## 1.12.0 (2020-11-12)

### Added

-   [`SetSendingAddress()`](./docs/forms-apps-client.md#SetSendingAddress) method
-   [`DeleteSendingAddress()`](./docs/forms-apps-client.md#DeleteSendingAddress) method

## 1.11.0 (2020-11-12)

### Added

-   isInteger prop to `FormElement`
-   minLength and maxLength props to `FormElement` and `createTextElement` constructor

## 1.10.0 (2020-10-15)

### Added

-   `OrganisationsClient`

## 1.9.0 (2020-07-23)

### Added

-   `conditionallyExecutePredicates` to `FormSubmissionEvent`
-   CRUD methods to [`FormsAppsClient`](./docs/forms-apps-client.md)

## 1.8.0 (2020-07-09)

### Added

-   Added `environmentId` to `FormSubmissionEventConfiguration`

## 1.7.0 (2020-07-06)

### Added

-   Added `overrideLock` parameter to update and delete form functions
-   Added `gatewayId` to `FormSubmissionEventConfiguration`
-   Added `placeholderValue` to `FormElement`
-   Added `tags` to `Form`
-   Added `publishStartDate` and `publishEndDate` to `Form`

## 1.6.0 (2020-06-10)

### Added

-   FormsApps class and `VerifyJWT` method

## 1.5.1 (2020-06-03)

### Added

-   `BPOINT` submission event type
-   `CP_HCMS` `SubmissionEvent` type

## 1.4.0 (2020-05-25)

### Added

-   CRUD methods to [`FormsClient`](./docs/forms-client.md)
-   `summary` `FormElement` type

## 1.3.0 (2020-04-06)

### Removed

-   Support for overriding api and pdf urls through .env variables

### Added

-   Support for tenant selection when instantiating a client
-   [`searchSubmissions()`](./docs/forms-client.md) function
-   `limit` and `offset` parameters to `searchSubmissions()`

## 1.2.0 (2020-02-13)

### Added

-   `priority` parameter to [`JobsClient.CreateJob()`](<./docs/jobs-client.md#createjob(job)>)
-   `device` property to `FormSubmission` class

## 1.1.0 (2020-01-30)

### Added

-   [`JobsClient`](./docs/jobs-client.md) class

## 1.0.1 (2019-06-20)

### Added

-   `isDraft` parameter to [`FormsClient.GetFormSubmission()`](./docs/forms-client.md#getformsubmission)
-   [`TeamMembersClient`](./docs/team-members-client.md) class

## 1.0.0

Initial production release
