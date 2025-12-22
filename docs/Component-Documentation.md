# SemanticBlazor - Component Documentation

SemanticBlazor is a Blazor component library based on Semantic UI principles. This documentation provides an overview of available components, their parameters, and usage examples, which can serve as a reference for AI assistants working with this library.

## Basic Concepts

### Base Component Classes

All components in SemanticBlazor inherit from these base classes:

- **SemControlBase**: The base class for all components, containing common parameters like Id, Class, Style, Visible, Enabled, and Attributes.
- **SemInputControlBase<TValue>**: Specialized base class for input components, adding parameters like Value, ValueChanged, and functions for form validation.
- **SemDropdownSingleSelectionBase<TItem, TValue>**: Base class for all dropdown lists for single value selection.
- **SemDropdownMultipleSelectionBase<TItem, TValue>**: Base class for all dropdown lists for multiple value selection.
- **SemButtonSwitchBase<TItem, TValue>**: Base class for all button switch components.
- **SemCheckboxListBase<TItem, TValue>**: Base class for all checkbox list components.
- **SemRadioButtonListBase<TItem, TValue>**: Base class for all radio button list components.
- **SemListBase<TItem>**: Base class for all item lists.

### Common Component Parameters

All components share these basic parameters:

- **Id**: Unique component identifier (defaults to a generated GUID)
- **Class**: CSS classes added to the component
- **Style**: Inline CSS style for the component
- **Visible**: Determines if the component is visible
- **Enabled**: Determines if the component is enabled (disabled components have the "disabled" attribute)
- **Attributes**: Dictionary<string, object> for additional HTML attributes

### Common Enums

The library uses several enum types for consistent appearance and behavior:

#### Colors
- **Color**: Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black
- **ButtonColor**: Positive, Negative and all Color values
- **MessageColor**: Info, Positive, Warning, Negative and all Color values
- **HeaderColor**: Red, Orange, Yellow, Olive, Green, Teal, Blue, Violet, Purple, Pink, Brown, Grey, Black

#### Sizes
- **Size**: Mini, Tiny, Small, Medium, Large, Big, Huge, Massive
- **InputSize**: Mini, Small, Large, Big, Huge, Massive
- **ModalSize**: Mini, Tiny, Small, Large, Fullscreen
- **HeaderSize**: Tiny, Small, Medium, Large, Huge

#### States and Emphasis
- **State**: Success, Error, Warning
- **Emphasis**: Primary, Secondary, Tertiary

## Components

### Buttons

#### SemButton

Button component that can be rendered as a button or link (a) depending on parameters.

**Parameters:**
- **OnClick**: EventCallback for button click
- **ChildContent**: Button content
- **Href**: URL for the link (when button is rendered as a link)
- **IsSubmitButton**: True to create a form submit button
- **IsButton**: True to create a button instead of a link (default true)
- **OnClickLoading**: True to show loading state after click
- **Tooltip**: Tooltip text
- **Icon**: Button icon
- **IconPosition**: Icon position (Left, Right)
- **IconLabeled**: True to display icon as a label
- **Color**: Button color (ButtonColor)
- **Emphasis**: Button emphasis (Primary, Secondary, Tertiary)
- **Size**: Button size
- **Classes**: Array of button style classes

**Confirmation dialog:**
- **NeedsConfirmation**: True to display a confirmation dialog before action
- **ConfirmationHeader**: Confirmation dialog title
- **ConfirmationMessage**: Confirmation dialog message
- **CancelButtonText**: Cancel button text (default "No")
- **ConfirmButtonText**: Confirm button text (default "Yes")
- **ConfirmButtonIconClass**: CSS class for confirm button icon

**Usage:**
```razor
<SemButton Color="ButtonColor.Blue" Icon="Icon.Save_Icon">Save</SemButton>
<SemButton Color="ButtonColor.Green" Emphasis="Emphasis.Primary" OnClick="@SaveData">Save Data</SemButton>
<SemButton Color="ButtonColor.Red" NeedsConfirmation="true" ConfirmationMessage="Are you sure you want to delete this record?">Delete</SemButton>
```

