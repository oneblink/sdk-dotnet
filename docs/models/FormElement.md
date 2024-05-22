# OneBlink .Net SDK | FormElement Model

## `FormElement`

### Constructor

Only a default constructor is provided, instead it is recommended to create a FormElement using the static functions

### Properties

| Property                                 | Required                          | Type                                | Description                                                                                                                                                                                                                                                                                                                                                              | Default Value |
| ---------------------------------------- | --------------------------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------- |
| `id`                                     | Yes                               | `Guid`                              |                                                                                                                                                                                                                                                                                                                                                                          |               |
| `name`                                   | Yes                               | `string`                            |                                                                                                                                                                                                                                                                                                                                                                          |               |
| `label`                                  | Yes                               | `string`                            |                                                                                                                                                                                                                                                                                                                                                                          |               |
| `conditionallyShow`                      | No                                | `Boolean?`                          | Whether the form is always of conditionally shown                                                                                                                                                                                                                                                                                                                        | false         |
| `requiresAllConditionallyShowPredicates` | No                                | `Boolean?`                          | Whether all predicates must be true to show element                                                                                                                                                                                                                                                                                                                      | false         |
| `type`                                   | Yes                               | `string`                            | "text", "email", "textarea", "number", "select","checkboxes", "radio", "draw", "camera", "date", "time", "datetime", "heading", "location", "repeatableSet", "page", "html", "barcodeScanner", "captcha", "image", "file", "files", "calculation", "telephone", "autocomplete", "form", "infoPage", "geoscapeAddress", "summary","compliance", "pointAddress", "boolean" |               |
| `required`                               | Yes                               | `Boolean?`                          | Whether the user us required to provided a value for this element                                                                                                                                                                                                                                                                                                        | false         |
| `readOnly`                               | No                                | `Boolean?`                          | Whether the user can modify the elements value                                                                                                                                                                                                                                                                                                                           | false         |
| `conditionallyShowPredicates`            | No                                | `List<ConditionallyShowPredicate>`  | List of elements to be used as conditions                                                                                                                                                                                                                                                                                                                                | null          |
| `defaultValue`                           | No                                | `dynamic`                           | The default value for this element                                                                                                                                                                                                                                                                                                                                       | null          |
| `defaultValueDaysOffset`                 | No                                | `long?                              | The number of days to offset the default value for date and datetime elements                                                                                                                                                                                                                                                                                            | null          |
| `buttons`                                | No                                | `Boolean?`                          | Determines if this element is shown as buttons (applies to Radio buttons and checkboxes)                                                                                                                                                                                                                                                                                 | false         |
| `multi`                                  | No                                | `Boolean?`                          | Whether the element is a single or multiple selection (applies to select elements)                                                                                                                                                                                                                                                                                       | false         |
| `isSlider`                               | No                                | `Boolean?`                          | Whether this element is shown as a slider (applies to number elements)                                                                                                                                                                                                                                                                                                   | false         |
| `sliderIncrement`                        | No                                | `long?`                             | The size of the increments to be applied when slider is moved (applies to number elements using isSlider)                                                                                                                                                                                                                                                                |               |
| `minNumber`                              | No                                | `long?`                             | The minimum number that can entered by the user (applies to number element)                                                                                                                                                                                                                                                                                              |               |
| `maxNumber`                              | No                                | `long?`                             | The maximum number that can entered by the user (applies to number element)                                                                                                                                                                                                                                                                                              |               |
| `headingType`                            | No                                | `long?`                             | The size of the heading from 1 to 5 (applies to heading elements)                                                                                                                                                                                                                                                                                                        |               |
| `fromDate`                               | No                                | `string`                            | The minimum date as an iso string (datetime), 'yyyy-mm-dd' (date) or the constant 'NOW', that can be entered by the user (applies to date and datetime elements)                                                                                                                                                                                                         |
| `fromDateElementId`                      | No                                | `string`                            | This is a GUID that references an Element Id. This ID will be in reference to another element that will determine the starting date range of a date and/or datetime element. This will take precendence over fromDate and both are allowed                                                                                                                               |               |
| `fromDateDaysOffset`                     | No                                | `long?`                             | The number of days to offset the fromDate value for date and datetime elements                                                                                                                                                                                                                                                                                           |               |
| `toDateElementId`                        | No                                | `string`                            | This is a GUID that references an Element Id. This ID will be in reference to another element that will determine the end date range of a date and/or datetime element. This will take precendence over toDate and both are allowed                                                                                                                                      |               |
| `toDate`                                 | No                                | `string`                            | The maximum date as an iso string (datetime), 'yyyy-mm-dd' (date) or the constant 'NOW', that can be entered by the user (applies to date and datetime elements)                                                                                                                                                                                                         |               |
| `toDateDaysOffset`                       | No                                | `long?`                             | The number of days to offset the toDate value for date and datetime elements                                                                                                                                                                                                                                                                                             |               |
| `optionsType`                            | No                                | `string`                            | The type of the options supplied, valid values are "CUSTOM", "DYNAMIC", "SEARCH" (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                            |               |
| `dynamicOptionSetId`                     | No                                | `long?`                             | The id of the dynamic options set to be used with this element (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                              |               |
| `freshdeskFieldName`                     | No                                | `string`                            | The name of freshdesk ticket field to be used with this element (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                             |               |
| `options`                                | No                                | `List<FormElementOption>`           | List of form element options (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                                                                |               |
| `attributesMapping`                      | No                                | `List<FormElementAttributeMapping>` | List of form element attribute mapping (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                                                      |               |
| `conditionallyShowOptions`               | No                                | `Boolean?`                          | Whether to show certain options conditionally (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                                               |               |
| `conditionallyShowOptionsElementIds`     | No                                | `List<Guid>`                        | List of option element ids (applies to checkboxes, radio, compliance, select and autocomplete elements)                                                                                                                                                                                                                                                                  |               |
| `minSetEntries`                          | No                                | `dynamic`                           | The minimum number of entries that can be entered by the user (applies to repeatable set elements). This should be either a `long` or `FormElementRepeatableSetEntriesConstraint`.                                                                                                                                                                                       |               |
| `maxSetEntries`                          | No                                | `dynamic`                           | The maximum number of entries that can be entered by the user (applies to repeatable set elements). This should be either a `long` or `FormElementRepeatableSetEntriesConstraint`.                                                                                                                                                                                       |               |
| `addSetEntryLabel`                       | No                                | `string`                            | The label to be shown with the add set entry button (applies to repeatable set elements)                                                                                                                                                                                                                                                                                 |               |
| `removeSetEntryLabel`                    | No                                | `string`                            | The label to be shown with the remove set entry button (applies to repeatable set elements)                                                                                                                                                                                                                                                                              |               |
| `elements`                               | No                                | `List<FormElement>`                 | The elements that are part of the repeatable set (applies to repeatable set elements)                                                                                                                                                                                                                                                                                    |               |
| `restrictBarcodeTypes`                   | No                                | `Boolean?`                          | Whether to restrict the barcode types that can be read (applies to barcode elements)                                                                                                                                                                                                                                                                                     | false         |
| `restrictedBarcodeTypes`                 | No                                | `List<string>`                      | List of barcode types that will be scanned for (applies to barcode elements)                                                                                                                                                                                                                                                                                             |               |
| `calculation`                            | No                                | `string`                            | Formula to be used for calculation (applies to calculation elements)                                                                                                                                                                                                                                                                                                     |               |
| `preCalculationDisplay`                  | No                                | `string`                            | Text to be display whilst the calculation does not have a result (applies to calculation elements)                                                                                                                                                                                                                                                                       |               |
| `isDataLookup`                           | No                                | `Boolean?`                          | Whether this element will include a lookup button                                                                                                                                                                                                                                                                                                                        | false         |
| `elementLookupId`                        | No                                | `long?`                             | The id of the lookup being applied to this element                                                                                                                                                                                                                                                                                                                       |               |
| `formId`                                 | No                                | `long?`                             | The id of the form to be included (applies to form and infoPage elements)                                                                                                                                                                                                                                                                                                |               |
| `searchUrl`                              | No                                | `string`                            | The url to be used for searching for options (applies to checkboxes, radio, compliance select and autocomplete elements)                                                                                                                                                                                                                                                 |               |
| `restrictFileTypes`                      | No                                | `Boolean?`                          | Whether to restrict files types (applies to file and files elements)                                                                                                                                                                                                                                                                                                     |               |
| `restrictedFileTypes`                    | No                                | `List<string>`                      | List of file types to allow (applies to file and files elements)                                                                                                                                                                                                                                                                                                         |               |
| `minEntries`                             | No                                | `int?`                              | Minimum of files allowed (applies to files elements)                                                                                                                                                                                                                                                                                                                     |               |
| `maxEntries`                             | No                                | `int?`                              | Maximum of files allowed (applies to files elements)                                                                                                                                                                                                                                                                                                                     |               |
| `elementIds`                             | No                                | `List<Guid>`                        | List of element Ids to be summarised (applies to summary elements)                                                                                                                                                                                                                                                                                                       |               |
| `placeholderValue`                       | No                                | `string`                            | Placeholder text for element (applies to autocomplete, number, text, textarea, email and barcode scanner elements)                                                                                                                                                                                                                                                       |               |
| `minLength`                              | No                                | `int?`                              | Minimum length of a text field (applies to text and multiline elements)                                                                                                                                                                                                                                                                                                  |               |
| `maxLength`                              | No                                | `int?`                              | Maximum length of a text field (applies to text and multiline elements)                                                                                                                                                                                                                                                                                                  |               |
| `isInteger`                              | No                                | `Boolean?`                          | Whether the number is required to be an integer only (no decimals) (applies to number elements)                                                                                                                                                                                                                                                                          |               |
| `stateTerritoryFilter`                   | No                                | `List<string>`                      | An array of Australian State and/or Territory abbreviations that the search should be limited to.                                                                                                                                                                                                                                                                        |               |
| `hint`                                   | No                                | `string`                            | Text to display along with the label of the element with more instructions.                                                                                                                                                                                                                                                                                              |               |
| `hintPosition`                           | No                                | `string`                            | The position in which the hint will appear. Allowed values are "BELOW_LABEL" and "TOOLTIP".                                                                                                                                                                                                                                                                              |               |
| `addressTypeFilter`                      | No                                | `List<string>`                      | An array of address types that the search should be limited to.                                                                                                                                                                                                                                                                                                          |               |
| `displayAsCurrency`                      | No                                | `Boolean?`                          | Configure Calculation element to display result as currency.                                                                                                                                                                                                                                                                                                             |               |
| `storageType`                            | No                                | `string`                            | Configure storage type of elements that contain binary data(camera, draw and files). Allowed values are "legacy", "public", "private".                                                                                                                                                                                                                                   |               |
| `regexPattern`                           | No                                | `string`                            | Configure input validation using a regular expression with a custom error message (applies to number, text, textarea, email, telephone and barcode scanner elements)                                                                                                                                                                                                     |               |
| `regexFlags`                             | No                                | `string`                            | Regular expression validation flags                                                                                                                                                                                                                                                                                                                                      |               |
| `regexMessage`                           | Yes if `regexPattern` has a value | `string`                            | The error message if input does not match regex pattern                                                                                                                                                                                                                                                                                                                  |               |
| `canToggleAll`                           | No                                | `Boolean?`                          | Allows toggling of all options (applies to checkbox and select(with multi set as true) elements)                                                                                                                                                                                                                                                                         |               |
| `useGeoscapeAddressing`                  | No                                | `Boolean?`                          | Allows using geoscape Addressing service with the Civica Name Record element                                                                                                                                                                                                                                                                                             |               |
| `isCollapsed`                            | No                                | `Boolean?`                          | Default to collapsed (applies to section element)                                                                                                                                                                                                                                                                                                                        |               |
| `giveName1Label`                         | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `giveName1IsRequired`                    | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `giveName1IsHidden`                      | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `emailAddressLabel`                      | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `emailAddressIsRequired`                 | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `emailAddressIsHidden`                   | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `homePhoneLabel`                         | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `homePhoneIsRequired`                    | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `homePhoneIsHidden`                      | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `businessPhoneLabel`                     | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `businessPhoneIsRequired`                | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `businessPhoneIsHidden`                  | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `mobilePhoneLabel`                       | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `mobilePhoneIsRequired`                  | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `mobilePhoneIsHidden`                    | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `faxPhoneLabel`                          | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `faxPhoneIsRequired`                     | No                                | `Boolean?`                          | Whether this field is required to be filled in when the element is rendered.                                                                                                                                                                                                                                                                                             | `false`       |
| `faxPhoneIsHidden`                       | No                                | `Boolean?`                          | Whether this field is hidden when the element is rendered.                                                                                                                                                                                                                                                                                                               | `false`       |
| `address1Label`                          | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `address2Label`                          | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `postcodeLabel`                          | No                                | `string`                            | The label that will be set for this field when the element is rendered.                                                                                                                                                                                                                                                                                                  |               |
| `subCategoryLabel`                       | No                                | `string`                            | Display text presented to the user above the sub category input by default.                                                                                                                                                                                                                                                                                              |               |
| `subCategoryHint`                        | No                                | `string`                            | A hint triggered by an icon tooltip to be displayed when hovering beside the sub category label.                                                                                                                                                                                                                                                                         |               |
| `itemLabel`                              | No                                | `string`                            | Display text presented to the user above the item input by default.                                                                                                                                                                                                                                                                                                      |               |
| `itemHint`                               | No                                | `string`                            | A hint triggered by an icon tooltip to be displayed when hovering beside the item label.                                                                                                                                                                                                                                                                                 |               |
| `customCssClasses`                       | No                                | `List<string>`                      | Custom CSS classes that will be added to the form during rendering                                                                                                                                                                                                                                                                                                       |               |
| `meta`                                   | No                                | `string`                            | JSON metadata associated with the form element. This field is for primarily for developer use.                                                                                                                                                                                                                                                                           |               |
| `webMapId`                               | No                                | `string`                            | ArcGIS Web map Id.                                                                                                                                                                                                                                                                                                                                                       |               |
| `showLayerPanel`                         | No                                | `bool`                              | Show layer panel to user when rendering ArcGIS web map.                                                                                                                                                                                                                                                                                                                  |               |
| `decorativeImage`                        | No                                | `bool?`                             | Whether the image element is decorative or not for screen readers.                                                                                                                                                                                                                                                                                                       |               |
| `showStreetAddress`                      | No                                | `bool?`                             | Whether the location element will pre-fill an element with a formatted address based on chosen location.                                                                                                                                                                                                                                                                 |               |
| `formattedAddressElementId`              | No                                | `string`                            | The element ID of the element that will be pre-filled with a formatted address after selecting a location with a location element. This can only be used for Geoscape elements with the Geoscape Integrations.                                                                                                                                                           |               |

### Static Functions

#### Text Element

##### `FormElement.CreateTextElement()`

Creates a new FormElement defined as a text element, including all parameters that are relevant to summary elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid`                             | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `required`                             | No       | `bool`                             | `false`       |
| `readOnly`                             | No       | `bool`                             | `false`       |
| `defaultValue`                         | No       | `string`                           | `null`        |

