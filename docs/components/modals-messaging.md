# Modals & Messaging Components

## SemModal

**Inherits:** `SemControlBase`

A modal dialog.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Header | RenderFragment | - | Modal header content |
| Content | RenderFragment | - | Modal body content |
| Actions | RenderFragment | - | Modal footer/actions |
| Size | ModalSize? | null | Modal size |
| HeaderClass | string | null | Header CSS class |
| ContentClass | string | null | Content CSS class |
| ActionsClass | string | null | Actions CSS class |
| AllowMultiple | bool | false | Allow stacking modals |
| Closable | bool | true | Can close by clicking outside |
| CloseIcon | ModalCloseIcon | Outside | Close icon position |

### ModalSize Options
`Mini`, `Tiny`, `Small`, `Large`, `Fullscreen`

### ModalCloseIcon Options
`Outside`, `Inside`, `None`

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| Show() | Task | Show the modal |
| Hide() | Task | Hide the modal |
| SubmitForm() | Task | Submit form inside modal |

### Examples

**Basic modal:**
```razor
<SemButton OnClick="() => modal.Show()">Open Modal</SemButton>

<SemModal @ref="modal" Size="ModalSize.Small">
  <Header>Modal Title</Header>
  <Content>
    Modal content goes here.
  </Content>
  <Actions>
    <SemButton OnClick="() => modal.Hide()">Cancel</SemButton>
    <SemButton Color="ButtonColor.Positive" OnClick="Save">Save</SemButton>
  </Actions>
</SemModal>

@code {
    SemModal modal;
}
```

**Large modal with scrolling content:**
```razor
<SemModal @ref="modal" Size="ModalSize.Large" ContentClass="scrolling">
  <Header>Long Content</Header>
  <Content>
    <!-- Long content here -->
  </Content>
  <Actions>
    <SemButton OnClick="() => modal.Hide()">Close</SemButton>
  </Actions>
</SemModal>
```

**Non-closable modal:**
```razor
<SemModal @ref="modal" Closable="false" CloseIcon="ModalCloseIcon.None">
  <Header>Required Action</Header>
  <Content>
    You must complete this action before continuing.
  </Content>
  <Actions>
    <SemButton Color="ButtonColor.Positive" OnClick="Complete">Complete</SemButton>
  </Actions>
</SemModal>
```

**Form modal:**
```razor
<SemModal @ref="editModal">
  <Header>Edit Item</Header>
  <Content>
    <SemForm Model="item" OnValidSubmit="SaveAndClose">
      <SemFormField For="@(() => item.Name)">
        <SemInput @bind-Value="item.Name"></SemInput>
      </SemFormField>
      <SemFormField For="@(() => item.Description)">
        <SemInput @bind-Value="item.Description" Rows="3"></SemInput>
      </SemFormField>
    </SemForm>
  </Content>
  <Actions>
    <SemButton OnClick="() => editModal.Hide()">Cancel</SemButton>
    <SemButton Color="ButtonColor.Positive" OnClick="() => editModal.SubmitForm()">Save</SemButton>
  </Actions>
</SemModal>
```

---

## SemModalConfirmation

**Inherits:** `SemControlBase`

A pre-styled confirmation modal dialog.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Header | string | null | Confirmation header |
| Content | RenderFragment | - | Confirmation message |
| CancelButtonText | string | "No" | Cancel button text |
| ConfirmButtonText | string | "Yes" | Confirm button text |
| ConfirmButtonIconClass | string | "checkmark" | Confirm button icon |
| OnClick | EventCallback<MouseEventArgs> | - | Confirm action handler |

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| Show() | Task | Show the confirmation |

### Examples

**Basic confirmation:**
```razor
<SemButton OnClick="() => confirmDelete.Show()" Color="ButtonColor.Negative">
  Delete
</SemButton>

<SemModalConfirmation @ref="confirmDelete"
                      Header="Confirm Delete"
                      OnClick="DeleteItem">
  <Content>
    Are you sure you want to delete this item?
  </Content>
</SemModalConfirmation>

@code {
    SemModalConfirmation confirmDelete;

    async Task DeleteItem() {
        await itemService.DeleteAsync(item.Id);
        NavigationManager.NavigateTo("/items");
    }
}
```

**Custom buttons:**
```razor
<SemModalConfirmation @ref="confirmLogout"
                      Header="Logout"
                      CancelButtonText="Stay"
                      ConfirmButtonText="Logout"
                      ConfirmButtonIconClass="sign out"
                      OnClick="PerformLogout">
  <Content>
    Are you sure you want to logout?
  </Content>
</SemModalConfirmation>
```

---

## SemMessage

**Inherits:** `SemControlBase`

A message/alert component.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | null | Custom content |
| Header | string | null | Message header |
| Message | string | null | Message text |
| Icon | Icon? | null | Message icon |
| Color | MessageColor? | null | Message color |
| Size | Size? | null | Message size |
| Classes | MessageClass[] | null | Additional CSS classes |