### Forms

#### SemForm

Form component that wraps the standard EditForm with extended functionality.

**Parameters:**
- **ChildContent**: Form content
- **OnInvalidSubmit**: EventCallback called on invalid submission
- **OnValidSubmit**: EventCallback called on valid submission
- **OnSubmit**: EventCallback called on any submission
- **Model**: Form data model
- **Size**: Form size
- **State**: Form state (Success, Error, Warning)
- **Classes**: Array of form style classes
- **FormValidationPosition**: Position for displaying form validation errors (Top, Bottom, Hidden)
- **FieldValidationPosition**: Position for displaying field validation errors (Top, Bottom, Hidden)
- **ShowLoadingOnSubmit**: True to show loading state on submission

**Methods:**
- **Submit()**: Programmatic form submission

**Usage:**
```razor
<SemForm Model="@formModel" OnValidSubmit="@HandleValidSubmit" FormValidationPosition="ValidationPosition.Top">
    <!-- Form content -->
</SemForm>
```

#### SemFormField

Component for wrapping individual form fields.

**Parameters:**
- **ChildContent**: Field content
- **For**: Expression<Func<TValue>> for automatic validation
- **Label**: Field label
- **Required**: True for required field
- **Width**: Field width

**Usage:**
```razor
<SemFormField Label="Name" Required="true">
    <SemInput @bind-Value="@model.Name" />
</SemFormField>
```

### Input Fields

#### SemInput

Basic input field for various data types.

**Parameters:**
- **Value**: Field value (TValue)
- **ValueChanged**: EventCallback on value change
- **For**: Expression<Func<TValue>> for automatic validation
- **EnterPressed**: EventCallback on Enter key press
- **Icon**: Field icon
- **IconPosition**: Icon position (Left, Right)
- **Clearable**: True to add the ability to clear the value
- **Placeholder**: Placeholder text
- **IsPassword**: True for password field
- **NumberStep**: Step for number field
- **NumberMin**: Minimum value for number field
- **NumberMax**: Maximum value for number field
- **InputClass**: CSS classes added to the input element
- **InputStyle**: Inline CSS style for input element
- **Size**: Field size
- **Classes**: Array of style classes
- **Rows**: Number of rows for textarea

**Usage:**
```razor
<SemInput @bind-Value="@model.Username" Placeholder="Username" Icon="Icon.User_Icon" />
<SemInput @bind-Value="@model.Password" IsPassword="true" Placeholder="Password" Icon="Icon.Lock_Icon" />
<SemInput @bind-Value="@model.Price" InputType="number" NumberMin="0" NumberStep="0.01" />
<SemInput @bind-Value="@model.Description" InputType="textarea" Rows="3" />
```

#### SemDateTimeInput

Input field for date and time.

**Parameters:**
- All standard SemInputControlBase parameters
- **ShowButtons**: True to display buttons for changing date/time
- **Format**: Date and time format
- **SelectOnFocus**: True to select content on focus

**Usage:**
```razor
<SemDateTimeInput @bind-Value="@model.EventDate" Format="MM/dd/yyyy" />
```

#### SemDropdownSelection

Dropdown list for single value selection.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: List items (obsolete)
- **ListItems**: RenderFragment for defining items
- **DefaultText**: Text displayed when no value is selected (default "Select...")
- **Icon**: Dropdown icon
- **Search**: True to enable search in items
- **Scrolling**: True to activate scrollbar for many items
- **FulltextSearchMode**: Fulltext search mode (True = enabled, False = disabled, Exact = exact match)
- **Clearable**: True to enable clearing selection (not available for non-nullable numeric types)
- **IsButton**: True to display as a button instead of standard appearance
- **ButtonIcon**: Button icon (with IsButton=true)
- **ButtonIconPosition**: Button icon position
- **ButtonIconLabeled**: True to display icon as a label
- **ButtonColor**: Button color
- **ButtonEmphasis**: Button emphasis
- **ButtonSize**: Button size
- **ButtonClasses**: Array of button style classes

