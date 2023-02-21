# OneBlink .Net SDK | Usage

## 4.0 Migration

### Forms.Search()

In previous versions (< 4.0), this function returned all forms in one call. This is no longer the case and mandatory pagination is now enforced.

If no `limit` is provided, this is set to 200. If no `offset` is provided, this is set to `0`.

If you currently have more than 200 forms returned from this function, or expect to have more than 200 forms returned, you will need to update your code to account for this.
If you do need to account for this, accessing all forms as you previously could now requires that you make multiple calls to this function. This could look something like:

```C#
long? nextOffset = 0;
List<Form> forms = new List<Form>();

while (nextOffset != null) {
    var result = await client.Search(
        // ...filters
        limit: 100,
        offset: (int)nextOffset
    );
    forms.AddRange(result.forms);
    nextOffset = result.meta.nextOffset;
}

// Use `forms`

```

Alternately, you could integrate pagination directly into your application.

## Clients

-   [FormsClient](./forms-client.md)
-   [FormsAppsClient](./forms-apps-client.md)
-   [FormsAppEnvironmentsClient](./forms-app-environments.md)
-   [PdfClient](./pdf-client.md)
-   [TeamMembersClient](./team-members-client.md)
-   [JobsClient](./jobs-client.md)
-   [OrganisationsClient](./organisations-client.md)
-   [KeysClient](./keys-client.md)
-   [EmailClient](./email-client.md)
-   [EmailTemplateClient](./email-template-client.md)
-   [ApprovalsClient](./approvals-client.md)
-   [DataManagerClient](./data-manager-client.md)

## Models

-   [Job](./models/job.md)
-   [JobDetail](./models/jobDetail.md)
-   [JobsSearchParameters](./models/jobsSearchParameters.md)
-   [Form](./models/Form.md)
-   [FormElement](./models/FormElement.md)
