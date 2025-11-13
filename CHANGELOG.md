# Changelog

## Unreleased

### Added

- `isAIBuilderSupported` to `Form`
- properties to to `FormEvent` for excel add row event
- `hideApprovalDenyButton` to `FormApprovalFlowStepBase`
- `excludeAliases`, `datasetFilter`, `CreatePointAddressV3Element()` to `FormElement`


## [11.1.1] - 2025-09-15

### Removed

- `path` from `AttachmentData` class

## [11.1.0] - 2025-08-29

### Added

- `allowAttachmentsDownload` to `FormPostSubmissionReceipt` class
- `path` to `AttachmentData` class
- `SetSendingAddress()`, `DeleteSendingAddress()` & `GetSendingAddress()` to `FormsAppEnvironmentsClient`

### Changed

- `NewFormsAppSendingAddress` docs

## [11.0.11] - 2025-08-26

##### Release Name: HotFix Slippery Spine

### Fixed

- key used for s3 attachment uploads

## [11.0.9] - 2025-08-11

### Added

- `arcGISWebMap` form element properties for image snapshots

## [11.0.8] - 2025-07-25

### Added

- `sendNotificationEmailOptionDefaultUnchecked` to `FormApprovalConfiguration`
- `FormSubmissionEvent.CreateGoodToGoSubmissionEvent()` method
- `FormSubmissionEventConfigurationMapping.goodToGoCustomFieldName` property
- `FormSubmissionEventConfigurationMapping.mapping` property

## [11.0.7] - 2025-07-10

### Added

- `footer` to `FormsListStyles`
- Lookup Button element properties to `FormElement`
- favicon configuration to environments and apps
- `validationIcon` configuration to environments
- `maxFileSize` to `FormElement`
- `restrictFileSize` to `FormElement`

## [11.0.6] - 2025-06-16

### Added

- `customHostname` to `FormsAppEnvironment`
- `description` to `ArcGISWebMapElement` graphic attribute options

## [11.0.5] - 2025-06-03

### Added

- `DynamicListOption` class
- `FormSubmissionWebhookPayload` class
- `FormElementLookupPayload` class
- `requiresConfirmation` to `FormElement`
- `displayAsCheckbox` to `FormElement`
- `FormsAppsClient.VerifyJWT()` static method

## [11.0.4] - 2025-05-22

### Added

- `googleAnalyticsTagId` to `FormsAppBase`
- Additional attributes to `RawJWTPayload`
- Additional attributes to `FormSubmissionUser`

## [11.0.3] - 2025-04-30

### Added

- `basemapId`, `allowedDrawingTools`, `addressSearchWidgetEnabled` and `homeWidgetEnabled` to `FormElement`
- `pointAddressV3EnvironmentId` to `Form` class

## [11.0.2] - 2025-04-04

### Added

- `isDisplayingAddressInformation` to `FormElement`
- `isCustomPdfEditable` to `PDFConfiguration`

## [11.0.1] - 2025-03-19

### Fixed

- `FormsClient.Get()` using legacy endpoint.

## [11.0.0] - 2025-03-11

### Added

- `customPDFs` to Form
- `customPdfId` to `PDFConfiguration`
- `isCloningCustomPDFs` to `FormsAppEnvironmentCloneOptions`
- `customPDFs` to `FormMigrationOptions`

### Changed

- **[BREAKING]** `PdfClient.GetSubmissionPdf()` parameters
  ```diff
  Stream stream = await pdfClient.GetSubmissionPdf(
      formId = 1,
      submissionId = "",
  -   false,
  -   false,
  -   null,
  -   true,
  -   true,
  -   null,
  -   true,
  -   "A4",
  -   true
  +   new GetSubmissionPdfRequest()
  +   {
  +       isDraft = false,
  +       includeSubmissionIdInPdf = false,
  +       excludedElementIds = null,
  +       usePagesAsBreaks = true,
  +       includePaymentInPdf = true,
  +       excludedCSSClasses = null,
  +       includeExternalIdInPdf = true,
  +       pdfSize = "A4",
  +       includeCalendarBookingInPdf = true
  +   }
  );
  ```