**Usage:**
```razor
<SemDropdownSelection @bind-Value="@selectedValue" Search="true" Clearable="true">
    <ListItems>
        <SemSelectListItem Value="1">Item 1</SemSelectListItem>
        <SemSelectListItem Value="2">Item 2</SemSelectListItem>
    </ListItems>
</SemDropdownSelection>
```

#### SemDropdownMultiSelection

Dropdown list for multiple value selection.

**Parameters:**
- Similar to SemDropdownSelection, but Value is a collection of values

**Usage:**
```razor
<SemDropdownMultiSelection @bind-Value="@selectedValues" Search="true">
    <ListItems>
        <SemSelectListItem Value="1">Item 1</SemSelectListItem>
        <SemSelectListItem Value="2">Item 2</SemSelectListItem>
    </ListItems>
</SemDropdownMultiSelection>
```

#### SemButtonSwitch

Component for switching between multiple values using buttons.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: List items (obsolete)
- **ItemTemplate**: RenderFragment for item template
- **ListItems**: RenderFragment for defining items
- **Size**: Button size
- **Color**: Button color
- **Classes**: Array of style classes

**Usage:**
```razor
<SemButtonSwitch @bind-Value="@selectedValue">
    <ListItems>
        <SemSelectListItem Value="1">Option 1</SemSelectListItem>
        <SemSelectListItem Value="2">Option 2</SemSelectListItem>
    </ListItems>
</SemButtonSwitch>
```

#### SemDataButtonSwitch

Specialized version of SemButtonSwitch for working with generic data.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: Collection of items
- **ValueSelector**: Function to select value from item
- **ItemKey**: Function to select item key
- **ItemText**: Function to select item text
- **DataMethod**: Function to load data

**Parameters inherited from SemButtonSwitchBase:**
- **Size**: Button size
- **Color**: Button color
- **Classes**: Array of style classes

**Usage:**
```razor
<SemDataButtonSwitch @bind-Value="@selectedValue" 
                    Items="@people"
                    ValueSelector="@(p => p.Id)"
                    ItemText="@(p => p.Name)" />
```

#### SemDataDropdownSelection

Specialized version of SemDropdownSelection for working with generic data.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: Collection of items
- **ValueSelector**: Function to select value from item
- **ItemKey**: Function to select item key
- **ItemText**: Function to select item text
- **DataMethod**: Function to load data
- **AllowAdditions**: True to allow adding new items (only for strings)

**Parameters inherited from SemDropdownSingleSelectionBase:**
- **DefaultText**: Text displayed when no value is selected (default "Select...")
- **Icon**: Dropdown icon
- **Search**: True to enable search in items
- **Scrolling**: True to activate scrollbar for many items
- **FulltextSearchMode**: Fulltext search mode (True = enabled, False = disabled, Exact = exact match)
- **Clearable**: True to enable clearing selection (not available for non-nullable numeric types)
- **IsButton**: True to display as a button instead of standard appearance
- **ButtonIcon**: Button icon (with IsButton=true)
- **ButtonIconPosition**: Button icon position
- **ButtonIconLabeled**: True to display icon as a label
- **ButtonColor**: Button color
- **ButtonEmphasis**: Button emphasis
- **ButtonSize**: Button size
- **ButtonClasses**: Array of button style classes

**Usage:**
```razor
<SemDataDropdownSelection @bind-Value="@selectedPersonId"
                         Items="@people"
                         ValueSelector="@(p => p.Id)"
                         ItemText="@(p => p.Name)"
                         DefaultText="Select a person..."
                         Search="true"
                         Clearable="true" />
```

#### SemDataDropdownMultiSelection

Specialized version of SemDropdownMultiSelection for working with generic data.

**Parameters:**
- **Value**: Collection of selected values
- **ValueChanged**: EventCallback on value change
- **Items**: Collection of items
- **ValueSelector**: Function to select value from item
- **ItemKey**: Function to select item key
- **ItemText**: Function to select item text
- **DataMethod**: Function to load data