##### Example

```c#
FormElement textElement = FormElement.CreateTextElement(
    "Unit_test_element",
    "Unit test element",
    Guid.NewGuid(),
    false,
    false,
    null,
    true,
    false,
    "default Value"
);
```

#### Geoscape Address Element

##### `FormElement.CreateGeoscapeAddressElement()`

Creates a new FormElement defined as a `geoscapeAddress` element, including all parameters that are relevant to Geoscape Address elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid`                             | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `stateTerritoryFilter`                 | No       | `List<string>`                     | `null`        |

##### Example

```c#
FormElement geoscapeAddressElement = FormElement.CreateGeoscapeAddressElement(
    "Geoscape_test_element",
    "Geoscape test element"
);
```

#### Summary Element

##### `FormElement.CreateSummaryElement()`

Creates a new FormElement defined as a summary element, including all parameters that are relevant to summary elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `elementIds`                           | Yes      | `List<Guid>`                       |               |
| `id`                                   | No       | `Guid`                             | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |

##### Example

```c#
FormElement summaryElement = FormElement.CreateSummaryElement(
    "Summary_test_element",
    "Summary test element",
    new List<Guid>() { textElement.id },
    Guid.NewGuid(),
    false,
    false,
    null
);
```

#### Compliance Element

##### `FormElement.CreateComplianceElement()`

Creates a new FormElement defined as a compliance element, including all parameters that are relevant to compliance elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `options`                              | Yes      | `List<FormElementOption>`          |               |
| `id`                                   | No       | `Guid?`                            | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `required`                             | No       | `bool`                             | `false`       |
| `readOnly`                             | No       | `bool`                             | `false`       |
| `defaultValue`                         | No       | `string`                           | `null`        |
| `hint`                                 | No       | `string`                           | `null`        |
| `isDataLookup`                         | No       | `bool`                             | `false`       |
| `dataLookupId`                         | No       | `long?`                            | `null`        |
| `isElementLookup`                      | No       | `bool`                             | `false`       |
| `elementLookupId`                      | No       | `long?`                            | `null`        |

##### Example

```c#
FormElementOption option = new FormElementOption();
option.id = Guid.NewGuid();
option.value = "A";
option.label = "A";
FormElement complianceElement = FormElement.CreateComplianceElement(
    "Compliance_test_element",
    "Compliance_test_element",
    new List<FormElementOption>(){option}
);
```

#### Point Address Element

##### `FormElement.CreatePointAddressElement()`

Creates a new FormElement defined as a `pointAddress` element, including all parameters that are relevant to Point Address elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid`                             | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `stateTerritoryFilter`                 | No       | `List<string>`                     | `null`        |
| `addressTypeFilter`                    | No       | `List<string>`                     | `null`        |

