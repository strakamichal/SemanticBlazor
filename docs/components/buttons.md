# Button Components

## SemButton

**Inherits:** `SemControlBase`

A button with various styles and behaviors.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Button text/content |
| Href | string | null | Navigation URL (renders as anchor) |
| OnClick | EventCallback<MouseEventArgs> | - | Click handler |
| IsSubmitButton | bool | false | Render as form submit button |
| IsButton | bool | true | Add "button" class |
| OnClickLoading | bool | false | Show loading state on click |
| Tooltip | string | null | Button tooltip |
| Icon | Icon? | null | Button icon |
| IconPosition | IconPosition? | null | Left or Right |
| IconLabeled | bool | true | Use labeled icon styling |
| Color | ButtonColor? | null | Button color |
| Emphasis | Emphasis? | null | Primary/Secondary/Tertiary |
| Size | Size? | null | Button size |
| Classes | ButtonClass[] | null | Additional CSS classes |
| NeedsConfirmation | bool | false | Show confirmation dialog |
| ConfirmationHeader | string | null | Confirmation header |
| ConfirmationMessage | string | null | Confirmation message |
| CancelButtonText | string | "No" | Cancel button text |
| ConfirmButtonText | string | "Yes" | Confirm button text |

### ButtonClass Options
`Animated`, `Labeled`, `Icon`, `Basic`, `Inverted`, `Right_Floated`, `Left_Floated`, `Compact`, `Toggle`, `Fluid`, `Circular`, `Top_Attached`, `Bottom_Attached`, `Left_Attached`, `Right_Attached`

### ButtonColor Options
`Positive`, `Negative`, `Red`, `Orange`, `Yellow`, `Olive`, `Green`, `Teal`, `Blue`, `Violet`, `Purple`, `Pink`, `Brown`, `Grey`, `Black`

### Examples

**Basic buttons:**
```razor
<SemButton OnClick="HandleClick">Click Me</SemButton>
<SemButton Color="ButtonColor.Positive">Save</SemButton>
<SemButton Color="ButtonColor.Negative">Delete</SemButton>
<SemButton Href="/page">Navigate</SemButton>
```

**With icon:**
```razor
<SemButton Icon="Icon.Save" Color="ButtonColor.Green">Save</SemButton>
<SemButton Icon="Icon.Download" IconPosition="IconPosition.Right">Download</SemButton>
```

**Icon-only button:**
```razor
<SemButton Icon="Icon.Edit" Classes="@(new[] { ButtonClass.Icon })"></SemButton>
<SemButton Icon="Icon.Trash" Classes="@(new[] { ButtonClass.Icon })" Color="ButtonColor.Red"></SemButton>
```

**Loading button:**
```razor
<SemButton OnClick="LongOperation" OnClickLoading="true">Process</SemButton>
```

**Submit button:**
```razor
<SemButton IsSubmitButton="true" Color="ButtonColor.Positive">Submit</SemButton>
```

**With confirmation:**
```razor
<SemButton OnClick="Delete" NeedsConfirmation="true"
           ConfirmationHeader="Delete Item?"
           ConfirmationMessage="This action cannot be undone."
           Color="ButtonColor.Negative">
  Delete
</SemButton>
```

**Basic and inverted:**
```razor
<SemButton Classes="@(new[] { ButtonClass.Basic })">Basic</SemButton>
<SemButton Classes="@(new[] { ButtonClass.Basic, ButtonClass.Inverted })" Color="ButtonColor.Blue">
  Inverted Basic
</SemButton>
```

**Sizes:**
```razor
<SemButton Size="Size.Mini">Mini</SemButton>
<SemButton Size="Size.Small">Small</SemButton>
<SemButton Size="Size.Large">Large</SemButton>
<SemButton Size="Size.Huge">Huge</SemButton>
```

---

## SemButtonSwitch<TValue>

**Inherits:** `SemButtonSwitchBase<ListItem, TValue>`

A button group for single selection from static options.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Selected value (two-way binding) |
| ListItems | RenderFragment | - | Static list items |
| Color | ButtonColor? | null | Button color |
| Size | Size? | null | Button size |
| Classes | ButtonClass[] | null | Button classes |

### Example

```razor
<SemButtonSwitch @bind-Value="selectedValue" Color="ButtonColor.Blue">
  <ListItems>
    <SemSelectListItem Value="day" Text="Day"></SemSelectListItem>
    <SemSelectListItem Value="week" Text="Week"></SemSelectListItem>
    <SemSelectListItem Value="month" Text="Month"></SemSelectListItem>
  </ListItems>
</SemButtonSwitch>

@code {
    string selectedValue = "day";
}
```

---

## SemDataButtonSwitch<TItem, TValue>

**Inherits:** `SemButtonSwitchBase<TItem, TValue>`

A button group for single selection from dynamic data.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Selected value (two-way binding) |
| Items | IEnumerable<TItem> | empty | Items collection |
| ItemKey | Func<TItem, object> | null | Key selector |
| ItemText | Func<TItem, string> | null | Text selector |
| ValueSelector | Func<TItem, TValue> | null | Value selector |
| DataMethod | Func<Task<IEnumerable<TItem>>> | null | Async data method |
| ItemTemplate | RenderFragment<object> | null | Custom item template |
| Color | ButtonColor? | null | Button color |
| Size | Size? | null | Button size |
| Classes | ButtonClass[] | null | Button classes |

### Example

```razor
<SemDataButtonSwitch TItem="Category" TValue="int"
                     Items="categories"
                     ItemKey="c => c.Id"
                     ItemText="c => c.Name"
                     ValueSelector="c => c.Id"
                     @bind-Value="selectedCategoryId"
                     Color="ButtonColor.Teal">
</SemDataButtonSwitch>

@code {
    List<Category> categories = new() {
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Clothing" },
        new Category { Id = 3, Name = "Books" }
    };
    int selectedCategoryId = 1;
}
```

**With DataMethod:**
```razor
<SemDataButtonSwitch TItem="Status" TValue="int"
                     DataMethod="LoadStatuses"
                     ItemKey="s => s.Id"
                     ItemText="s => s.Name"
                     ValueSelector="s => s.Id"
                     @bind-Value="selectedStatusId">
</SemDataButtonSwitch>

@code {
    async Task<IEnumerable<Status>> LoadStatuses() {
        return await statusService.GetAllAsync();
    }
}
```
