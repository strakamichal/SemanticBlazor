# Layout Components

## SemGrid

**Inherits:** `SemControlBase`

A 16-column responsive grid system.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Grid content (columns/rows) |
| Columns | GridUnit? | null | Number of equal-width columns |
| Classes | GridClass[] | null | Additional CSS classes |

### GridClass Options
`Relaxed`, `Very_Relaxed`, `Celled`, `Internally_Celled`, `Equal_Width`, `Centered`, `Right_Aligned`, `Left_Aligned`, `Center_Aligned`, `Stackable`, `Mobile_Reversed`

### Examples

**Equal columns:**
```razor
<SemGrid Columns="GridUnit.Four">
  <SemGridColumn>Column 1</SemGridColumn>
  <SemGridColumn>Column 2</SemGridColumn>
  <SemGridColumn>Column 3</SemGridColumn>
  <SemGridColumn>Column 4</SemGridColumn>
</SemGrid>
```

**Custom widths:**
```razor
<SemGrid>
  <SemGridColumn Wide="GridUnit.Four">4 wide</SemGridColumn>
  <SemGridColumn Wide="GridUnit.Twelve">12 wide</SemGridColumn>
</SemGrid>
```

**Relaxed centered:**
```razor
<SemGrid Classes="@(new[] { GridClass.Relaxed, GridClass.Centered })">
  <SemGridColumn Wide="GridUnit.Eight">Centered content</SemGridColumn>
</SemGrid>
```

---

## SemGridRow

**Inherits:** `SemControlBase`

A row within a grid for grouping columns.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Row content (columns) |
| Columns | GridUnit? | null | Number of columns in this row |

### Example
```razor
<SemGrid>
  <SemGridRow Columns="GridUnit.Three">
    <SemGridColumn>1</SemGridColumn>
    <SemGridColumn>2</SemGridColumn>
    <SemGridColumn>3</SemGridColumn>
  </SemGridRow>
</SemGrid>
```

---

## SemGridColumn

**Inherits:** `SemControlBase`

A column within a grid.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Column content |
| Wide | GridUnit? | null | Column width (1-16) |
| Classes | ColumnClass[] | null | Additional CSS classes |

### ColumnClass Options
`Right_Floated`, `Left_Floated`, `Right_Aligned`, `Left_Aligned`, `Center_Aligned`, `Doubling`

### Example
```razor
<SemGridColumn Wide="GridUnit.Eight" Classes="@(new[] { ColumnClass.Center_Aligned })">
  Centered 8-wide column
</SemGridColumn>
```

---

## SemSegment

**Inherits:** `SemControlBase`

A container for grouping related content.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Segment content |
| Color | Color? | null | Segment color |
| Emphasis | Emphasis? | null | Primary, Secondary, Tertiary |
| Classes | SegmentClass[] | null | Additional CSS classes |

### SegmentClass Options
`Basic`, `Raised`, `Stacked`, `Piled`, `Compact`, `Circular`, `Clearing`, `Loading`, `Placeholder`, `Vertical`, `Inverted`, `Top_Attached`, `Bottom_Attached`, `Padded`, `Very_Padded`, `Right_Floated`, `Left_Floated`, `Right_Aligned`, `Left_Aligned`, `Center_Aligned`, `Attached`

### Examples

```razor
<SemSegment>Basic segment</SemSegment>

<SemSegment Color="Color.Blue" Classes="@(new[] { SegmentClass.Raised })">
  Blue raised segment
</SemSegment>

<SemSegment Classes="@(new[] { SegmentClass.Loading })">
  Loading content...
</SemSegment>

<SemSegment Classes="@(new[] { SegmentClass.Padded, SegmentClass.Inverted })" Color="Color.Black">
  Inverted padded segment
</SemSegment>
```

---

## SemDivider

**Inherits:** `SemControlBase`

A horizontal or vertical divider.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Optional content (text) |
| Classes | DividerClass[] | null | Additional CSS classes |

### DividerClass Options
`Horizontal`, `Vertical`, `Inverted`, `Fitted`, `Hidden`, `Clearing`

### Examples

```razor
<SemDivider></SemDivider>

<SemDivider Classes="@(new[] { DividerClass.Horizontal })">
  OR
</SemDivider>

<SemDivider Classes="@(new[] { DividerClass.Hidden })"></SemDivider>
```
