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

## Permissions

The majority of actions in this SDK require that your developer key has particular permissions. These permissions can be set in your tenant's console. If you do not have access to your tenant's console, you will need to work with your Administrator to associate the permissions that you require with your key. The associated permissions for each function are detailed on the function definitions.

### Developer Key & Role

Actions that allow a developer key with a minimum role permission will have the following in the function definition:

**Minimum Role Permission**

The developer key used must be assigned a role with at least the permission documented for each action. E.g. If the action's minimum role permission is _Forms: Read Only_, the role assigned to the developer key could have _Forms: Read Only_ or _Forms: Manager_.

### Developer Key & App Association

Actions that require a developer key to be assigned to an app will have the following in the function definition:

**App Association Required**

In the case of any actions relating to forms, the assigned app must be associated with the form that is being actioned. A form can be associated with an app in the following ways:

- For _Forms List_ type apps, the form can be in the _Forms List_ menu item.
- For _Tiles_ type apps, the form can be in a _Container_ menu item or added directly to the menu via a _Form_ menu item.
- For _Tiles_ or _Forms List_ type apps, the form can be assigned to an action in a _Scheduled task_.
- For _Approvals_ type apps, the form can be an _Approval form_.

**Submission Data Key Supported**

In the case of any actions relating to retrieving form submission data, a Submission Data developer key can be used so long as the developer key has been assigned to the form that is being actioned.

## Clients

- [FormsClient](./forms-client.md)
- [FormsAppsClient](./forms-apps-client.md)
- [FormsAppEnvironmentsClient](./forms-app-environments.md)
- [PdfClient](./pdf-client.md)
- [TeamMembersClient](./team-members-client.md)
- [JobsClient](./jobs-client.md)
- [OrganisationsClient](./organisations-client.md)
- [KeysClient](./keys-client.md)
- [EmailClient](./email-client.md)
- [EmailTemplateClient](./email-template-client.md)
- [ApprovalsClient](./approvals-client.md)
- [DataManagerClient](./data-manager-client.md)

## Models

- [Job](./models/job.md)
- [JobDetail](./models/jobDetail.md)
- [JobsSearchParameters](./models/jobsSearchParameters.md)
- [Form](./models/Form.md)
- [FormElement](./models/FormElement.md)
