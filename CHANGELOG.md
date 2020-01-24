# Changelog

## Unreleased

### Removed 

-   [`NewJob()`] class
-   Use the [`Job()`] class instead
### Changed 

-   the properties and class structure of [`Job()`], [`JobDetail()`] and [`JobsSearchParameters()`]
-   Constructors for each class can now used instantiate all relevant properties
-   The [`Job()`] class is now passed to [`JobsClient.createJob()`] instead of [`NewJob()`]

### Changed 

-   The name of [`JobsClient.search()`] function to [`JobsClient.searchJobs()`]

### Added

-   [`JobsClient`](./docs/jobs-client.md) class

## 1.0.1 (2019-06-20) The Killer Orangutan

### Added

-   `isDraft` parameter to [`FormsClient.GetFormSubmission()`](./docs/forms-client.md#getformsubmission)
-   [`TeamMembersClient`](./docs/team-members-client.md) class

## 1.0.0

Initial production release
