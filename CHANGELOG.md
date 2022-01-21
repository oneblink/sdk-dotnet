# Changelog

## Unreleased

### Added

-   `uploadedAt` to `AttachmentData` class
-   `description` to `FormsAppBase` class

## 2.7.2 (2022-01-19)

### Added

-   Approval form inclusion on approval events
-   Approval Form information to approvalStep related classes.
-   [`FormsClient.GetFormSubmissionMeta()`](./docs/forms-client#getformsubmissionmeta)

## 2.7.1 (2021-12-23)

### Added

-   `Migrate` to the `FormsClient` class

## 2.7.0 (2021-12-21)

### Added

-   More events to forms

### Changed

-   Drafts on submission events

## 2.6.1 (2021-12-02)

### Added

-   `FreshdeskCreateTicket` to the submission events
-   `freshdeskFieldName` to the FormElement class

## 2.6.0 (2021-11-25)

### Added

-   `Email` to the submission events
-   `createFilesElement()` as well as preventing extensionless attachments

## 2.5.5 (2021-11-16)

### Added

-   Added `EmailTemplatesClient`

## 2.5.4 (2021-11-11)

### Added

-   `emailTemplate` to `FormSubmissionEventConfiguration`
-   Added `FormsAppEnvironmentsClient`

### Changed

-   Updated `FormsClient.Search()` parameters.

## 2.5.3 (2021-10-05)

### Added

-   `usePagesAsBreaks` to `FormSubmissionEventConfigration`
-   `usePagesAsBreaks` to `PdfClient.GetSubmissionPdf()`

## 2.5.2 (2021-09-27)

### Added

-   `groupFiles` to `FormSubmissionEventConfigration`

## 2.5.1 (2021-09-15)

### Added

-   `GetFormSubmissionApproval` to `ApprovalsClient`
-   `GetFormApprovalFlowInstance` to `ApprovalsClient`

## 2.5.0 (2021-08-31)

### Added

-   `lastUpdatedBy`, `updatedAfterDateTime` and `updatedBeforeDateTime` parameters to `ApprovalsClient.GetFormSubmissionAdministrationApprovals()`
-   `ipAddress` to `FormSubmission`
-   `lastUpdatedBy` to `FormApprovalFlowInstance`

## 2.4.0 (2021-08-24)

### Added

-   `isDescription` to `FormSubmissionEventCivicaElementMapping`

### Removed

-   `civicaDescription` from `FormSubmissionEventConfiguration`

## 2.3.0 (2021-08-11)

### Added

-   `ApprovalsClient`
-   `externalIdGeneration` to `Form`

## 2.2.8 (2021-08-02)

### Added

-   `serverValidation` to `Form`

## 2.2.7 (2021-07-20)

### Added

-   `nylasAccountId`, `nylasSchedulingPageId`, `nameElementId` and `emailElementId` to `FormSubmissionEventConfigration`
-   `CreateSchedulingSubmissionEvent()` to `FormSubmissionEvent`
-   [`GenerateSubmissionAttachmentUrl()`](./docs/forms-client#generatesubmissionattachmenturl)

## 2.2.6 (2021-06-30)

### Added

-   `excludedElementIds` to `PdfClient.GetSubmissionPdf()`

## 2.2.5 (2021-06-23)

### Added

-   `civicaDescription`, `civicaCustomerContactMethod`, `civicaCategory` and `mapping` to `FormSubmissionEventConfiguration`
-   `CreateCivicaCrmSubmissionEvent()` to `FormSubmissionEvent`
-   `Boolean` element type to `FormElement`
-   `useGeoscapeAddressing` and `CreateCivicaNameRecordElement()` to `FormElement`
-   `isCollapsed` and `CreateSectionElement()` to `FormElement`

## 2.2.4 (2021-06-02)

### Fixed

-   `description` not being set on form when passed to constructor

### Added

-   `canToggleAll` to `FormElement`
-   `customerReferenceNumber` to `FormSubmissionEventConfiguration`
-   `CreateWestpacQuickWebSubmissionEvent()` to `FormSubmissionEvent`

## 2.2.3 (2021-06-02)

### Added

-   `regexPattern`, `regexFlags` and `regexMessage` to `FormElement`
-   `buttons` to `FormListStyles`

### Fixed

-   Setting of `ContentDisposition` in `CreateSubmissionAttachment()`

### Changed

-   Remove string value type validation from properties

## 2.2.2 (2021-05-26)

### Added

-   `encryptPdf` prop to `FormSubmissionEventConfiguration` class
-   `defaultValueDaysOffset`, `fromDateDaysOffset`, `toDateDaysOffset` to `FormElement`
-   `cancelAction` and `cancelRedirectUrl` to `Form`
-   Allowed value of `BACK` for `postSubmissionAction`

### Fixed

-   `OneBlinkHttpClient.SendRequest()` to check content type before converting to json

### Changed

-   Type of `FormElement.fromDate` and `FormElement.toDate` from `DateTime` to `string`

## 2.2.1 (2021-05-19)

### Changed

-   Type of `value` from `int` to `double` in `ConditionallyShowPredicate` Model

### Added

-   `recaptchaIntegrationDomainId` to `FormsAppBase`

## 2.2.0 (2021-05-13)

### Fixed

-   `ConditionallyShowPredicate` class missing BETWEEN `type`

### Added

-   `displayAsCurrency` to `FormElement`
-   `storageType` to `FormElement`
-   `formsAppEnvironment` to `FormsClient Search`
-   `GetFormSubmissionAttachment` to `FormsClient`
-   `CreateSubmissionAttachment` to `FormsClient`
-   `author` to `FormSubmissionEventConfiguration`

## 2.1.0 (2021-04-27)

### Updated

-   Forms App base with `isClientLoggingEnabled` prop

## 2.0.0 (2021-04-15)

### Added

-   `GenerateSubmissionDataUrl` to `FormsClient`
-   `KeysClient` class
-   `GetMyFormsApp`, `CreateUser` and `DeleteUser` to `FormsAppClient`
-   `Get` to `OrganisationsClient`
-   `pointAddress` element type to `FormElement`

### Changed

-   **[BREAKING]** replaced `FormsApp` class with `FormsListFormsApp`, `TilesFormsApp`, `ApprovalsFormsApp`, and `VolunteersFormsApp`

## 1.17.0 (2021-03-23)

### Added

-   `GeneratePdf` function to `PdfClient`
-   `SendEmail` function to `EmailClient`

### Changed

-   Added `isDraft` and `includeSubmissionIdInPdf` parameters to `PdfClient.GetSubmissionPdf()`

## 1.16.0 (2021-03-23)

### Added

-   `compliance` form element
-   `hint` property to form elements with labels

## 1.15.0 (2021-03-03)

### Added

-   `previousFormSubmissionApprovalId` to `FormUrlOptions`

## 1.14.0 (2021-02-09)

### Added

-   Added `type`, `categories` and `waiverUrl` to `FormsApp`, `CONTAINER` and `FORM` to `AllowedMenuItemTypes`, `formIds` and `formId` to `FormsAppMenuItems`

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