## [10.2.0] - 2025-02-20

### Added

- properties to support SharePoint Create List Item and Store Files form workflow event

## [10.1.1] - 2025-01-22

### Added

- `isArchived` to Forms

## [10.1.0] - 2025-01-12

### Added

- `styles` to `FormsAppEnvironment`

## [10.0.0] - 2024-12-11

### Removed

- legacy nylas
- **[BREAKING]** `CreateSchedulingSubmissionEvent` from `FormSubmissionEvent`

### Added

- `formSubmissionNylasBooking` to `FormSubmissionMetaResponse`

## [9.0.2] - 2024-12-09

### Added

- `imageUrl` property to `FormElementOption` class
- `disableAutosave` to `Form`

### Fixed

- Headers not being escaped when uploading to s3

## [9.0.1] - 2024-11-27

### Added

- `nodes` and `type` to `FormApprovalFlowInstanceStep` and `FormApprovalStep`
- `cachingStrategies` to `FormsAppBase`

## [9.0.0] - 2024-11-13

### Added

- `nylasGrantId` and `nylasConfigurationId` to `FormSubmissionEventConfiguration`

### Removed

- **[BREAKING]** `FormsAppsClient.updateStyles()` The `styles` property can be set using `FormsAppsClient.Create()` and updated using `FormsAppsClient.Update()`

## [8.1.1] - 2024-10-29

### Added

- `startingSequentialNumber` to `FormExternalIdGenerationConfiguration`
- `isCloningScheduledTasks` to `FormsAppEnvironmentCloneOptions`

## [8.1.0] - 2024-10-09

### Added

- `enableSubmission` to `Form`

## [8.0.0] - 2024-09-25

### Removed

- **[BREAKING]** `TeamMembersClient` class

## [7.0.1] - 2024-09-03

### Added

- `slug` to `Form`

## [7.0.0] - 2024-08-07

### Added

- Minimum Role Permission to Client docs

### Removed

- **[BREAKING]** `EncryptUserToken` and `DecryptUserToken` methods from the `FormsClient` class
- **[BREAKING]** `secret` property from `FormUrlOptions` class

### Changed

- `GenerateFormUrl` method in the `FormsClient` class to include the `username` property into the JWT payload as the `sub` claim

## [6.2.2] - 2024-07-10

### Changed

- form submissions and draft downloads to use storage endpoints

### Added

- `canCollapseFromBottom` to `FormElement`

## [6.2.1] - 2024-07-01

### Added

- `organisationManagedSecretId` to `EndpointConfiguration` and `FormSubmissionEventConfiguration`
- `allowGeoscapeAddresses` to `Form`

## [6.2.0] - 2024-06-21

### Added

- `customerSecretId` to `DeveloperKey`
- `pointAddressEnvironmentId` to `Form`

## [6.1.0] - 2024-06-13

### Added

- `excludedAttachmentElementIds` to `FormSubmissionEventConfiguration`
- `ExecuteWorkflowEvent` to `FormsClient` class

## [6.0.0] - 2024-06-04

### Added

- `googleMapsIntegrationKeyId` to `FormsAppBase`
- `groups` to `FormsAppBase`
- `customGroups` to `RawJWTPayload`
- `groups` to `FormSubmissionUser`

### Removed

- **[BREAKING]** `isCloningFormGoogleMapsIntegrationEnvironmentId` from `FormsAppEnvironmentCloneOptions`
- **[BREAKING]** `googleMapsIntegrationEnvironmentId` from `FormMigrationOptions`
- **[BREAKING]** `googleMapsIntegrationEnvironmentId` from `Form`
- **[BREAKING]** `recaptchaIntegrationDomainId` to be a `Guid` type

## [5.6.4] - 2024-05-20

### Added

- `embeddedforms` and `approvalForms` to `FormMigrationOptions`

## [5.6.3] - 2024-05-10

