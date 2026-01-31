# Selection Components

Selection components come in two variants:
- **Static (ListItems):** Use `SemSelectListItem` children for fixed options
- **Data-bound (Items):** Use `Items`, `ItemKey`, `ItemText`, `ValueSelector` for dynamic data

---

## SemDropdownSelection<TValue>

Single selection dropdown with static items.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Selected value (two-way binding) |
| ListItems | RenderFragment | - | Static list items |
| DefaultText | string | "Select..." | Placeholder text |
| Icon | Icon? | null | Dropdown icon |
| Search | bool | false | Enable search |
| Scrolling | bool | false | Enable scrolling |
| Clearable | bool | false | Allow clearing |
| FulltextSearchMode | DropdownFulltextSearch | False | Search mode |

### Example

```razor
<SemDropdownSelection @bind-Value="selectedStatus">
  <ListItems>
    <SemSelectListItem Value="active" Text="Active"></SemSelectListItem>
    <SemSelectListItem Value="inactive" Text="Inactive"></SemSelectListItem>
    <SemSelectListItem Value="pending" Text="Pending"></SemSelectListItem>
  </ListItems>
</SemDropdownSelection>
```

---

## SemDataDropdownSelection<TItem, TValue>

Single selection dropdown with dynamic data.

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
| AllowAdditions | bool | false | Allow adding new items (string only) |
| DefaultText | string | "Select..." | Placeholder text |
| Search | bool | false | Enable search |
| Clearable | bool | false | Allow clearing |

### Examples

**Basic:**
```razor
<SemDataDropdownSelection TItem="Country" TValue="int"
                          Items="countries"
                          ItemKey="c => c.Id"
                          ItemText="c => c.Name"
                          ValueSelector="c => c.Id"
                          @bind-Value="selectedCountryId">
</SemDataDropdownSelection>
```

**With search:**
```razor
<SemDataDropdownSelection TItem="User" TValue="int"
                          Items="users"
                          ItemKey="u => u.Id"
                          ItemText="u => u.FullName"
                          ValueSelector="u => u.Id"
                          @bind-Value="selectedUserId"
                          Search="true"
                          Clearable="true"
                          DefaultText="Select user...">
</SemDataDropdownSelection>
```

**With DataMethod:**
```razor
<SemDataDropdownSelection TItem="Category" TValue="int"
                          DataMethod="LoadCategories"
                          ItemKey="c => c.Id"
                          ItemText="c => c.Name"
                          ValueSelector="c => c.Id"
                          @bind-Value="categoryId">
</SemDataDropdownSelection>

@code {
    async Task<IEnumerable<Category>> LoadCategories() {
        return await categoryService.GetAllAsync();
    }
}
```

**Allow additions (string values):**
```razor
<SemDataDropdownSelection TItem="string" TValue="string"
                          Items="existingTags"
                          ItemKey="t => t"
                          ItemText="t => t"
                          ValueSelector="t => t"
                          @bind-Value="selectedTag"
                          AllowAdditions="true"
                          Search="true">
</SemDataDropdownSelection>
```

---

## SemDropdownMultiSelection<TValue>

Multi selection dropdown with static items. **Value type: `List<TValue>`**

### Example

```razor
<SemDropdownMultiSelection @bind-Value="selectedRoles">
  <ListItems>
    <SemSelectListItem Value="admin" Text="Administrator"></SemSelectListItem>
    <SemSelectListItem Value="editor" Text="Editor"></SemSelectListItem>
    <SemSelectListItem Value="viewer" Text="Viewer"></SemSelectListItem>
  </ListItems>
</SemDropdownMultiSelection>

@code {
    List<string> selectedRoles = new();
}
```

---

## SemDataDropdownMultiSelection<TItem, TValue>

Multi selection dropdown with dynamic data. **Value type: `List<TValue>`**

### Example

```razor
<SemDataDropdownMultiSelection TItem="Tag" TValue="int"
                               Items="tags"
                               ItemKey="t => t.Id"
                               ItemText="t => t.Name"
                               ValueSelector="t => t.Id"
                               @bind-Value="selectedTagIds"
                               Search="true">
</SemDataDropdownMultiSelection>

@code {
    List<int> selectedTagIds = new();
}
```

---

## SemCheckboxList<TValue>