##### Example

```c#
FormElement pointAddressElement = FormElement.CreatePointAddressElement(
    "Point_test_element",
    "Point test element"
);
```

#### Boolean Element

##### `FormElement.CreateBooleanElement()`

Creates a new FormElement defined as a Boolean element, including all parameters that are relevant to boolean elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid?`                            | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `required`                             | No       | `bool`                             | `false`       |
| `readOnly`                             | No       | `bool`                             | `false`       |
| `defaultValue`                         | No       | `bool`                             | `false`       |
| `hint`                                 | No       | `string`                           | `null`        |
| `isDataLookup`                         | No       | `bool`                             | `false`       |
| `dataLookupId`                         | No       | `long?`                            | `null`        |
| `isElementLookup`                      | No       | `bool`                             | `false`       |
| `elementLookupId`                      | No       | `long?`                            | `null`        |

##### Example

```c#
FormElement booleanElement = FormElement.CreateBooleanElement(
    name: "Boolean_test_element",
    label: "Boolean_test_element",
    defaultValue: true,
    required: true,
    hint: "This is a hint."

);
```

#### Civica Name Record Element

##### `FormElement.CreateCivicaNameRecordElement()`

Creates a new FormElement defined as a Civica Name record element, including all parameters that are relevant to Civica name record elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `name`                                 | Yes      | `string`                           |               |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid?`                            | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `required`                             | No       | `bool`                             | `false`       |
| `readOnly`                             | No       | `bool`                             | `false`       |
| `defaultValue`                         | No       | `dynamic`                          | `null`        |
| `hint`                                 | No       | `string`                           | `null`        |
| `useGeoscapeAddressing`                | No       | `bool`                             | `false`       |
| `titleLabel`                           | No       | `string`                           |               |
| `familyNameLabel`                      | No       | `string`                           |               |
| `giveName1Label`                       | No       | `string`                           |               |
| `giveName1IsRequired`                  | No       | `Boolean?`                         | `false`       |
| `giveName1IsHidden`                    | No       | `Boolean?`                         | `false`       |
| `emailAddressLabel`                    | No       | `string`                           |               |
| `emailAddressIsRequired`               | No       | `Boolean?`                         | `false`       |
| `emailAddressIsHidden`                 | No       | `Boolean?`                         | `false`       |
| `homePhoneLabel`                       | No       | `string`                           |               |
| `homePhoneIsRequired`                  | No       | `Boolean?`                         | `false`       |
| `homePhoneIsHidden`                    | No       | `Boolean?`                         | `false`       |
| `businessPhoneLabel`                   | No       | `string`                           |               |
| `businessPhoneIsRequired`              | No       | `Boolean?`                         | `false`       |
| `businessPhoneIsHidden`                | No       | `Boolean?`                         | `false`       |
| `mobilePhoneLabel`                     | No       | `string`                           |               |
| `mobilePhoneIsRequired`                | No       | `Boolean?`                         | `false`       |
| `mobilePhoneIsHidden`                  | No       | `Boolean?`                         | `false`       |
| `faxPhoneLabel`                        | No       | `string`                           |               |
| `faxPhoneIsRequired`                   | No       | `Boolean?`                         | `false`       |
| `faxPhoneIsHidden`                     | No       | `Boolean?`                         | `false`       |
| `streetAddressesLabel`                 | No       | `string`                           |               |
| `address1Label`                        | No       | `string`                           |               |
| `address2Label`                        | No       | `string`                           |               |
| `postcodeLabel`                        | No       | `string`                           |               |

