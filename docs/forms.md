# OneBlink .Net SDK | Forms Class

## Instance Functions

- [`search()`](#search)

## Constructor

| Parameter | Required | Type | Description
|---|---|---|---|
| `accessKey` | Yes | `string` | Access key provided by OneBlink. |
| `secretKey` | Yes | `string` | Secret key provided by OneBlink. |

### Example

```c#
using OneBlink.SDK;
string accessKey= "123455678901ABCDEFGHIJKL";
string secretKey= "123455678901ABCDEFGHIJKL123455678901ABCDEFGHIJKL";
Forms forms = new Forms(accessKey, secretKey);
```

## `search()`

### Example

```c#
bool? isAuthenticated = null;
bool? isPublished = null;
string name = null;
string response = await forms.search(isAuthenticated, isPublished, name);
```

### Parameters

| Parameter | Required | Type | Description
|---|---|---|---|
| `isAuthenticated` | Yes | `bool?` | Return authenticated forms or unauthenticated forms. If null provided, all forms will be returned. |
| `isPublished` | Yes | `bool?` | Return published forms or unpublished forms. If null provided, all forms will be returned. |
| `name` | Yes | `string` | Search on the name property of a form. Can be a prefix, suffix or partial match. If null or whitespace provided, all forms will be returned. |

### Result

A string containing the following JSON:

```json
{
  "meta": {
    "limit": null,
    "offset": null,
    "nextOffset": null
  },
  "forms": [
    {
      "id": 1,
      "name": "testsform",
      "description": "a form",
      "organisationId": "0101010101010",
      "elements": [],
      "isAuthenticated": false,
      "isPublished": true,
      "submissionEvents": [],
      "postSubmissionAction": "FORMS_LIBRARY",
      "isInfoPage": false,

    }
  ]
}
```
