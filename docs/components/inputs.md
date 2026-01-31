# Input Components

## SemInput<TValue>

**Inherits:** `SemInputControlBase<TValue>`

A text input supporting various types (text, number, password, textarea).

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Bound value |
| ValueChanged | EventCallback<TValue> | - | Value change callback |
| Icon | Icon? | null | Input icon |
| IconPosition | IconPosition? | Left | Icon position |
| Clearable | bool | false | Show clear button |
| Placeholder | string | null | Placeholder text |
| IsPassword | bool | false | Password input |
| NumberStep | decimal? | 1 | Step for number input |
| NumberMin | decimal? | null | Minimum for number input |
| NumberMax | decimal? | null | Maximum for number input |
| InputClass | string | null | Inner input CSS class |
| InputStyle | string | null | Inner input inline styles |
| Size | InputSize? | null | Input size |
| Classes | InputClass[] | null | Additional CSS classes |
| Rows | int | 1 | Number of rows (>1 = textarea) |
| EnterPressed | EventCallback | - | Callback when Enter is pressed |

### InputClass Options
`Transparent`, `Inverted`, `Fluid`, `Labeled`

### InputSize Options
`Mini`, `Small`, `Large`, `Big`, `Huge`, `Massive`

### Type Inference
- `string` -> text input
- `string` + `IsPassword="true"` -> password input
- `string` + `Rows > 1` -> textarea
- `int`, `decimal`, `double` -> number input
- `DateTime` -> date input

### Examples

**Text input:**
```razor
<SemInput @bind-Value="name"></SemInput>
<SemInput @bind-Value="name" Placeholder="Enter name"></SemInput>
```

**With icon:**
```razor
<SemInput @bind-Value="search" Icon="Icon.Search" Placeholder="Search..."></SemInput>
<SemInput @bind-Value="email" Icon="Icon.Envelope" IconPosition="IconPosition.Left"></SemInput>
```

**Clearable:**
```razor
<SemInput @bind-Value="filter" Clearable="true"></SemInput>
```

**Number input:**
```razor
<SemInput @bind-Value="quantity"></SemInput>
<SemInput @bind-Value="price" NumberStep="0.01" NumberMin="0"></SemInput>
<SemInput @bind-Value="percentage" NumberMin="0" NumberMax="100"></SemInput>
```

**Password:**
```razor
<SemInput @bind-Value="password" IsPassword="true"></SemInput>
```

**Textarea:**
```razor
<SemInput @bind-Value="description" Rows="5"></SemInput>
```

**Sizes:**
```razor
<SemInput @bind-Value="text" Size="InputSize.Mini"></SemInput>
<SemInput @bind-Value="text" Size="InputSize.Large"></SemInput>
```

**Fluid (full width):**
```razor
<SemInput @bind-Value="text" Classes="@(new[] { InputClass.Fluid })"></SemInput>
```

**Enter key handler:**
```razor
<SemInput @bind-Value="searchTerm" EnterPressed="PerformSearch"></SemInput>
```

---

## SemActionInput<TValue>

**Inherits:** `SemInputControlBase<TValue>`

An input with an attached action button.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Bound value |
| OnClick | EventCallback<MouseEventArgs> | - | Button click handler |
| OnClickLoading | bool | false | Show loading on click |
| ActionText | string | null | Button text |
| Clearable | bool | false | Show clear button |
| InputClass | string | null | Input CSS class |
| InputStyle | string | null | Input inline styles |
| InputIcon | Icon? | null | Input icon |
| InputIconPosition | IconPosition? | null | Input icon position |
| Size | InputSize? | null | Input size |
| ButtonClass | string | null | Button CSS class |
| ButtonIcon | Icon? | null | Button icon |
| ButtonIconPosition | IconPosition? | null | Button icon position |
| ButtonIconLabeled | bool | true | Use labeled icon |
| ButtonColor | ButtonColor? | null | Button color |
| NeedsConfirmation | bool | false | Show confirmation |
| ConfirmationHeader | string | null | Confirmation header |
| ConfirmationMessage | string | null | Confirmation message |

### Examples

```razor
<SemActionInput @bind-Value="searchTerm"
                ActionText="Search"
                OnClick="PerformSearch"
                ButtonIcon="Icon.Search"
                ButtonColor="ButtonColor.Blue">
</SemActionInput>

<SemActionInput @bind-Value="code"
                ActionText="Apply"
                OnClick="ApplyCode"
                OnClickLoading="true"
                Clearable="true">
</SemActionInput>
```

