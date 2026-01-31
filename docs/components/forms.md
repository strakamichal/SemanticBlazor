# Form Components

## SemForm

**Inherits:** `SemControlBase`

A form container with validation support using DataAnnotations.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Form content |
| Model | object | null | Form model for validation |
| OnValidSubmit | EventCallback<EditContext> | - | Called on valid submit |
| OnInvalidSubmit | EventCallback<EditContext> | - | Called on invalid submit |
| OnSubmit | EventCallback<EditContext> | - | Called on any submit |
| Size | Size? | null | Form size |
| State | State? | null | Success/Error/Warning state |
| Classes | FormClass[] | null | Additional CSS classes |
| FormValidationPosition | ValidationPosition | Hidden | Form-level validation position |
| FieldValidationPosition | ValidationPosition | Hidden | Field-level validation position |
| ShowLoadingOnSubmit | bool | true | Show loading during submit |

### FormClass Options
`Loading`, `Equal_Width`, `Inverted`

### ValidationPosition Options
`Hidden`, `Top`, `Bottom`

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| Submit() | Task | Programmatically submit the form |

### Examples

**Basic form:**
```razor
<SemForm Model="person" OnValidSubmit="HandleSubmit">
  <SemFormField For="@(() => person.Name)">
    <SemInput @bind-Value="person.Name"></SemInput>
  </SemFormField>
  <SemFormField For="@(() => person.Email)">
    <SemInput @bind-Value="person.Email"></SemInput>
  </SemFormField>
  <SemButton IsSubmitButton="true" Color="ButtonColor.Positive">Save</SemButton>
</SemForm>
```

**With validation messages:**
```razor
<SemForm Model="person" OnValidSubmit="Save"
         FormValidationPosition="ValidationPosition.Top"
         FieldValidationPosition="ValidationPosition.Bottom">
  <SemFormField For="@(() => person.Email)">
    <SemInput @bind-Value="person.Email"></SemInput>
  </SemFormField>
  <SemButton IsSubmitButton="true">Submit</SemButton>
</SemForm>
```

**Equal width fields:**
```razor
<SemForm Model="item" Classes="@(new[] { FormClass.Equal_Width })">
  ...
</SemForm>
```

---

## SemFormField<TValue>

**Inherits:** `SemControlBase`

A form field with label and validation support.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Field input content |
| For | Expression<Func<TValue>> | null | Property expression |
| Label | string | null | Custom label (default: from Display attribute) |
| LabelVisible | bool | true | Show label |
| Editable | bool | true | Field is editable (hides required if false) |
| Required | bool | false | Show required indicator |
| Wide | GridUnit? | null | Field width (1-16) |
| Classes | FieldClass[] | null | Additional CSS classes |

### FieldClass Options
`Inline`

### Examples

**Basic field:**
```razor
<SemFormField For="@(() => model.Name)">
  <SemInput @bind-Value="model.Name"></SemInput>
</SemFormField>
```

**Custom label:**
```razor
<SemFormField For="@(() => model.Email)" Label="Email Address">
  <SemInput @bind-Value="model.Email"></SemInput>
</SemFormField>
```

**Read-only display:**
```razor
<SemFormField For="@(() => model.CreatedDate)" Editable="false">
  @model.CreatedDate.ToShortDateString()
</SemFormField>
```

**Custom width:**
```razor
<SemFormField For="@(() => model.Phone)" Wide="GridUnit.Six">
  <SemInput @bind-Value="model.Phone"></SemInput>
</SemFormField>
```

**Inline field:**
```razor
<SemFormField For="@(() => model.Name)" Classes="@(new[] { FieldClass.Inline })">
  <SemInput @bind-Value="model.Name"></SemInput>
</SemFormField>
```

**Hidden label:**
```razor
<SemFormField For="@(() => model.Search)" LabelVisible="false">
  <SemInput @bind-Value="model.Search" Placeholder="Search..."></SemInput>
</SemFormField>
```

---

## SemFormFields

**Inherits:** `SemControlBase`

Groups multiple form fields on one row.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Field content |
| Fields | GridUnit? | null | Number of equal-width fields |
| Classes | FieldsClass[] | null | Additional CSS classes |

### FieldsClass Options
`Equal_Width`, `Inline`

### Examples

**Two fields per row:**
```razor
<SemFormFields Fields="GridUnit.Two">
  <SemFormField For="@(() => model.FirstName)">
    <SemInput @bind-Value="model.FirstName"></SemInput>
  </SemFormField>
  <SemFormField For="@(() => model.LastName)">
    <SemInput @bind-Value="model.LastName"></SemInput>
  </SemFormField>
</SemFormFields>
```

**Equal width:**
```razor
<SemFormFields Classes="@(new[] { FieldsClass.Equal_Width })">
  <SemFormField For="@(() => model.City)">
    <SemInput @bind-Value="model.City"></SemInput>
  </SemFormField>
  <SemFormField For="@(() => model.State)">
    <SemInput @bind-Value="model.State"></SemInput>
  </SemFormField>
  <SemFormField For="@(() => model.Zip)">
    <SemInput @bind-Value="model.Zip"></SemInput>
  </SemFormField>
</SemFormFields>
```

**Custom widths:**
```razor
<SemFormFields>
  <SemFormField Wide="GridUnit.Four" For="@(() => model.Code)">
    <SemInput @bind-Value="model.Code"></SemInput>
  </SemFormField>
  <SemFormField Wide="GridUnit.Twelve" For="@(() => model.Description)">
    <SemInput @bind-Value="model.Description"></SemInput>
  </SemFormField>
</SemFormFields>
```

---

## SemValidationMessage<TValue>

Displays validation errors for a specific field.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| For | Expression<Func<TValue>> | - | Property expression |

### Example
```razor
<SemInput @bind-Value="model.Email"></SemInput>
<SemValidationMessage For="@(() => model.Email)"></SemValidationMessage>
```

---

## SemValidationSummary

Displays all validation errors as a list in a negative message box.

### Example
```razor
<SemForm Model="model" OnValidSubmit="Save">
  <SemValidationSummary></SemValidationSummary>
  ...
</SemForm>
```

---

## Complete Form Example

```razor
@using System.ComponentModel.DataAnnotations

<SemForm Model="person" OnValidSubmit="SavePerson"
         FieldValidationPosition="ValidationPosition.Bottom">
  <SemFormFields Fields="GridUnit.Two">
    <SemFormField For="@(() => person.FirstName)">
      <SemInput @bind-Value="person.FirstName"></SemInput>
    </SemFormField>
    <SemFormField For="@(() => person.LastName)">
      <SemInput @bind-Value="person.LastName"></SemInput>
    </SemFormField>
  </SemFormFields>

  <SemFormField For="@(() => person.Email)">
    <SemInput @bind-Value="person.Email" Icon="Icon.Envelope"></SemInput>
  </SemFormField>

  <SemFormField For="@(() => person.Phone)" Wide="GridUnit.Eight">
    <SemInput @bind-Value="person.Phone" Icon="Icon.Phone"></SemInput>
  </SemFormField>

  <SemFormField For="@(() => person.Notes)">
    <SemInput @bind-Value="person.Notes" Rows="4"></SemInput>
  </SemFormField>

  <SemButton IsSubmitButton="true" Color="ButtonColor.Positive" Icon="Icon.Save">
    Save
  </SemButton>
</SemForm>

@code {
  Person person = new();

  async Task SavePerson(EditContext context) {
    await personService.SaveAsync(person);
  }

  class Person {
    [Required, Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required, Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    public string Notes { get; set; }
  }
}
```
