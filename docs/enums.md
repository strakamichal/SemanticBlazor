# Enums Reference

All enums are in the `SemanticBlazor` namespace.

## Helper Methods

```csharp
// Convert enum to CSS class (lowercase, underscores to spaces)
Enums.GetClass(Color.Red)           // "red"
Enums.GetClass(GridClass.Equal_Width) // "equal width"

// Convert array to space-separated classes
Enums.GetClasses(new[] { ButtonClass.Basic, ButtonClass.Inverted }) // "basic inverted"

// Get icon CSS class
Icons.GetClass(Icon.User)  // "user"
```

---

## Colors

### Color
General color enum for most components.
```
Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black
```

### ButtonColor
Extended colors for buttons with semantic states.
```
Positive, Negative, Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black
```

### MessageColor
Extended colors for messages with semantic states.
```
Info, Positive, Warning, Negative, Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black
```

### HeaderColor
Colors for headers.
```
Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black
```

---

## Sizes

### Size
General size options.
```
Mini, Tiny, Small, Medium, Large, Big, Huge, Massive
```

### InputSize
Size options for input components.
```
Mini, Small, Large, Big, Huge, Massive
```

### ModalSize
Size options for modals.
```
Mini, Tiny, Small, Large, Fullscreen
```

### HeaderSize
Size options for headers.
```
Tiny, Small, Medium, Large, Huge
```

---

## States & Emphasis

### State
```
Success, Error, Warning
```

### Emphasis
```
Primary, Secondary, Tertiary
```

---

## Positioning

### IconPosition
```
Right, Left
```

### ValidationPosition
```
Hidden, Top, Bottom
```

### TabMenuPosition
```
Top, Bottom
```

---

## Component Behavior

### CheckboxType
```
Checkbox, Slider, Toggle
```

### ListViewType
```
List, Items, Comments, Feed, Cards, Custom
```

### DropdownAction
```
Auto, Activate, Select, Combo, Hide, Nothing
```

### DropdownOn
```
Click, Hover
```

### DropdownFulltextSearch
```
True, False, Exact
```

### TimePrecision
```
Hour, Minute
```

### ModalCloseIcon
```
Outside, Inside, None
```

---

## CSS Class Enums

### GridUnit
Column count (1-16).
```
One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen
```

### GridClass
```
Relaxed, Very_Relaxed, Celled, Internally_Celled, Equal_Width, Centered, Right_Aligned, Left_Aligned, Center_Aligned, Stackable, Mobile_Reversed
```

### ColumnClass
```
Right_Floated, Left_Floated, Right_Aligned, Left_Aligned, Center_Aligned, Doubling
```

### SegmentClass
```
Basic, Raised, Stacked, Piled, Compact, Circular, Clearing, Loading, Placeholder, Vertical, Inverted, Top_Attached, Bottom_Attached, Padded, Very_Padded, Right_Floated, Left_Floated, Right_Aligned, Left_Aligned, Center_Aligned, Attached
```

### DividerClass
```
Horizontal, Vertical, Inverted, Fitted, Hidden, Clearing
```

### ButtonClass
```
Animated, Labeled, Icon, Basic, Inverted, Right_Floated, Left_Floated, Compact, Toggle, Fluid, Circular, Top_Attached, Bottom_Attached, Left_Attached, Right_Attached
```

### IconClass
```
Loading, Fitted, Flipped, Rotated, Circular, Bordered, Inverted
```

### InputClass
```
Transparent, Inverted, Fluid, Labeled
```

### LabelClass
```
Basic, Empty, Horizontal, Floating, Image, Right, Left, Top_Attached, Bottom_Attached, Circular, Pointing, Pointing_Below, Corner, Tag, Ribbon
```

### MessageClass
```
Floating, Compact, Top_Attached, Bottom_Attached
```

### MenuClass
```
Secondary, Compact, Pointing, Text, Vertical, Fluid, Pagination, Tabular, Fixed, Stackable, Inverted, Top_Attached, Bottom_Attached, Fitted, Borderless
```

### FormClass
```
Loading, Equal_Width, Inverted
```

### FieldsClass
```
Equal_Width, Inline
```

### FieldClass
```
Inline
```

### HeaderClass
```
Dividing, Block, Top_Attached, Attached, Bottom_Attached, Left, Right, Right_Floated, Left_Floated, Justified, Inverted, Center, Sub, Right_Aligned, Left_Aligned, Center_Aligned
```

---

## Icon Enum

The `Icon` enum contains 900+ icons. Here are the most commonly used:

### Loading Icons
```
Spinner_Loading, Notched_Circle_Loading, Sync_Loading, Sync_Alternate_Loading, Cog_Loading
```

### Common Actions
```
Edit, Trash, Trash_Alternate, Save, Download, Upload, Copy, Cut, Paste, Undo, Redo, Search, Plus, Minus, Check, Times, Close_Icon
```

### Navigation
```
Arrow_Left, Arrow_Right, Arrow_Up, Arrow_Down, Angle_Left, Angle_Right, Angle_Up, Angle_Down, Chevron_Left, Chevron_Right, Chevron_Up, Chevron_Down
```

### Status & Indicators
```
Check_Circle, Times_Circle, Exclamation_Triangle, Exclamation_Circle, Info_Circle, Question_Circle, Bell, Star
```

### User & People
```
User, Users, User_Plus, User_Circle
```

### Objects
```
Home, Cog, Cogs, Calendar, Clock, Envelope, Phone, File, Folder, Image, Camera, Heart, Flag, Tag, Bookmark
```

### Media
```
Play, Pause, Stop, Forward, Backward, Volume_Up, Volume_Down
```

### Social
```
Facebook, Twitter, Instagram, Linkedin, Github, Google
```

### Usage Example
```razor
<SemIcon Icon="Icon.User"></SemIcon>
<SemIcon Icon="Icon.Spinner_Loading"></SemIcon>
<SemButton Icon="Icon.Save">Save</SemButton>
<SemButton Icon="Icon.Trash" Color="ButtonColor.Red"></SemButton>
```

For the complete list of 900+ icons, see the `Icon` enum in `SemanticBlazor/Enums.cs`.