### Added

- `includeCalendarBookingInPdf` to `FormSubmissionEventConfiguration`

## [5.6.2] - 2024-04-30

### Changed

- uploads to go storage service

## [5.6.1] - 2024-04-10

### Added

- `pendingApprovalsReminder` to `FormApprovalConfiguration`

## [5.6.0] - 2024-03-14

### Added

- `decorativeImage` to `FormElement`
- `notificationElementId` to `FormSubmissionEventConfiguration`

## [5.5.0] - 2024-02-18

### Added

- `webMapId` and `showLayerPanel` to `FormElement`
- `versionId` to `FormMigrationOptions`

## [5.4.0] - 2024-02-07

### Added

- `isRetryable` to `FormSubmissionEvent` model
- `approvalCreatedEmailTemplateId`, `clarificationRequestEmailTemplateId`, `approvedEmailTemplateId`, `deniedEmailTemplateId` to `FormApprovalConfiguration` model

## [5.3.0] - 2024-01-18

### Added

- `pdfSize` to `GeneratePDFFromSubmissionDataRequest`, `GetSubmissionPdfRequest` and `PDFConfiguration`
- `customCssClasses` to `Form` class
- `emailAttachmentsEndpoint` to `FormSubmissionEventConfiguration` class
- `UploadEmailAttachment` to `FormsClient` class
- `WorkflowAttachmentUploadCredentials` to models
- `EmailAttachmentData` to models
- `CreateLiquorLicenceElement` function to `FormElement`

### Updated

- `GetFormSubmission` to return `null` if submission has expired
- CI event for `Dependabot` to trigger from `pull_request_target` workflow event

## [5.2.0] - 2023-11-21

### Added

- `GeneratePdfFromSubmissionData` function to `PdfClient` class
- `continueWithAutosave` to `Form` class
- `lastElementUpdated`, `externalId`, `task`, `taskGroup` and `taskGroupInstance` to `FormSubmission` class

## [5.1.1] - 2023-11-01

### Added

- `excludeDefinition` property to `FormElementLookup`

## [5.1.0] - 2023-10-23

### Added

- `repeatableSetPredicate` property to `ConditionallyShowPredicate`

## [5.0.0] - 2023-09-17

### Removed

- **[BREAKING]** `definition` from `FormStoreRecord` model

## [4.4.0] - 2023-08-10

### Fixed

- `isCloningFormApprovalSteps` missing from `FormsAppEnvironmentCloneOptions` model

### Added

- `submissionTitle` to `Form` class
- `submissionTitle` to `FormSubmissionMetadata` class
- `personalisation` to `FormMigrationOptions` class
- `isCloningFormPersonalisation` to `FormsAppEnvironmentCloneOptions` class
- `submissionTitle` to `Forms.SearchSubmissions()`

### Changed

- `externalIdGeneration` to `externalIdGenerationOnSubmit` in `FormMigrationOptions` and `FormsAppEnvironmentCloneOptions` classes

### Removed

- `externalIdGeneration` from `Form` class

## [4.3.0] - 2023-07-26

- `runLookupOnClear` to `FormElementLookupEnvironment` class

## [4.2.0] - 2023-07-12

### Added

- `GenerateWorkflowAttachmentLink` to `FormsClient` class

## [4.1.12] - 2023-07-03

### Added

- `lookupButton` to `FormElement`
- `ListsClient` and `LookupsClient` class

## [4.1.11] - 2023-06-23

### Added

- `NSW_GOV_PAY` parameters to `FormSubmissionEventConfiguration`

## [4.1.10] - 2023-06-05

### Added

- `includeExternalIdInPdf` to `PDFConfiguration`
- `includeExternalIdInPdf` parameters to `PdfClient.GetSubmissionPdf()`

## [4.1.9] - 2023-05-26

### Added

- `searchQuerystringParameter` to `FormElement` class
- `personalisation` and `externalIdGenerationOnSubmit` to `Form` class
- `FormPersonalisation` model class for `personalisation`
- `enableAppUserSignup` to `FormsAppBase` class
- `firstName` and `lastName` to `FormsAppUser`

