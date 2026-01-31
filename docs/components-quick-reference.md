# SemanticBlazor Quick Reference

Blazor component library implementing Semantic UI (Fomantic UI). All components use `Sem*` prefix.

## Component Index

| Category | Components | Details |
|----------|-----------|---------|
| Layout | SemGrid, SemGridRow, SemGridColumn, SemSegment, SemDivider | [layout.md](components/layout.md) |
| Typography | SemHeader, SemHeader1-6, SemLabel, SemIcon | [typography.md](components/typography.md) |
| Navigation | SemMenu, SemMenuItem, SemTabs, SemTab, SemDropdownMenu | [navigation.md](components/navigation.md) |
| Buttons | SemButton, SemButtonSwitch, SemDataButtonSwitch | [buttons.md](components/buttons.md) |
| Forms | SemForm, SemFormField, SemFormFields, SemValidationMessage, SemValidationSummary | [forms.md](components/forms.md) |
| Inputs | SemInput, SemActionInput, SemCheckbox, SemDateInput, SemTimeInput, SemDateTimeInput | [inputs.md](components/inputs.md) |
| Selection | SemDropdownSelection, SemDataDropdownSelection, SemDropdownMultiSelection, SemDataDropdownMultiSelection, SemCheckboxList, SemDataCheckboxList, SemRadioButtonList, SemDataRadioButtonList | [selection.md](components/selection.md) |
| Data Display | SemDataTable, SemDataTableColumn, SemDataList, SemCards, SemPagination | [data-display.md](components/data-display.md) |
| Modals & Messaging | SemModal, SemModalConfirmation, SemMessage, NotificationPanel | [modals-messaging.md](components/modals-messaging.md) |

**Enums Reference:** [enums.md](enums.md)

---

## Common Base Parameters

All components inherit from `SemControlBase`:

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Id | string | GUID | Unique identifier |
| Class | string | null | Additional CSS classes |
| Style | string | null | Inline styles |
| Visible | bool | true | Component visibility |
| Enabled | bool | true | Component enabled state |
| Attributes | Dictionary | null | Additional HTML attributes |

---

## Quick Examples by Category

### Layout
```razor
<SemGrid Columns="GridUnit.Three">
  <SemGridColumn>Col 1</SemGridColumn>
  <SemGridColumn>Col 2</SemGridColumn>
  <SemGridColumn>Col 3</SemGridColumn>
</SemGrid>

<SemSegment Color="Color.Blue">Content in segment</SemSegment>
```

### Typography
```razor
<SemHeader1 Icon="Icon.Settings">Page Title</SemHeader1>
<SemLabel Color="Color.Red">New</SemLabel>
<SemIcon Icon="Icon.User" Size="Size.Large"></SemIcon>
```

### Navigation
```razor
<SemMenu>
  <SemMenuItem Href="/">Home</SemMenuItem>
  <SemMenuItem Href="/about">About</SemMenuItem>
</SemMenu>

<SemTabs>
  <Tabs>
    <SemTab Name="tab1" Text="First">Content 1</SemTab>
    <SemTab Name="tab2" Text="Second">Content 2</SemTab>
  </Tabs>
</SemTabs>
```

### Buttons
```razor
<SemButton OnClick="Save" Color="ButtonColor.Positive" Icon="Icon.Save">Save</SemButton>
<SemButton OnClick="Delete" Color="ButtonColor.Negative" NeedsConfirmation="true"
           ConfirmationMessage="Are you sure?">Delete</SemButton>
```

### Forms
```razor
<SemForm Model="person" OnValidSubmit="HandleSubmit">
  <SemFormField For="@(() => person.Name)">
    <SemInput @bind-Value="person.Name"></SemInput>
  </SemFormField>
  <SemFormField For="@(() => person.Email)">
    <SemInput @bind-Value="person.Email"></SemInput>
  </SemFormField>
  <SemButton IsSubmitButton="true" Color="ButtonColor.Positive">Submit</SemButton>
</SemForm>
```