### MessageColor Options
`Info`, `Positive`, `Warning`, `Negative`, `Red`, `Orange`, `Yellow`, `Olive`, `Green`, `Teal`, `Blue`, `Violet`, `Purple`, `Pink`, `Brown`, `Grey`, `Black`

### MessageClass Options
`Floating`, `Compact`, `Top_Attached`, `Bottom_Attached`

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| Show() | void | Show the message |
| Show(message, color, icon?) | void | Show with parameters |
| Show(message, header, color, icon?) | void | Show with header |
| Hide() | void | Hide the message |

### Examples

**Static messages:**
```razor
<SemMessage Color="MessageColor.Info">
  This is an informational message.
</SemMessage>

<SemMessage Color="MessageColor.Positive" Header="Success">
  Operation completed successfully!
</SemMessage>

<SemMessage Color="MessageColor.Warning" Icon="Icon.Exclamation_Triangle">
  Please review your input before continuing.
</SemMessage>

<SemMessage Color="MessageColor.Negative" Header="Error" Icon="Icon.Times_Circle">
  An error occurred while processing your request.
</SemMessage>
```

**With custom content:**
```razor
<SemMessage Color="MessageColor.Info">
  <div class="header">Welcome!</div>
  <p>Thank you for signing up. Here's what you can do next:</p>
  <ul class="list">
    <li>Complete your profile</li>
    <li>Explore the dashboard</li>
    <li>Invite your team</li>
  </ul>
</SemMessage>
```

**Programmatic control:**
```razor
<SemMessage @ref="statusMessage"></SemMessage>

<SemButton OnClick="SaveItem">Save</SemButton>

@code {
    SemMessage statusMessage;

    async Task SaveItem() {
        try {
            await itemService.SaveAsync(item);
            statusMessage.Show("Item saved successfully!", MessageColor.Positive, Icon.Check_Circle);
        }
        catch (Exception ex) {
            statusMessage.Show(ex.Message, "Error", MessageColor.Negative, Icon.Exclamation_Circle);
        }
    }
}
```

**Compact and floating:**
```razor
<SemMessage Color="MessageColor.Info"
            Classes="@(new[] { MessageClass.Compact, MessageClass.Floating })">
  Quick notification
</SemMessage>
```

---

## NotificationPanel

**Inherits:** `SemControlBase`

A notification panel that displays toast-like notifications.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ClearAllText | string | "Clear all" | Clear all button text |

### Setup

**1. Register the service in Program.cs:**
```csharp
builder.Services.AddScoped<NotificationService>();
```

**2. Add the panel to your layout (e.g., MainLayout.razor):**
```razor
@inherits LayoutComponentBase

<div class="page">
  @Body
</div>

<NotificationPanel></NotificationPanel>
```

**3. Inject and use the service in components:**
```razor
@inject NotificationService NotificationService

<SemButton OnClick="ShowNotification">Show Notification</SemButton>

@code {
    void ShowNotification() {
        NotificationService.Show(new NotificationModel {
            Title = "Success",
            Message = "Item has been saved successfully.",
            Color = "green",
            Icon = Icon.Check_Circle,
            Expiration = DateTime.Now.AddSeconds(5)
        });
    }
}
```

### NotificationModel

```csharp
public class NotificationModel
{
    public string Id { get; set; }          // Auto-generated if not set
    public string Title { get; set; }        // Notification title
    public string Message { get; set; }      // Notification body (supports HTML)
    public string Color { get; set; }        // CSS color class (green, red, blue, etc.)
    public Icon? Icon { get; set; }          // Optional icon
    public DateTime Expiration { get; set; } // When to auto-hide
}
```

### Complete Example

```razor
@inject NotificationService Notifications

<SemButton OnClick="SaveItem" Color="ButtonColor.Positive">Save</SemButton>
<SemButton OnClick="DeleteItem" Color="ButtonColor.Negative">Delete</SemButton>

@code {
    async Task SaveItem() {
        try {
            await service.SaveAsync(item);
            Notifications.Show(new NotificationModel {
                Title = "Saved",
                Message = "Your changes have been saved.",
                Color = "green",
                Icon = Icon.Check,
                Expiration = DateTime.Now.AddSeconds(3)
            });
        }
        catch (Exception ex) {
            Notifications.Show(new NotificationModel {
                Title = "Error",
                Message = ex.Message,
                Color = "red",
                Icon = Icon.Exclamation_Triangle,
                Expiration = DateTime.Now.AddSeconds(10)
            });
        }
    }

    async Task DeleteItem() {
        await service.DeleteAsync(item.Id);
        Notifications.Show(new NotificationModel {
            Title = "Deleted",
            Message = "Item has been removed.",
            Color = "orange",
            Icon = Icon.Trash,
            Expiration = DateTime.Now.AddSeconds(3)
        });
    }
}
```