## [4.1.8] - 2023-05-12

### Added

- `unpublishedUserMessage` to `Form`

## [4.1.7] - 2023-05-02

### Added

- `displayAlways` property to `FormElementOption` class

## [4.1.6] - 2023-04-27

### Added

- `FormElementRepeatableSetEntriesConstraint` model class for Repeatable set Element based min/max entries.

## [4.1.5] - 2023-04-20

### Added

- `Microsoft DevSkim` to Github build action

## [4.1.4] - 2023-04-14

### Added

- `fromDateElementId` to `FormElement`
- `ToDateElementId` to `FormElement`

## [4.1.3] - 2023-04-03

### Added

- `excludedCSSClasses` to `PDFConfiguration` and `PdfClient.GetSubmissionPdf()`

## [4.1.2] - 2023-03-27

### Added

- `hintPosition` to `FormElement`
- `postSubmissionReceipt` to `Form`
- `FormExternalIdGeneration` model
- `ReceiptConfiguration` model
- `toEmail`, `ccEmail` and `bccEmail` to `FormSubmissionEventConfiguration`
- deprecated warnings to `CreatePDFSubmissionEvent()` and `CreateEmailSubmissionEvent()` methods using the `email` parameter

### Changed

- Deprecated `email` from `FormSubmissionEventConfiguration`

## [4.1.1] - 2023-03-13

### Added

- `formApprovalFlowInstanceId` to `ApprovalsClient.GetFormSubmissionAdministrationApprovals()`
- `requiredAll` to `FormElement`

## [4.1.0] - 2023-03-03

### Added

- `'oneblink:access'` claim to JWT for signed URL to submit an authenticated form

## [4.0.0] - 2023-02-23

### Updated

- **[BREAKING]** `FormsClient.Search()` to use v2 url. Now paginates by a maximum of 200 results at a time.

### Added

- `disallowApprovingWhenAwaitingClarification` to `FormApprovalConfiguration`

## [3.0.17] - 2023-02-16

### Changed

- TRIM Submission Event to have optional `action` and `location`

### Removed

- `isInfoPage` from `Form`
- `isInfoPage` from `FormsClient.Search()` parameters

## [3.0.16] - 2022-12-12

### Added

- timezone to Organisation

## [3.0.15] - 2022-11-15

### Changed

- `FormsAppsClient.VerifyJWT()` to use cognito directly

## [3.0.14] - 2022-11-08

### Added

- `GetFormSubmissionAttachmentMeta` to `FormsClient`

### Changed

- Origin for test tenant's
- `FormsAppsClient.VerifyJWT()` to call API instead of using cognito

## [3.0.11] - 2022-09-27

### Added

- `autoDenyAfterClarificationRequest` to `FormApprovalConfiguration`

### Fixed

- type for `FormApprovalConfiguration.defaultNotificationEmailElementId`

## [3.0.10] - 2022-09-13

### Added

- `approvalConfiguration` to `Form`
- `FormApprovalCannedResponse` class
- `cannedResponseKey` to `FormSubmissionApproval`
- `DataManagerClient` class and corresponding model classes
- `secret` to `FormServerValidationConfiguration`
- `isValid` parameter to `FormsClient.SearchSubmissions`

### Changed

- Numerous updates to `JWTPayload` class

## [3.0.9] - 2022-08-16

### Added

- `requiredMessage` to `FormElement`
- `customCssClasses` to `FormElement`
- `meta` to `FormElement`
- `label` to `FormSubmissionEvent`

## [3.0.8] - 2022-07-29

### Added

- `formSubmissionWorkflowEvents` and `formSubmissionSchedulingBooking` to `FormSubmissionMetadataResponse`

### Changed

- Mark `FormsClient.GetSubmissionMeta()` as obsolete

## [3.0.7] - 2022-06-29

### Added

