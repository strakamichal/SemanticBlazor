# Navigation Components

## SemMenu

**Inherits:** `SemControlBase`

A navigation menu container.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Menu items |
| Color | Color? | null | Menu color |
| Size | Size? | null | Menu size |
| Classes | MenuClass[] | null | Additional CSS classes |

### MenuClass Options
`Secondary`, `Compact`, `Pointing`, `Text`, `Vertical`, `Fluid`, `Pagination`, `Tabular`, `Fixed`, `Stackable`, `Inverted`, `Top_Attached`, `Bottom_Attached`, `Fitted`, `Borderless`

### Examples

```razor
<SemMenu>
  <SemMenuItem Href="/">Home</SemMenuItem>
  <SemMenuItem Href="/about">About</SemMenuItem>
  <SemMenuItem Href="/contact">Contact</SemMenuItem>
</SemMenu>

<SemMenu Classes="@(new[] { MenuClass.Vertical })">
  <SemMenuItem>Dashboard</SemMenuItem>
  <SemMenuItem>Settings</SemMenuItem>
</SemMenu>

<SemMenu Classes="@(new[] { MenuClass.Secondary, MenuClass.Pointing })">
  <SemMenuItem>Tab 1</SemMenuItem>
  <SemMenuItem>Tab 2</SemMenuItem>
</SemMenu>

<SemMenu Classes="@(new[] { MenuClass.Inverted })" Color="Color.Blue">
  <SemMenuItem Href="/">Home</SemMenuItem>
</SemMenu>
```

---

## SemMenuItem

**Inherits:** `SemControlBase`

An item within a menu.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Item content |
| Header | RenderFragment | null | Optional header content |
| Href | string | null | Navigation URL (uses NavLink) |
| Dropdown | bool | false | Enable dropdown behavior |
| DropdownOn | DropdownOn | Click | Dropdown trigger (Click/Hover) |
| DropdownAction | DropdownAction | Hide | Dropdown action on select |
| Color | Color? | null | Item color |
| OnClick | EventCallback<MouseEventArgs> | - | Click event |
| NeedsConfirmation | bool | false | Show confirmation before action |
| ConfirmationHeader | string | null | Confirmation dialog header |
| ConfirmationMessage | string | null | Confirmation dialog message |
| CancelButtonText | string | "No" | Cancel button text |
| ConfirmButtonText | string | "Yes" | Confirm button text |

### Examples

```razor
<SemMenuItem Href="/dashboard">Dashboard</SemMenuItem>

<SemMenuItem OnClick="HandleLogout">Logout</SemMenuItem>

<SemMenuItem Dropdown="true">
  More
  <SemMenu>
    <SemMenuItem Href="/settings">Settings</SemMenuItem>
    <SemMenuItem Href="/profile">Profile</SemMenuItem>
  </SemMenu>
</SemMenuItem>

<SemMenuItem OnClick="Delete" NeedsConfirmation="true"
             ConfirmationHeader="Confirm"
             ConfirmationMessage="Are you sure?">
  Delete
</SemMenuItem>
```

---

## SemTabs

**Inherits:** `SemControlBase`

A tabbed interface container.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Tabs | RenderFragment | - | Tab definitions |
| MenuPosition | TabMenuPosition | Top | Tab menu position (Top/Bottom) |
| Color | Color? | null | Tab menu color |
| Size | Size? | null | Tab menu size |
| Classes | MenuClass[] | null | Additional CSS classes |
| ActiveTabChanged | EventCallback<SemTab> | - | Callback when active tab changes |

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| SetActiveTab(string) | Task | Activate tab by name |
| GetActiveTab() | SemTab | Get currently active tab |

### Example

```razor
<SemTabs @ref="tabs" ActiveTabChanged="OnTabChanged">
  <Tabs>
    <SemTab Name="general" Text="General">
      General settings content
    </SemTab>
    <SemTab Name="advanced" Text="Advanced">
      Advanced settings content
    </SemTab>
    <SemTab Name="security" Text="Security" Enabled="hasPermission">
      Security settings content
    </SemTab>
  </Tabs>
</SemTabs>

@code {
    SemTabs tabs;

    async Task SwitchToAdvanced() {
        await tabs.SetActiveTab("advanced");
    }
}
```

---

## SemTab

**Inherits:** `SemControlBase`

A single tab within SemTabs.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Tab content |
| Name | string | null | Tab identifier |
| Text | string | null | Tab label text |
| Active | bool | false | Whether tab is active |
| MenuContent | RenderFragment | null | Custom menu item content |
| MenuItemClass | string | null | Additional menu item classes |
| MenuItemStyle | string | null | Menu item inline styles |

### Examples

```razor
<SemTab Name="settings" Text="Settings">
  Settings content here
</SemTab>

<SemTab Name="notifications">
  <MenuContent>
    <SemIcon Icon="Icon.Bell"></SemIcon> Notifications
    <SemLabel Color="Color.Red" Classes="@(new[] { LabelClass.Floating })">5</SemLabel>
  </MenuContent>
  <ChildContent>
    Notification list...
  </ChildContent>
</SemTab>
```

---

## SemDropdownMenu

**Inherits:** `SemControlBase`

A dropdown menu (typically used inside SemMenu).

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Dropdown content |
| DropdownOn | DropdownOn | Click | Trigger behavior (Click/Hover) |
| DropdownAction | DropdownAction | Hide | Action on select |

### Example

```razor
<SemMenu>
  <SemMenuItem Href="/">Home</SemMenuItem>
  <SemDropdownMenu>
    <span class="text">More</span>
    <i class="dropdown icon"></i>
    <div class="menu">
      <SemMenuItem Href="/settings">Settings</SemMenuItem>
      <SemMenuItem Href="/help">Help</SemMenuItem>
    </div>
  </SemDropdownMenu>
</SemMenu>
```
