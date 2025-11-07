# OneBlink .Net SDK | Form Model

## `Form()`

### Constructor

| Parameter                      | Required | Type                        | Description                                                                                                                 | Default Value                     |
| ------------------------------ | -------- | --------------------------- | --------------------------------------------------------------------------------------------------------------------------- | --------------------------------- |
| `name`                         | Yes      | `string`                    |                                                                                                                             |                                   |
| `description`                  | Yes      | `string`                    |                                                                                                                             |                                   |
| `organisationId`               | Yes      | `string`                    | Id of the organisation this form is associated too                                                                          |                                   |
| `formsAppEnvironmentId`        | Yes      | `long`                      | Id of the environment this form is part of                                                                                  |                                   |
| `formsAppIds`                  | No       | `List<long>`                | List of Form Apps id's                                                                                                      | `new List<long>()`                |
| `elements`                     | No       | `List<FormElement>`         | List of FormElement's                                                                                                       | `new List<FormElement>()`         |
| `id`                           | No       | `long?`                     | Will be assigned by OneBlink when form is creating                                                                          | `null`                            |
| `postSubmissionAction`         | No       | `string`                    | Allowed values of "BACK", "URL", "CLOSE", "FORMS_LIBRARY"                                                                   | `"FORMS_LIBRARY"`                 |
| `isAuthenticated`              | No       | `bool`                      | Determines if only authenticated users can access the form                                                                  | `true`                            |
| `submissionEvents`             | No       | `List<FormSubmissionEvent>` | List of Form submission events                                                                                              | `new List<FormSubmissionEvent>()` |
| `draftEvents`                  | No       | `List<FormSubmissionEvent>` | List of Form draft events                                                                                                   | `new List<FormSubmissionEvent>()` |
| `schedulingEvents`             | No       | `List<FormSubmissionEvent>` | List of Form scheduling events                                                                                              | `new List<FormSubmissionEvent>()` |
| `approvalSteps`                | No       | `List<FormSubmissionEvent>` | List of Form approval steps                                                                                                 | `new List<FormApprovalStep>()`    |
| `approvalEvents`               | No       | `List<FormSubmissionEvent>` | List of Form approval events                                                                                                | `new List<FormSubmissionEvent>()` |
| `isMultiPage`                  | No       | `bool`                      | Determines if this form a single page form or multi page form                                                               | `false`                           |
| `redirectUrl`                  | No       | `string`                    | URL to be redirected too, only applies if `postSubmissionAction` is "URL"                                                   | `null`                            |
| `tags`                         | No       | `List<string>`              | List of tags to be associated with the form                                                                                 | `new List<string>()`              |
| `publishStartDate`             | No       | `DateTime?`                 | DateTime the form should become available                                                                                   | `null`                            |
| `publishEndDate`               | No       | `DateTime?`                 | DateTime the form should become unavailable                                                                                 | `null`                            |
| `unpublishedUserMessage`       | No       | `string`                    | The message to be shown to forms users when the form is not in the published time window                                    | `null`                            |
| `cancelAction`                 | No       | `string`                    | Allowed values of "BACK", "URL", "CLOSE", "FORMS_LIBRARY"                                                                   | `"BACK"`                          |
| `cancelRedirectUrl`            | No       | `string`                    | URL to be redirected too, only applies if `cancelAction` is "URL"                                                           | `null`                            |
| `serverValidation`             | No       | `FormServerValidation`      | Optional configuration for form submission validation                                                                       | `null`                            |
| `externalIdGenerationOnSubmit` | No       | `FormExternalIdGeneration`  | Optional configuration for generating externalId after serverValidation but before submission                               | `null`                            |
| `personalisation`              | No       | `FormPersonalisation`       | Optional configuration for prefilling elements or generating new elements on form load                                      | `null`                            |
| `approvalConfiguration`        | No       | `FormApprovalConfiguration` | Optional configuration for approvals                                                                                        | `null`                            |
| `submissionTitle`              | No       | `string`                    | Optional configuration for the default submission title                                                                     | `null`                            |
| `continueWithAutosave`         | No       | `boolean`                   | Whether or not viewing the form should auto-continue with autosave data when available rather than prompting the user title | `false`                           |
| `customCssClasses`             | No       | `List<string>`              | Custom CSS classes that will be added to the form during rendering                                                          | `new List<string>()`              |
| `pointAddressEnvironmentId`    | No       | `Guid?`                     | Optional except when `elements` contains a Point Address element                                                            | `null`                            |
| `allowGeoscapeAddresses`       | No       | `bool?`                     | Optional configuration to allow use of Geoscape elements on the form                                                        | `null`                            |
| `slug`                         | No       | `string`                    | Unique domain safe text to identify the form                                                                                | `null`                            |
| `enableSubmission`             | No       | `FormEnableSubmission`      | Conditionally enable form submission                                                                                        | `null`                            |
| `disableAutosave`              | No       | `bool?`                     | Optionally disable autosave                                                                                                 | `null`                            |
| `customPDFs`                   | no       | `List<FormCustomPDF>`       | Optional custom PDFs that can be used in place of the OOTB PDF                                                              | `null`                            |
| `isAIBuilderSupported`         | no       | `bool?`                     | Optional Whether or not the form can be edited using an AI builder.                                                         | `null`                            |

### Other properties

| Property    | Type       | Description                        |
| ----------- | ---------- | ---------------------------------- |
| `createdAt` | `DateTime` | DateTime the form was created      |
| `updatedAt` | `DateTime` | DateTime the form was last updated |