- `additionalNotes` to `FormSubmissionApproval`
- `includePaymentInPdf` to `FormSubmissionEventConfiguration`

### Fixed

- `approvalFormsInclusionConfig` to `approvalFormsInclusion` in `FormSubmissionEventConfiguration`
- `approvalFormInclusion` to `value` in `ApprovalFormsInclusionConfiguration`

## [3.0.6] - 2022-06-17

### Added

- `subCategoryLabel`, `subCategoryHint`, `itemLabel` and `itemHint` to `FormElement`
- `dependentFieldValue`, `type`, `freshdeskFieldName` to `FormSubmissionEventConfigurationMapping`

## [3.0.5] - 2022-06-09

### Added

- `EmailTemplate` properties
  - `environments`
  - `organisationId`

### Removed

- `EmailTemplate` properties
  - `template`
  - `formsAppEnvironmentId`
- `EmailTemplatesClient.Search()` `formsAppEnvironmentId` parameter

## [3.0.4] - 2022-05-31

### Added

- `formSubmissionPayments` to `FormSubmissionMetaResponse` class

## [3.0.3] - 2022-05-20

### Added

- `tierAdditions` to `Organisation` class

## [3.0.2] - 2022-05-03

### Changed

- `id` in `FormElementOption` model to be a string

### Added

- `FormStoreFormsApp` class

## [3.0.1] - 2022-04-19

### Added

- `compareWith` property to `ConditionallyShowPredicate`

## [3.0.0] - 2022-03-31

### Added