---

## SemCheckbox

**Inherits:** `SemInputControlBase<bool>`

A checkbox input.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | bool | - | Bound value |
| ChildContent | RenderFragment | null | Custom label content |
| Label | string | null | Label text |
| Type | CheckboxType | Checkbox | Checkbox/Slider/Toggle |

### CheckboxType Options
`Checkbox`, `Slider`, `Toggle`

### Examples

```razor
<SemCheckbox @bind-Value="isActive" Label="Active"></SemCheckbox>

<SemCheckbox @bind-Value="isEnabled" Type="CheckboxType.Toggle">
  Enable feature
</SemCheckbox>

<SemCheckbox @bind-Value="setting" Type="CheckboxType.Slider">
  Dark mode
</SemCheckbox>

<SemCheckbox @bind-Value="agreed">
  I agree to the <a href="/terms">terms and conditions</a>
</SemCheckbox>
```

---

## SemDateInput<TValue>

**Inherits:** `SemDateTimeInputBase<TValue>`

A date picker input.

**Supported Types:** `DateTime`, `DateTime?`

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Bound value |
| Icon | Icon? | null | Input icon |
| IconPosition | IconPosition? | Left | Icon position |
| Clearable | bool | false | Allow clearing (nullable only) |
| Placeholder | string | null | Placeholder text |
| Culture | string | null | Date format culture |
| Size | InputSize? | null | Input size |
| StartDateInputId | string | null | ID of start date (for range) |
| EndDateInputId | string | null | ID of end date (for range) |

### Examples

```razor
<SemDateInput @bind-Value="birthDate"></SemDateInput>

<SemDateInput @bind-Value="appointmentDate"
              Icon="Icon.Calendar"
              Clearable="true"
              Placeholder="Select date">
</SemDateInput>
```

**Date range:**
```razor
<SemDateInput @bind-Value="startDate" Id="start" EndDateInputId="end"
              Placeholder="Start date"></SemDateInput>
<SemDateInput @bind-Value="endDate" Id="end" StartDateInputId="start"
              Placeholder="End date"></SemDateInput>
```

---

## SemTimeInput<TValue>

**Inherits:** `SemDateTimeInputBase<TValue>`

A time picker input.

**Supported Types:** `TimeSpan`, `TimeSpan?`

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Bound value |
| Icon | Icon? | null | Input icon |
| IconPosition | IconPosition? | Left | Icon position |
| Placeholder | string | null | Placeholder text |
| Culture | string | null | Time format culture |
| Size | InputSize? | null | Input size |
| MinutesEnabled | bool | true | Allow minute selection |

### Examples

```razor
<SemTimeInput @bind-Value="startTime"></SemTimeInput>

<SemTimeInput @bind-Value="meetingTime"
              Icon="Icon.Clock"
              Placeholder="Select time">
</SemTimeInput>

<SemTimeInput @bind-Value="hour" MinutesEnabled="false"></SemTimeInput>
```

---

## SemDateTimeInput<TValue>

**Inherits:** `SemInputControlBase<TValue>`

A combined date and time picker.

**Supported Types:** `DateTime`, `DateTime?`

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Value | TValue | - | Bound value |
| DateIcon | Icon? | null | Date input icon |
| TimeIcon | Icon? | null | Time input icon |
| IconPosition | IconPosition? | Left | Icon position |
| Clearable | bool | false | Allow clearing date |
| Placeholder | string | null | Placeholder text |
| Culture | string | null | Format culture |
| Size | InputSize? | null | Input size |
| MinutesEnabled | bool | true | Allow minute selection |

### Examples

```razor
<SemDateTimeInput @bind-Value="appointmentDateTime"></SemDateTimeInput>

<SemDateTimeInput @bind-Value="eventDateTime"
                  DateIcon="Icon.Calendar"
                  TimeIcon="Icon.Clock"
                  Clearable="true">
</SemDateTimeInput>
```

---

## Common Input Patterns

### Disabled input
```razor
<SemInput @bind-Value="name" Enabled="false"></SemInput>
```

### Hidden input (but in form)
```razor
<SemInput @bind-Value="id" Visible="false"></SemInput>
```

### With validation in form
```razor
<SemFormField For="@(() => model.Email)">
  <SemInput @bind-Value="model.Email" Icon="Icon.Envelope"></SemInput>
</SemFormField>
```