### Inputs
```razor
<SemInput @bind-Value="name" Placeholder="Enter name"></SemInput>
<SemInput @bind-Value="amount" NumberMin="0" NumberStep="0.01"></SemInput>
<SemInput @bind-Value="password" IsPassword="true"></SemInput>
<SemInput @bind-Value="description" Rows="5"></SemInput>
<SemCheckbox @bind-Value="isActive" Label="Active"></SemCheckbox>
<SemDateInput @bind-Value="birthDate" Clearable="true"></SemDateInput>
```

### Selection (Static Items)
```razor
<SemDropdownSelection @bind-Value="selectedId">
  <ListItems>
    <SemSelectListItem Value="1" Text="Option 1"></SemSelectListItem>
    <SemSelectListItem Value="2" Text="Option 2"></SemSelectListItem>
  </ListItems>
</SemDropdownSelection>
```

### Selection (Dynamic Data)
```razor
<SemDataDropdownSelection TItem="Country" TValue="int"
                          Items="countries"
                          ItemKey="c => c.Id"
                          ItemText="c => c.Name"
                          ValueSelector="c => c.Id"
                          @bind-Value="selectedCountryId"
                          Search="true">
</SemDataDropdownSelection>
```

### Data Table
```razor
<SemDataTable Items="users" AllowPaging="true" DefaultPageSize="10">
  <Columns>
    <SemDataTableColumn TItem="User" HeaderText="Name" ItemText="u => u.Name"></SemDataTableColumn>
    <SemDataTableColumn TItem="User" HeaderText="Email" ItemText="u => u.Email"></SemDataTableColumn>
    <SemDataTableColumn TItem="User" HeaderText="Actions">
      <ItemTemplate>
        <SemButton Size="Size.Mini" OnClick="() => Edit(context)">Edit</SemButton>
      </ItemTemplate>
    </SemDataTableColumn>
  </Columns>
</SemDataTable>
```

### Modal
```razor
<SemButton OnClick="() => modal.Show()">Open</SemButton>

<SemModal @ref="modal" Size="ModalSize.Small">
  <Header>Title</Header>
  <Content>Modal content</Content>
  <Actions>
    <SemButton OnClick="() => modal.Hide()">Cancel</SemButton>
    <SemButton Color="ButtonColor.Positive" OnClick="Save">Save</SemButton>
  </Actions>
</SemModal>
```

### Message
```razor
<SemMessage Color="MessageColor.Positive" Icon="Icon.Check_Circle">
  Operation successful!
</SemMessage>
```

---

## Data-Bound vs Static Components

**Static (ListItems):** Use `SemSelectListItem` children
- `SemDropdownSelection`, `SemDropdownMultiSelection`
- `SemCheckboxList`, `SemRadioButtonList`, `SemButtonSwitch`

**Data-bound (Items + selectors):** Use `Items`, `ItemKey`, `ItemText`, `ValueSelector`
- `SemDataDropdownSelection`, `SemDataDropdownMultiSelection`
- `SemDataCheckboxList`, `SemDataRadioButtonList`, `SemDataButtonSwitch`

---

## Common Enums

**Colors:** `Color.Red`, `Color.Blue`, `Color.Green`, etc.
**Button Colors:** `ButtonColor.Positive`, `ButtonColor.Negative`, + all Color values
**Sizes:** `Size.Mini`, `Size.Small`, `Size.Medium`, `Size.Large`, `Size.Huge`
**Grid Units:** `GridUnit.One` through `GridUnit.Sixteen`

See [enums.md](enums.md) for complete reference.

---

## Key Patterns

### Two-way Binding
```razor
<SemInput @bind-Value="model.Name"></SemInput>
```

### Form Validation
```razor
<SemFormField For="@(() => model.Email)">
  <SemInput @bind-Value="model.Email"></SemInput>
</SemFormField>
```

### Async Data Loading
```razor
<SemDataTable TItem="Order" DataMethod="LoadOrders" CountMethod="CountOrders" AllowPaging="true">
```

### CSS Class Modifiers
```razor
<SemButton Classes="@(new[] { ButtonClass.Basic, ButtonClass.Inverted })">
<SemSegment Classes="@(new[] { SegmentClass.Raised, SegmentClass.Padded })">
```
