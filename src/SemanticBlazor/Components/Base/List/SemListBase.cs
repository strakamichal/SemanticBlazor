using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base.Common;
using SemanticBlazor.Models;

namespace SemanticBlazor.Components.Base.List
{
  public class SemListBase<TItem> : SemControlBase
  {
    private IEnumerable<TItem> AllItems { get; set; } = new List<TItem>();
    public IEnumerable<TItem> CurrentItems { get; private set; }
    [Parameter]
    public IEnumerable<TItem> Items
    {
      get => AllItems;
      set
      {
        if (DataMethod != null) throw new Exception("Items cannot be set when DataMethod is defined");
        if (Equals(AllItems, value)) return;
        AllItems = value;
        PageIndex = 0;
        GetData();
      }
    }
    [Parameter] public Func<DataMethodParams, Task<IEnumerable<TItem>>> DataMethod { get; set; }
    [Parameter] public Func<Task<int>> CountMethod { get; set; }
    [Parameter] public EventCallback<int> PageIndexChanged { get; set; }
    [Parameter] public EventCallback DataLoaded { get; set; }

    [Parameter] public bool AllowPaging { get; set; }
    [Parameter] public int DefaultPageSize { get; set; } = 5;
    [Parameter] public string SortExpression { get; set; }
    [Parameter] public string SortDirection { get; set; }

    private int _pageSize;
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    protected int PagerStart = 0;
    protected bool Loading;

    protected override async Task OnInitializedAsync()
    {
      PageIndex = 0;
      _pageSize = DefaultPageSize;
      await GetData();
    }

    public virtual async Task SetPageIndex(int newPageIndex)
    {
      PageIndex = newPageIndex;
      await PageIndexChanged.InvokeAsync(PageIndex);
      await GetData();
    }

    public void SetLoadingState(bool isLoading)
    {
      Loading = isLoading;
      StateHasChanged();
    }

    public async Task RefreshData(bool resetPaging = true)
    {
      Loading = true;
      if (resetPaging) PageIndex = 0;
      AllItems = null;
      await GetData();
    }

    private async Task GetData()
    {
      Loading = true;
      StateHasChanged();

      if (AllowPaging)
      {
        if (CountMethod != null)
        {
          // Pokud je definová metoda na count, tak se používá stránkování na serveru (API)
          var itemsCount = await CountMethod();
          TotalPages = (int) Math.Ceiling((decimal) itemsCount / _pageSize);
          CurrentItems = await CallDataMethod(new DataMethodParams() {StartRowIndex = PageIndex * _pageSize, MaximumRows = _pageSize, SortExpression = SortExpression, SortDirection = SortDirection});
        }
        else
        {
          // Pokud nneí definová metoda na count, tak se načtou všechna data a stránkuje se na klientovi
          if (DataMethod != null && (AllItems == null || !AllItems.Any()))
          {
            AllItems = await CallDataMethod(new DataMethodParams() {StartRowIndex = 0, MaximumRows = int.MaxValue, SortExpression = SortExpression, SortDirection = SortDirection});
          }
          if (AllItems != null)
          {
            var allItems = AllItems.ToList();
            TotalPages = (int) Math.Ceiling((decimal) allItems.Count() / _pageSize);
            CurrentItems = allItems.Skip(PageIndex * _pageSize).Take(_pageSize).ToList();
          }
        }
      }
      else
      {
        if (DataMethod != null) AllItems = await CallDataMethod(new DataMethodParams() {StartRowIndex = 0, MaximumRows = int.MaxValue, SortExpression = SortExpression, SortDirection = SortDirection});
        CurrentItems = AllItems;
      }
      Loading = false;
      await DataLoaded.InvokeAsync(null);
      StateHasChanged();
    }

    private async Task<IEnumerable<TItem>> CallDataMethod(DataMethodParams e)
    {
      return await DataMethod(e) ?? new List<TItem>();
    }
  }
}