**Parameters inherited from SemDropdownMultipleSelectionBase:**
- **DefaultText**: Text displayed when no value is selected (default "Select...")
- **Icon**: Dropdown icon
- **Search**: True to enable search in items
- **Scrolling**: True to activate scrollbar for many items
- **FulltextSearchMode**: Fulltext search mode (True = enabled, False = disabled, Exact = exact match)
- **IsButton**: True to display as a button instead of standard appearance
- **ButtonIcon**: Button icon (with IsButton=true)
- **ButtonIconPosition**: Button icon position
- **ButtonIconLabeled**: True to display icon as a label
- **ButtonColor**: Button color
- **ButtonEmphasis**: Button emphasis
- **ButtonSize**: Button size
- **ButtonClasses**: Array of button style classes

**Usage:**
```razor
<SemDataDropdownMultiSelection @bind-Value="@selectedPersonIds"
                              Items="@people"
                              ValueSelector="@(p => p.Id)"
                              ItemText="@(p => p.Name)"
                              DefaultText="Select people..."
                              Search="true" />
```

#### SemCheckbox

Checkbox component.

**Parameters:**
- **Value**: Checkbox value (bool)
- **ValueChanged**: EventCallback on value change
- **For**: Expression<Func<bool>> for automatic validation
- **Label**: Checkbox label
- **Disabled**: True for disabled checkbox
- **ReadOnly**: True for read-only checkbox

**Usage:**
```razor
<SemCheckbox @bind-Value="@model.IsActive" Label="Active" />
```

#### SemCheckboxList

Component for displaying a list of checkboxes.

**Parameters:**
- **Value**: List of selected values
- **ValueChanged**: EventCallback on selection change
- **Items**: List of items (obsolete)
- **ListItems**: RenderFragment for defining items
- **Direction**: List direction (Vertical, Horizontal)

**Usage:**
```razor
<SemCheckboxList @bind-Value="@selectedValues">
    <ListItems>
        <SemSelectListItem Value="1">Item 1</SemSelectListItem>
        <SemSelectListItem Value="2">Item 2</SemSelectListItem>
    </ListItems>
</SemCheckboxList>
```

#### SemDataCheckboxList

Specialized version of SemCheckboxList for working with generic data.

**Parameters:**
- **Value**: List of selected values
- **ValueChanged**: EventCallback on selection change
- **Items**: Collection of items
- **ValueSelector**: Function to select value from item
- **ItemKey**: Function to select item key
- **ItemText**: Function to select item text
- **DataMethod**: Function to load data

**Parameters inherited from SemCheckboxListBase:**
- **Direction**: List direction (Vertical, Horizontal)

**Usage:**
```razor
<SemDataCheckboxList @bind-Value="@selectedPersonIds"
                    Items="@people"
                    ValueSelector="@(p => p.Id)"
                    ItemText="@(p => p.Name)" />
```

#### SemRadioButtonList

Component for displaying a list of radio buttons.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: List of items (obsolete)
- **ListItems**: RenderFragment for defining items
- **Direction**: List direction (Vertical, Horizontal)

**Usage:**
```razor
<SemRadioButtonList @bind-Value="@selectedValue">
    <ListItems>
        <SemSelectListItem Value="1">Item 1</SemSelectListItem>
        <SemSelectListItem Value="2">Item 2</SemSelectListItem>
    </ListItems>
</SemRadioButtonList>
```

#### SemDataRadioButtonList

Specialized version of SemRadioButtonList for working with generic data.

**Parameters:**
- **Value**: Selected value
- **ValueChanged**: EventCallback on value change
- **Items**: Collection of items
- **ValueSelector**: Function to select value from item
- **ItemKey**: Function to select item key
- **ItemText**: Function to select item text
- **DataMethod**: Function to load data

**Parameters inherited from SemRadioButtonListBase:**
- **Direction**: List direction (Vertical, Horizontal)

