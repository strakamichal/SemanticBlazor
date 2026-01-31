# Typography Components

## SemHeader

**Inherits:** `SemControlBase`

A content header with optional icon.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Header text content |
| Size | HeaderSize? | null | Tiny, Small, Medium, Large, Huge |
| Color | HeaderColor? | null | Header color |
| Icon | Icon? | null | Optional icon |
| IconClasses | IconClass[] | null | Icon CSS classes |
| IconPosition | IconPosition? | null | Left or Right |
| SubHeader | bool | false | Render as subheader |
| Classes | HeaderClass[] | null | Additional CSS classes |

### HeaderClass Options
`Dividing`, `Block`, `Top_Attached`, `Attached`, `Bottom_Attached`, `Left`, `Right`, `Right_Floated`, `Left_Floated`, `Justified`, `Inverted`, `Center`, `Sub`, `Right_Aligned`, `Left_Aligned`, `Center_Aligned`

### Examples

```razor
<SemHeader Size="HeaderSize.Large">Page Title</SemHeader>

<SemHeader Icon="Icon.Settings" Color="HeaderColor.Blue">Settings</SemHeader>

<SemHeader Classes="@(new[] { HeaderClass.Dividing })">Section Title</SemHeader>

<SemHeader SubHeader="true">Subheader text</SemHeader>
```

---

## SemHeader1 - SemHeader6

**Inherits:** `SemHeader`

Semantic HTML headers (h1-h6) with all SemHeader functionality.

### Examples

```razor
<SemHeader1>Main Title (h1)</SemHeader1>
<SemHeader2 Icon="Icon.Book">Chapter (h2)</SemHeader2>
<SemHeader3 Color="HeaderColor.Grey">Section (h3)</SemHeader3>
```

---

## SemLabel

**Inherits:** `SemControlBase`

A label for highlighting content.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Label content |
| Color | Color? | null | Label color |
| Size | Size? | null | Label size |
| Classes | LabelClass[] | null | Additional CSS classes |
| OnClick | EventCallback<MouseEventArgs> | - | Click event (renders as anchor) |

### LabelClass Options
`Basic`, `Empty`, `Horizontal`, `Floating`, `Image`, `Right`, `Left`, `Top_Attached`, `Bottom_Attached`, `Circular`, `Pointing`, `Pointing_Below`, `Corner`, `Tag`, `Ribbon`

### Examples

```razor
<SemLabel Color="Color.Blue">New</SemLabel>

<SemLabel Color="Color.Red" Size="Size.Large">Important</SemLabel>

<SemLabel Classes="@(new[] { LabelClass.Tag })" Color="Color.Teal">
  Sale
</SemLabel>

<SemLabel Classes="@(new[] { LabelClass.Pointing })">
  Please enter a value above
</SemLabel>

<SemLabel Classes="@(new[] { LabelClass.Circular })" Color="Color.Red">
  5
</SemLabel>
```

---

## SemIcon

**Inherits:** `SemControlBase`

An icon from the Semantic UI icon set (900+ icons).

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Icon | Icon? | null | Icon to display |
| Color | Color? | null | Icon color |
| Size | Size? | null | Icon size |
| Classes | IconClass[] | null | Additional CSS classes |
| OnClick | EventCallback<MouseEventArgs> | - | Click event (adds "link" class) |

### IconClass Options
`Loading`, `Fitted`, `Flipped`, `Rotated`, `Circular`, `Bordered`, `Inverted`

### Common Icons
- **Actions:** `Icon.Edit`, `Icon.Trash`, `Icon.Save`, `Icon.Download`, `Icon.Upload`
- **Navigation:** `Icon.Arrow_Left`, `Icon.Arrow_Right`, `Icon.Chevron_Down`, `Icon.Angle_Right`
- **Status:** `Icon.Check`, `Icon.Times`, `Icon.Exclamation_Triangle`, `Icon.Info_Circle`
- **Objects:** `Icon.User`, `Icon.Home`, `Icon.Cog`, `Icon.Search`, `Icon.Calendar`
- **Loading:** `Icon.Spinner_Loading`, `Icon.Notched_Circle_Loading`

### Examples

```razor
<SemIcon Icon="Icon.User"></SemIcon>

<SemIcon Icon="Icon.Check" Color="Color.Green" Size="Size.Large"></SemIcon>

<SemIcon Icon="Icon.Spinner_Loading"></SemIcon>

<SemIcon Icon="Icon.Edit" OnClick="HandleEdit"></SemIcon>

<SemIcon Icon="Icon.Star" Classes="@(new[] { IconClass.Circular, IconClass.Inverted })" Color="Color.Yellow"></SemIcon>
```