Checkbox list with static items. **Value type: `List<TValue>`**

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | List<TValue> | - | Selected values |
| ListItems | RenderFragment | - | Static list items |
| Type | CheckboxType | Checkbox | Checkbox/Slider/Toggle |

### Example

```razor
<SemCheckboxList @bind-Value="selectedFeatures">
  <ListItems>
    <SemSelectListItem Value="notifications" Text="Email notifications"></SemSelectListItem>
    <SemSelectListItem Value="newsletter" Text="Weekly newsletter"></SemSelectListItem>
    <SemSelectListItem Value="updates" Text="Product updates"></SemSelectListItem>
  </ListItems>
</SemCheckboxList>

@code {
    List<string> selectedFeatures = new();
}
```

---

## SemDataCheckboxList<TItem, TValue>

Checkbox list with dynamic data. **Value type: `List<TValue>`**

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | List<TValue> | - | Selected values |
| Items | IEnumerable<TItem> | empty | Items collection |
| ItemKey | Func<TItem, object> | null | Key selector |
| ItemText | Func<TItem, string> | null | Text selector |
| ValueSelector | Func<TItem, TValue> | null | Value selector |
| DataMethod | Func<Task<IEnumerable<TItem>>> | null | Async data method |
| ItemTemplate | RenderFragment<object> | null | Custom item template |
| Type | CheckboxType | Checkbox | Checkbox style |

### Examples

```razor
<SemDataCheckboxList TItem="Permission" TValue="int"
                     Items="permissions"
                     ItemKey="p => p.Id"
                     ItemText="p => p.Name"
                     ValueSelector="p => p.Id"
                     @bind-Value="selectedPermissionIds">
</SemDataCheckboxList>
```

**As toggles:**
```razor
<SemDataCheckboxList TItem="Feature" TValue="string"
                     Items="features"
                     ItemKey="f => f.Code"
                     ItemText="f => f.Name"
                     ValueSelector="f => f.Code"
                     @bind-Value="enabledFeatures"
                     Type="CheckboxType.Toggle">
</SemDataCheckboxList>
```

---

## SemRadioButtonList<TValue>

Radio button list with static items (single selection).

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Selected value |
| ListItems | RenderFragment | - | Static list items |

### Example

```razor
<SemRadioButtonList @bind-Value="selectedPriority">
  <ListItems>
    <SemSelectListItem Value="low" Text="Low"></SemSelectListItem>
    <SemSelectListItem Value="medium" Text="Medium"></SemSelectListItem>
    <SemSelectListItem Value="high" Text="High"></SemSelectListItem>
  </ListItems>
</SemRadioButtonList>
```

---

## SemDataRadioButtonList<TItem, TValue>

Radio button list with dynamic data (single selection).

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Selected value |
| Items | IEnumerable<TItem> | empty | Items collection |
| ItemKey | Func<TItem, object> | null | Key selector |
| ItemText | Func<TItem, string> | null | Text selector |
| ValueSelector | Func<TItem, TValue> | null | Value selector |
| DataMethod | Func<Task<IEnumerable<TItem>>> | null | Async data method |
| ItemTemplate | RenderFragment<object> | null | Custom item template |

### Example

```razor
<SemDataRadioButtonList TItem="ShippingMethod" TValue="int"
                        Items="shippingMethods"
                        ItemKey="s => s.Id"
                        ItemText="s => $\"{s.Name} - {s.Price:C}\""
                        ValueSelector="s => s.Id"
                        @bind-Value="selectedShippingId">
</SemDataRadioButtonList>
```

---

## SemSelectListItem

A static list item for use with selection components.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | string | null | Item value |
| Text | string | null | Display text |

### Example
```razor
<SemSelectListItem Value="1" Text="First Option"></SemSelectListItem>
```

---

## Summary: Choosing the Right Component

| Need | Single Selection | Multi Selection |
|------|-----------------|-----------------|
| Static options, dropdown | `SemDropdownSelection` | `SemDropdownMultiSelection` |
| Dynamic data, dropdown | `SemDataDropdownSelection` | `SemDataDropdownMultiSelection` |
| Static options, checkboxes | - | `SemCheckboxList` |
| Dynamic data, checkboxes | - | `SemDataCheckboxList` |
| Static options, radio buttons | `SemRadioButtonList` | - |
| Dynamic data, radio buttons | `SemDataRadioButtonList` | - |
| Static options, button group | `SemButtonSwitch` | - |
| Dynamic data, button group | `SemDataButtonSwitch` | - |
