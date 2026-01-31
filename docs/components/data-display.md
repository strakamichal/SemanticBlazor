# Data Display Components

## SemDataTable<TItem>

**Inherits:** `SemListBase<TItem>`

A data table with sorting, paging, and templating support.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Items | IEnumerable<TItem> | null | Static items |
| DataMethod | Func<DataMethodParams, Task<IEnumerable<TItem>>> | null | Async data method |
| CountMethod | Func<Task<int>> | null | Total count method (server paging) |
| Columns | RenderFragment | - | Column definitions |
| Header | RenderFragment | null | Custom header template |
| RowTemplate | RenderFragment<TItem> | null | Custom row template |
| AllowSorting | bool | false | Enable column sorting |
| AllowPaging | bool | false | Enable pagination |
| DefaultPageSize | int | 5 | Items per page |
| ShowHeader | bool | true | Show table header |
| RowClass | string | null | CSS class for all rows |
| RowClassFunc | Func<TItem, string> | null | Function to get row class |
| SegmentClass | string | "basic" | Wrapper segment class |
| EmptyDataMessage | string | "No records..." | Message when empty |

### Methods

| Method | Returns | Description |
|--------|---------|-------------|
| RefreshData(bool) | Task | Reload data, optionally reset paging |
| Sort(string) | Task | Sort by expression |

### Examples

**Basic table:**
```razor
<SemDataTable Items="users">
  <Columns>
    <SemDataTableColumn TItem="User" HeaderText="Name" ItemText="u => u.Name"></SemDataTableColumn>
    <SemDataTableColumn TItem="User" HeaderText="Email" ItemText="u => u.Email"></SemDataTableColumn>
  </Columns>
</SemDataTable>
```

**With paging (client-side):**
```razor
<SemDataTable Items="products" AllowPaging="true" DefaultPageSize="10">
  <Columns>
    <SemDataTableColumn TItem="Product" HeaderText="Name" ItemText="p => p.Name"></SemDataTableColumn>
    <SemDataTableColumn TItem="Product" HeaderText="Price" ItemText="p => p.Price.ToString(\"C\")"></SemDataTableColumn>
  </Columns>
</SemDataTable>
```

**With server-side paging:**
```razor
<SemDataTable TItem="Order"
              DataMethod="LoadOrders"
              CountMethod="CountOrders"
              AllowPaging="true"
              DefaultPageSize="20">
  <Columns>
    <SemDataTableColumn TItem="Order" HeaderText="ID" ItemText="o => o.Id.ToString()"></SemDataTableColumn>
    <SemDataTableColumn TItem="Order" HeaderText="Date" ItemText="o => o.Date.ToShortDateString()"></SemDataTableColumn>
  </Columns>
</SemDataTable>

@code {
    async Task<IEnumerable<Order>> LoadOrders(DataMethodParams p) {
        return await orderService.GetPagedAsync(p.StartRowIndex, p.MaximumRows, p.SortExpression, p.SortDirection);
    }

    async Task<int> CountOrders() {
        return await orderService.CountAsync();
    }
}
```

**With sorting:**
```razor
<SemDataTable Items="products" AllowSorting="true">
  <Columns>
    <SemDataTableColumn TItem="Product" HeaderText="Name" ItemText="p => p.Name" SortExpression="Name"></SemDataTableColumn>
    <SemDataTableColumn TItem="Product" HeaderText="Price" ItemText="p => p.Price.ToString(\"C\")" SortExpression="Price"></SemDataTableColumn>
  </Columns>
</SemDataTable>
```

**Custom cell template:**
```razor
<SemDataTable Items="users">
  <Columns>
    <SemDataTableColumn TItem="User" HeaderText="Name" ItemText="u => u.Name"></SemDataTableColumn>
    <SemDataTableColumn TItem="User" HeaderText="Status">
      <ItemTemplate>
        <SemLabel Color="@(context.IsActive ? Color.Green : Color.Red)">
          @(context.IsActive ? "Active" : "Inactive")
        </SemLabel>
      </ItemTemplate>
    </SemDataTableColumn>
    <SemDataTableColumn TItem="User" HeaderText="Actions">
      <ItemTemplate>
        <SemButton Size="Size.Mini" Icon="Icon.Edit" OnClick="() => Edit(context)"></SemButton>
        <SemButton Size="Size.Mini" Icon="Icon.Trash" Color="ButtonColor.Red" OnClick="() => Delete(context)"></SemButton>
      </ItemTemplate>
    </SemDataTableColumn>
  </Columns>
</SemDataTable>
```

**Custom row template:**
```razor
<SemDataTable Items="items">
  <Header>
    <tr>
      <th>Name</th>
      <th>Description</th>
      <th>Actions</th>
    </tr>
  </Header>
  <RowTemplate>
    <tr class="@(context.IsHighlighted ? "warning" : "")">
      <td><strong>@context.Name</strong></td>
      <td>@context.Description</td>
      <td><SemButton Size="Size.Mini" OnClick="() => Select(context)">Select</SemButton></td>
    </tr>
  </RowTemplate>
</SemDataTable>
```