**Usage:**
```razor
<SemDataRadioButtonList @bind-Value="@selectedPersonId"
                       Items="@people"
                       ValueSelector="@(p => p.Id)"
                       ItemText="@(p => p.Name)" />
```

### Tables and Lists

#### SemDataTable

Table component for displaying data with sorting, paging, and other features.

**Parameters:**
- **Items**: Collection of items to display
- **Columns**: RenderFragment for defining columns
- **ShowHeader**: True to display table header
- **Striped**: True for zebra-striped rows
- **Selectable**: True for selectable rows
- **SelectedItem**: Selected item (with Selectable=true)
- **SelectedItemChanged**: EventCallback on selected item change
- **PageSize**: Page size for pagination
- **CurrentPage**: Current page
- **ShowPager**: True to display pagination
- **LoadingText**: Text during loading

**Usage:**
```razor
<SemDataTable Items="@people" Selectable="true" @bind-SelectedItem="selectedPerson" ShowPager="true" PageSize="10">
    <Columns>
        <SemDataTableColumn TItem="Person" Property="p => p.Id" Title="ID" Sortable="true" />
        <SemDataTableColumn TItem="Person" Property="p => p.Name" Title="Name" Sortable="true" />
        <SemDataTableColumn TItem="Person" Property="p => p.Email" Title="Email" />
        <SemDataTableColumn TItem="Person" Title="Actions">
            <Template>
                <SemButton Color="ButtonColor.Red" Size="Size.Mini" OnClick="@(() => Delete(context))">Delete</SemButton>
            </Template>
        </SemDataTableColumn>
    </Columns>
</SemDataTable>
```

#### SemDataList

Component for displaying a list of items.

**Parameters:**
- **Items**: Collection of items to display
- **Selectable**: True for selectable items
- **SelectedItem**: Selected item
- **SelectedItemChanged**: EventCallback on selected item change
- **ItemTemplate**: Template for rendering items
- **PageSize**: Page size for pagination
- **CurrentPage**: Current page
- **ShowPager**: True to display pagination

**Usage:**
```razor
<SemDataList Items="@people" Selectable="true" @bind-SelectedItem="selectedPerson">
    <ItemTemplate Context="person">
        <SemDataListItem>
            <div class="content">
                <div class="header">@person.Name</div>
                <div class="description">@person.Email</div>
            </div>
        </SemDataListItem>
    </ItemTemplate>
</SemDataList>
```

#### SemDataListItem

Component for a SemDataList item.

**Parameters:**
- **ChildContent**: Item content
- **Active**: True for active item
- **Disabled**: True for disabled item

### Menu and Navigation

#### SemMenu

Menu component with support for items and submenus.

**Parameters:**
- **ChildContent**: Menu content (items)
- **Vertical**: True for vertical menu
- **Inverted**: True for inverted color scheme
- **Secondary**: True for secondary appearance
- **Pointing**: True for pointing style
- **Tabular**: True for tabular appearance
- **Text**: True for text appearance
- **Fluid**: True for 100% width
- **Compact**: True for compact display
- **Size**: Menu size

**Usage:**
```razor
<SemMenu Secondary="true" Pointing="true">
    <SemMenuItem Active="page == 'home'" OnClick="@(() => NavigateTo('home'))">Home</SemMenuItem>
    <SemMenuItem Active="page == 'users'" OnClick="@(() => NavigateTo('users'))">Users</SemMenuItem>
    <SemMenuItem Active="page == 'settings'" OnClick="@(() => NavigateTo('settings'))">Settings</SemMenuItem>
</SemMenu>
```

### Modal Dialogs

#### SemModal

Modal dialog with support for header, content, and actions.

**Parameters:**
- **Header**: Dialog title
- **ChildContent**: Dialog content
- **Actions**: RenderFragment for action buttons
- **Size**: Dialog size (ModalSize)
- **Closable**: True to allow closing with X
- **ShowCloseButton**: True to display close button
- **CloseOnBackdrop**: True to close when clicking backdrop
- **CloseOnEscape**: True to close when pressing Escape
- **AutoOpen**: True to automatically open on render

