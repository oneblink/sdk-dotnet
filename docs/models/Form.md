# OneBlink .Net SDK | Form Model

## `Form()`

### Constructor

| Parameter               | Required | Type                        | Description                                                               | Default Value |
| ----------------------- | -------- | --------------------------- | ------------------------------------------------------------------------- | ------------- |
| `name`                  | Yes      | `string`                    |                                                                           |               |
| `description`           | Yes      | `string`                    |                                                                           |               |
| `organisationId`        | Yes      | `string`                    | Id of the organisation this form is associated too                        |               |
| `postSubmissionAction`  | Yes      | `string`                    | Allowed values of "URL", "CLOSE", "FORMS_LIBRARY"                         |               |
| `formsAppIds`           | Yes      | `List<long>`                | List of Form Apps id's, at least one is required                          |               |
| `formsAppEnvironmentId` | Yes      | `long`                      | Id of the environment this form is part of                                |               |
| `elements`              | No       | `List<FormElement>`         |                                                                           | null          |
| `isAuthenticated`       | No       | `bool`                      | Determines if only authenticated users can access the form                | true          |
| `submissionEvents`      | No       | `List<FormSubmissionEvent>` | List of Form submission events                                            | null          |
| `isMultiPage`           | No       | `bool`                      | Determines if this form a single page form or mutli page form             | false         |
| `redirectUrl`           | No       | `string`                    | URL to be redirected too, only applies if `postSubmissionAction` is "URL" | null          |
| `isInfoPage`            | No       | `bool`                      | Determines if form can only contain information elements                  | false         |

### Other properties

| Property    | Type       | Description                        |
| ----------- | ---------- | ---------------------------------- |
| `createdAt` | `DateTime` | DateTime the form was created      |
| `updatedAt` | `Dateime`  | DateTime the form was last updated |