- [`FormsAppClient.GetSendingAddress()`](./docs/forms-apps-client#getsendingaddress)

### Changed

- **[BREAKING]** Changed `FormsAppClient.SetSendingAddress()` response type from `FormsAppSendingAddress` to `FormsAppSendingAddressResponse`

## [2.7.4] - 2022-03-16

### Added

- `clarificationRequestEmailTemplateId` to `FormApprovalFlowStepBase`

## [2.7.3] - 2022-01-24

### Added

- `uploadedAt` to `AttachmentData` class
- `description` to `FormsAppBase` class

## [2.7.2] - 2022-01-19

### Added

- Approval form inclusion on approval events
- Approval Form information to approvalStep related classes.
- [`FormsClient.GetFormSubmissionMeta()`](./docs/forms-client#getformsubmissionmeta)

## [2.7.1] - 2021-12-23

### Added

- `Migrate` to the `FormsClient` class

## [2.7.0] - 2021-12-21

### Added

- More events to forms

### Changed

- Drafts on submission events

## [2.6.1] - 2021-12-02

### Added

- `FreshdeskCreateTicket` to the submission events
- `freshdeskFieldName` to the FormElement class

## [2.6.0] - 2021-11-25

### Added

- `Email` to the submission events
- `createFilesElement()` as well as preventing extensionless attachments

## [2.5.5] - 2021-11-16

### Added

- Added `EmailTemplatesClient`

## [2.5.4] - 2021-11-11

### Added

- `emailTemplate` to `FormSubmissionEventConfiguration`
- Added `FormsAppEnvironmentsClient`

### Changed

- Updated `FormsClient.Search()` parameters.

## [2.5.3] - 2021-10-05

### Added

- `usePagesAsBreaks` to `FormSubmissionEventConfigration`
- `usePagesAsBreaks` to `PdfClient.GetSubmissionPdf()`

## [2.5.2] - 2021-09-27

### Added

- `groupFiles` to `FormSubmissionEventConfigration`

## [2.5.1] - 2021-09-15

### Added

- `GetFormSubmissionApproval` to `ApprovalsClient`
- `GetFormApprovalFlowInstance` to `ApprovalsClient`

## [2.5.0] - 2021-08-31

### Added

- `lastUpdatedBy`, `updatedAfterDateTime` and `updatedBeforeDateTime` parameters to `ApprovalsClient.GetFormSubmissionAdministrationApprovals()`
- `ipAddress` to `FormSubmission`
- `lastUpdatedBy` to `FormApprovalFlowInstance`

## [2.4.0] - 2021-08-24

### Added

- `isDescription` to `FormSubmissionEventCivicaElementMapping`

### Removed

- `civicaDescription` from `FormSubmissionEventConfiguration`

## [2.3.0] - 2021-08-11

### Added

- `ApprovalsClient`
- `externalIdGeneration` to `Form`

## [2.2.8] - 2021-08-02

### Added

- `serverValidation` to `Form`

## [2.2.7] - 2021-07-20

### Added

- `nylasAccountId`, `nylasSchedulingPageId`, `nameElementId` and `emailElementId` to `FormSubmissionEventConfigration`
- `CreateSchedulingSubmissionEvent()` to `FormSubmissionEvent`
- [`GenerateSubmissionAttachmentUrl()`](./docs/forms-client#generatesubmissionattachmenturl)

## [2.2.6] - 2021-06-30

### Added

- `excludedElementIds` to `PdfClient.GetSubmissionPdf()`

## [2.2.5] - 2021-06-23

### Added

- `civicaDescription`, `civicaCustomerContactMethod`, `civicaCategory` and `mapping` to `FormSubmissionEventConfiguration`
- `CreateCivicaCrmSubmissionEvent()` to `FormSubmissionEvent`
- `Boolean` element type to `FormElement`
- `useGeoscapeAddressing` and `CreateCivicaNameRecordElement()` to `FormElement`
- `isCollapsed` and `CreateSectionElement()` to `FormElement`

## [2.2.4] - 2021-06-02

### Fixed

- `description` not being set on form when passed to constructor

### Added

- `canToggleAll` to `FormElement`
- `customerReferenceNumber` to `FormSubmissionEventConfiguration`
- `CreateWestpacQuickWebSubmissionEvent()` to `FormSubmissionEvent`

## [2.2.3] - 2021-06-02

### Added

- `regexPattern`, `regexFlags` and `regexMessage` to `FormElement`
- `buttons` to `FormListStyles`

### Fixed

- Setting of `ContentDisposition` in `CreateSubmissionAttachment()`

### Changed

- Remove string value type validation from properties

## [2.2.2] - 2021-05-26

### Added

- `encryptPdf` prop to `FormSubmissionEventConfiguration` class
- `defaultValueDaysOffset`, `fromDateDaysOffset`, `toDateDaysOffset` to `FormElement`
- `cancelAction` and `cancelRedirectUrl` to `Form`
- Allowed value of `BACK` for `postSubmissionAction`

### Fixed

- `OneBlinkHttpClient.SendRequest()` to check content type before converting to json

### Changed

- Type of `FormElement.fromDate` and `FormElement.toDate` from `DateTime` to `string`

## [2.2.1] - 2021-05-19

### Changed

- Type of `value` from `int` to `double` in `ConditionallyShowPredicate` Model

### Added

- `recaptchaIntegrationDomainId` to `FormsAppBase`

## [2.2.0] - 2021-05-13

### Fixed

- `ConditionallyShowPredicate` class missing BETWEEN `type`

### Added

- `displayAsCurrency` to `FormElement`
- `storageType` to `FormElement`
- `formsAppEnvironment` to `FormsClient Search`
- `GetFormSubmissionAttachment` to `FormsClient`
- `CreateSubmissionAttachment` to `FormsClient`
- `author` to `FormSubmissionEventConfiguration`

## [2.1.0] - 2021-04-27

### Updated

- Forms App base with `isClientLoggingEnabled` prop

## [2.0.0] - 2021-04-15

### Added

- `GenerateSubmissionDataUrl` to `FormsClient`
- `KeysClient` class
- `GetMyFormsApp`, `CreateUser` and `DeleteUser` to `FormsAppClient`
- `Get` to `OrganisationsClient`
- `pointAddress` element type to `FormElement`

### Changed

- **[BREAKING]** replaced `FormsApp` class with `FormsListFormsApp`, `TilesFormsApp`, `ApprovalsFormsApp`, and `VolunteersFormsApp`

## [1.17.0] - 2021-03-23

### Added

- `GeneratePdf` function to `PdfClient`
- `SendEmail` function to `EmailClient`

### Changed

- Added `isDraft` and `includeSubmissionIdInPdf` parameters to `PdfClient.GetSubmissionPdf()`

## [1.16.0] - 2021-03-23

### Added

- `compliance` form element
- `hint` property to form elements with labels

## [1.15.0] - 2021-03-03

### Added

- `previousFormSubmissionApprovalId` to `FormUrlOptions`

## [1.14.0] - 2021-02-09

### Added

- Added `type`, `categories` and `waiverUrl` to `FormsApp`, `CONTAINER` and `FORM` to `AllowedMenuItemTypes`, `formIds` and `formId` to `FormsAppMenuItems`

## [1.13.0] - 2021-01-18

### Added

- [`GenerateFormUrl()`](./docs/forms-client.md#GenerateFormUrl) method
- [`EncryptUserToken()`](./docs/forms-client.md#EncryptUserToken) method
- [`DecryptUserToken()`](./docs/forms-client.md#DecryptUserToken) method
- `crn2` and `crn3` to `FormSubmissionEventConfigration`
- `includeSubmissionIdInPdf` to `FormSubmissionEventConfigration`
- `encryptedElementIds` and `excludedElementIds` to `FormSubmissionEventConfigration`
- [`CreateGeoscapeAddressElement()`](./docs/models/FormElement.md#geoscape-address-element) method

## [1.12.0] - 2020-11-12

### Added

- [`SetSendingAddress()`](./docs/forms-apps-client.md#SetSendingAddress) method
- [`DeleteSendingAddress()`](./docs/forms-apps-client.md#DeleteSendingAddress) method

## [1.11.0] - 2020-11-12

### Added

- isInteger prop to `FormElement`
- minLength and maxLength props to `FormElement` and `createTextElement` constructor

## [1.10.0] - 2020-10-15

### Added

- `OrganisationsClient`

## [1.9.0] - 2020-07-23

### Added

- `conditionallyExecutePredicates` to `FormSubmissionEvent`
- CRUD methods to [`FormsAppsClient`](./docs/forms-apps-client.md)

## [1.8.0] - 2020-07-09

### Added

- Added `environmentId` to `FormSubmissionEventConfiguration`

## [1.7.0] - 2020-07-06

### Added

- Added `overrideLock` parameter to update and delete form functions
- Added `gatewayId` to `FormSubmissionEventConfiguration`
- Added `placeholderValue` to `FormElement`
- Added `tags` to `Form`
- Added `publishStartDate` and `publishEndDate` to `Form`

## [1.6.0] - 2020-06-10

### Added

- FormsApps class and `VerifyJWT` method

## [1.5.1] - 2020-06-03

### Added

- `BPOINT` submission event type
- `CP_HCMS` `SubmissionEvent` type

## [1.4.0] - 2020-05-25

### Added

- CRUD methods to [`FormsClient`](./docs/forms-client.md)
- `summary` `FormElement` type

## [1.3.0] - 2020-04-06

### Removed

- Support for overriding api and pdf urls through .env variables

### Added

- Support for tenant selection when instantiating a client
- [`searchSubmissions()`](./docs/forms-client.md) function
- `limit` and `offset` parameters to `searchSubmissions()`

## [1.2.0] - 2020-02-13

### Added

- `priority` parameter to [`JobsClient.CreateJob()`](<./docs/jobs-client.md#createjob(job)>)
- `device` property to `FormSubmission` class

## [1.1.0] - 2020-01-30

### Added

- [`JobsClient`](./docs/jobs-client.md) class

## [1.0.1] - 2019-06-20

### Added

- `isDraft` parameter to [`FormsClient.GetFormSubmission()`](./docs/forms-client.md#getformsubmission)
- [`TeamMembersClient`](./docs/team-members-client.md) class

## [1.0.0] - 2019-06-18

Initial production release