**Methods:**
- **Open()**: Opens the dialog
- **Close()**: Closes the dialog
- **Toggle()**: Toggles between open and closed states

**Usage:**
```razor
<SemButton OnClick="@(() => modal.Open())">Open Dialog</SemButton>

<SemModal @ref="modal" Header="User Details" Size="ModalSize.Small">
    <Content>
        <!-- Dialog content -->
    </Content>
    <Actions>
        <SemButton Color="ButtonColor.Green" OnClick="@SaveChanges">Save</SemButton>
        <SemButton OnClick="@(() => modal.Close())">Cancel</SemButton>
    </Actions>
</SemModal>
```

#### SemModalConfirmation

Specialized modal dialog for action confirmation.

**Parameters:**
- **Header**: Dialog title
- **ChildContent**: Dialog content
- **CancelButtonText**: Cancel button text
- **ConfirmButtonText**: Confirm button text
- **ConfirmButtonIconClass**: CSS class for confirm button icon
- **OnConfirm**: EventCallback called on confirmation

**Usage:**
```razor
<SemButton OnClick="@(() => confirmModal.Open())" Color="ButtonColor.Red">Delete</SemButton>

<SemModalConfirmation @ref="confirmModal" Header="Confirm Deletion" OnConfirm="@DeleteItem">
    <Content>
        Are you sure you want to delete this item?
    </Content>
</SemModalConfirmation>
```

### Other Components

#### SemIcon

Component for displaying icons.

**Parameters:**
- **Icon**: Icon to display
- **Size**: Icon size
- **Color**: Icon color
- **Loading**: True for animated loading icon
- **Disabled**: True for disabled icon
- **Circular**: True for circular icon
- **Bordered**: True for icon with border
- **Link**: True for link icon
- **OnClick**: EventCallback on click

**Usage:**
```razor
<SemIcon Icon="Icon.User_Icon" Size="Size.Large" />
<SemIcon Icon="Icon.Spinner_Icon" Loading="true" />
```

#### SemMessage

Component for displaying messages and alerts.

**Parameters:**
- **ChildContent**: Message content
- **Header**: Message title
- **Icon**: Message icon
- **Color**: Message color (MessageColor)
- **Dismissable**: True for dismissable message
- **Floating**: True for floating message
- **Compact**: True for compact display
- **Attached**: True for attached message (to another element)
- **Size**: Message size

**Usage:**
```razor
<SemMessage Color="MessageColor.Info" Icon="Icon.Info_Circle_Icon" Header="Information">
    This is an informational message.
</SemMessage>

<SemMessage Color="MessageColor.Negative" Icon="Icon.Exclamation_Circle_Icon" Dismissable="true">
    <Header>Error!</Header>
    <p>An error occurred while saving data.</p>
</SemMessage>
```

#### SemGrid

Component for responsive layouts.

**Parameters:**
- **ChildContent**: Grid content (rows and columns)
- **Columns**: Number of columns
- **Stackable**: True for stacking on small screens
- **Doubling**: True for doubling columns on small screens
- **Padded**: True for inner padding

**Usage:**
```razor
<SemGrid Columns="3" Stackable="true">
    <SemGridRow>
        <SemGridColumn Width="4">Column 1</SemGridColumn>
        <SemGridColumn Width="8">Column 2</SemGridColumn>
        <SemGridColumn Width="4">Column 3</SemGridColumn>
    </SemGridRow>
</SemGrid>
```

#### SemSegment

Component for content sections.

**Parameters:**
- **ChildContent**: Segment content
- **Color**: Segment color
- **Classes**: Array of segment style classes
- **Loading**: True for loading state
- **Disabled**: True for disabled segment
- **Inverted**: True for inverted color scheme

**Usage:**
```razor
<SemSegment Classes="@(new [] { SegmentClass.Raised, SegmentClass.Padded })">
    <p>Segment content...</p>
</SemSegment>
```

#### SemCards

Component for displaying cards.

