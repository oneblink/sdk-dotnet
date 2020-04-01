# Changelog

## Unreleased

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