**Conditional row styling:**
```razor
<SemDataTable Items="orders" RowClassFunc="GetRowClass">
  ...
</SemDataTable>

@code {
    string GetRowClass(Order order) {
        return order.Status switch {
            "Pending" => "warning",
            "Cancelled" => "negative",
            "Completed" => "positive",
            _ => ""
        };
    }
}
```

---

## SemDataTableColumn<TItem>

A column definition for SemDataTable.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| HeaderText | string | null | Column header text |
| HeaderTemplate | RenderFragment | null | Custom header template |
| HeaderClass | string | null | Header cell CSS class |
| ItemText | Func<TItem, string> | null | Function to get cell text |
| ItemTemplate | RenderFragment<TItem> | null | Custom cell template |
| ItemClass | string | null | Cell CSS class |
| ItemClassFunc | Func<TItem, string> | null | Function to get cell class |
| SortExpression | string | null | Sort field name |

---

## SemDataList<TItem>

**Inherits:** `SemListBase<TItem>`

A flexible list component with multiple view types.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| Items | IEnumerable<TItem> | null | Static items |
| DataMethod | Func<DataMethodParams, Task<IEnumerable<TItem>>> | null | Async data method |
| ViewType | ListViewType | - | List/Items/Comments/Feed/Cards |
| ItemTemplate | RenderFragment<TItem> | - | Item template |
| PlaceHolderTemplate | RenderFragment | null | Loading placeholder |
| EmptyDataTemplate | RenderFragment | null | Empty state template |
| EmptyDataMessage | string | "No records..." | Empty message |
| LoadingMessage | string | "Loading..." | Loading message |
| PlaceHolderCount | int | 1 | Number of placeholders |
| AllowPaging | bool | false | Enable pagination |
| DefaultPageSize | int | 5 | Items per page |
| ScrollOnTopOnPageChanged | bool | true | Scroll on page change |

### ListViewType Options
`List`, `Items`, `Comments`, `Feed`, `Cards`, `Custom`

### Examples

**Items view:**
```razor
<SemDataList TItem="Article" Items="articles" ViewType="ListViewType.Items">
  <ItemTemplate>
    <SemDataListItem>
      <div class="content">
        <div class="header">@context.Title</div>
        <div class="description">@context.Summary</div>
      </div>
    </SemDataListItem>
  </ItemTemplate>
</SemDataList>
```

**Feed view:**
```razor
<SemDataList TItem="Activity" Items="activities" ViewType="ListViewType.Feed">
  <ItemTemplate>
    <SemDataListItem>
      <div class="label">
        <SemIcon Icon="Icon.User"></SemIcon>
      </div>
      <div class="content">
        <div class="summary">
          <strong>@context.UserName</strong> @context.Action
          <div class="date">@context.Date.ToRelativeTime()</div>
        </div>
      </div>
    </SemDataListItem>
  </ItemTemplate>
</SemDataList>
```

**With paging:**
```razor
<SemDataList TItem="Product" Items="products" ViewType="ListViewType.Items"
             AllowPaging="true" DefaultPageSize="10">
  <ItemTemplate>
    ...
  </ItemTemplate>
</SemDataList>
```

---

## SemDataListItem

**Inherits:** `SemControlBase`

An item within SemDataList. Automatically applies correct CSS class based on parent ViewType.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| ChildContent | RenderFragment | - | Item content |

---

## SemCards<TItem>

**Inherits:** `SemListBase<TItem>`

A card-based list view. Same parameters as SemDataList.

### Example

```razor
<SemCards TItem="Product" Items="products" AllowPaging="true" DefaultPageSize="12">
  <ItemTemplate>
    <div class="card">
      <div class="image">
        <img src="@context.ImageUrl">
      </div>
      <div class="content">
        <div class="header">@context.Name</div>
        <div class="meta">@context.Category</div>
        <div class="description">@context.Description</div>
      </div>
      <div class="extra content">
        <span class="right floated">@context.Price.ToString("C")</span>
      </div>
    </div>
  </ItemTemplate>
</SemCards>
```

---

## SemPagination

**Inherits:** `SemControlBase`

A standalone pagination control.

### Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| TotalPages | int | - | Total number of pages |
| PageIndex | int | - | Current page (0-based) |
| PageIndexChanged | EventCallback<int> | - | Page change callback |
| Color | Color? | null | Pagination color |
| Size | Size? | null | Pagination size |

### Example

```razor
<SemPagination TotalPages="totalPages"
               PageIndex="currentPage"
               PageIndexChanged="HandlePageChange"
               Color="Color.Blue">
</SemPagination>

@code {
    int currentPage = 0;
    int totalPages = 10;

    void HandlePageChange(int newPage) {
        currentPage = newPage;
        LoadData();
    }
}
```

---

## DataMethodParams

Parameters passed to DataMethod for server-side operations.

```csharp
public class DataMethodParams
{
    public int StartRowIndex { get; set; }
    public int MaximumRows { get; set; }
    public string SortExpression { get; set; }
    public string SortDirection { get; set; } // "ASC" or "DESC"
}
```

### Usage
```razor
async Task<IEnumerable<Order>> LoadOrders(DataMethodParams p) {
    return await _context.Orders
        .OrderBy($"{p.SortExpression} {p.SortDirection}")
        .Skip(p.StartRowIndex)
        .Take(p.MaximumRows)
        .ToListAsync();
}
```