**Parameters:**
- **ChildContent**: Cards content
- **Centered**: True for centered cards
- **PerRow**: Number of cards per row

**Usage:**
```razor
<SemCards PerRow="3">
    <div class="ui card">
        <div class="content">
            <div class="header">Card 1</div>
            <div class="description">Card description</div>
        </div>
    </div>
    <div class="ui card">
        <div class="content">
            <div class="header">Card 2</div>
            <div class="description">Card description</div>
        </div>
    </div>
</SemCards>
```

#### SemDivider

Component for visual content separation.

**Parameters:**
- **Text**: Text displayed on the divider
- **Horizontal**: True for horizontal divider
- **Vertical**: True for vertical divider
- **Hidden**: True for hidden divider
- **Fitted**: True for divider without margins
- **Section**: True for section divider
- **Clearing**: True for clearing divider

**Usage:**
```razor
<SemDivider Text="Section 1" />
<p>Section 1 content...</p>
<SemDivider />
<p>Section 2 content...</p>
```

#### SemTabs

Component for displaying tabs.

**Parameters:**
- **ChildContent**: Tabs content (individual tabs)
- **ActiveTabId**: ID of active tab
- **ActiveTabIdChanged**: EventCallback on active tab change
- **Pointing**: True for pointing style tabs
- **Secondary**: True for secondary style tabs
- **Tabular**: True for tabular style tabs

**Usage:**
```razor
<SemTabs @bind-ActiveTabId="activeTabId">
    <SemTab Id="1" Title="Tab 1">Tab 1 content</SemTab>
    <SemTab Id="2" Title="Tab 2">Tab 2 content</SemTab>
</SemTabs>
```

#### SemTab

Component for a single tab in SemTabs.

**Parameters:**
- **Id**: Tab identifier
- **Title**: Tab title
- **ChildContent**: Tab content

#### SemValidationMessage

Component for displaying validation message for a specific form field.

**Parameters:**
- **For**: Expression<Func<TValue>> for automatic validation
- **Icon**: Error message icon

**Usage:**
```razor
<SemInput @bind-Value="@model.Name" For="@(() => model.Name)" />
<SemValidationMessage For="@(() => model.Name)" />
```

#### SemValidationSummary

Component for displaying a summary of form validation errors.

**Parameters:**
- **Header**: Summary title
- **ShowErrorCount**: True to display error count

**Usage:**
```razor
<SemForm Model="@model">
    <!-- Form content -->
    <SemValidationSummary Header="Please fix the following errors:" />
</SemForm>
```

#### SemSearchActionButton

Component for a search field with action button.

**Parameters:**
- **Value**: Search field value
- **ValueChanged**: EventCallback on value change
- **OnSearch**: EventCallback for search action
- **Placeholder**: Placeholder text
- **ButtonText**: Button text
- **ButtonColor**: Button color
- **ButtonIcon**: Button icon
- **Loading**: True to display loading state

**Usage:**
```razor
<SemSearchActionButton @bind-Value="@searchTerm" 
                      OnSearch="@Search" 
                      Placeholder="Search..." 
                      ButtonIcon="Icon.Search_Icon" />
```

## Best Practices for Using SemanticBlazor

1. Always use `SemForm` with appropriate data model and validation for forms.
2. Use `SemFormField` for inserting fields into forms for consistent appearance and behavior.
3. When action confirmation is needed, use `NeedsConfirmation` on buttons or `SemModalConfirmation`.
4. For complex data tables, use `SemDataTable` with defined columns for better clarity and functionality.
5. Use the library's enum types for consistent colors and sizes across your application.

## Tips for AI Assistant

- Check that all components use the correct enum types for colors and sizes.
- For input fields, recommend using `@bind-Value` for two-way data binding.
- For form fields, suggest adding validation using the `For` parameter.
- When designing layouts, recommend using `SemGrid` for responsive design.
- For user interaction, prefer `SemButton` with appropriate colors and icons.
- For displaying user feedback, suggest `SemMessage` with appropriate color based on message type.
- For tables, don't forget about pagination and sorting options for better user experience.