##### Example

```c#
FormElement civicaNameRecordElement = FormElement.CreateCivicaNameRecordElement(
    name: "CivicaNameRecord_test_element",
    label: "CivicaNameRecord_test_element",
    required: true,
    hint: "This is a hint.",
    useGeoscapeAddressing: true
);
```

#### Section Element

##### `FormElement.CreateSectionElement()`

Creates a new FormElement defined as a Section element, including all parameters that are relevant to section elements only

| Parameter                              | Required | Type                               | Default Value |
| -------------------------------------- | -------- | ---------------------------------- | ------------- |
| `label`                                | Yes      | `string`                           |               |
| `id`                                   | No       | `Guid?`                            | `new Guid()`  |
| `conditionallyShow`                    | No       | `bool`                             | `false`       |
| `requiresAllConditonallyShowPredicate` | No       | `bool`                             | `false`       |
| `conditionallyShowPredicates`          | No       | `List<ConditionallyShowPredicate>` | `null`        |
| `hint`                                 | No       | `string`                           | `null`        |
| `isCollapsed`                          | No       | `bool`                             | `false`       |
| `elements`                             | No       | `List<FormElement>`                | `null`        |

##### Example

```c#
List<FormElement> sectionElements = new List<FormElement>();
FormElement civicaNameRecordElement = FormElement.CreateSectionElement(
    label: "Section_test_element",
    hint: "This is a hint.",
    isCollapsed: true,
    elements: sectionElements
);
```
