using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;

namespace SemanticBlazor.Components.Base.Common
{
  // Used for data-binded Select controls
  public class SemSelectControlBase<TItem, TValue> : SemInputControlBase<TValue>
  {
    [Parameter] public virtual RenderFragment<object> ItemTemplate { get; set; }
    public virtual IEnumerable<TItem> Items { get; set; } = new List<TItem>();
    private IEnumerable<TItem> LatestItems { get; set; } = new List<TItem>();
    public virtual TItem SelectedItem { get; set; }
    public virtual List<TItem> SelectedItems { get; set; }
    public virtual Func<TItem, object> ItemKey { get; set; }
    public virtual Func<TItem, string> ItemText { get; set; }
    public virtual Func<Task<IEnumerable<TItem>>> DataMethod { get; set; }
    public virtual RenderFragment ListItems { get; set; }
    private bool _itemsSet;
    protected bool Loading;

    protected override async Task OnInitializedAsync()
    {
      await RefreshItems();
      _itemsSet = Items != null && Items.Any();
      LatestItems = Items;
      await base.OnInitializedAsync();

    }
    protected override async Task OnParametersSetAsync()
    {
      if (LatestItems == null || !LatestItems.SequenceEqual(Items ?? new List<TItem>()))
      {
        LatestItems = Items;
        if (DataMethod == null)
        {
          await ItemsLoaded();
        }
      }
      await base.OnParametersSetAsync();
    }
    public async Task RefreshItems()
    {
      if (DataMethod != null)
      {
        SetLoadingState(true);
        Items = await DataMethod.Invoke();
        SetLoadingState(false);
        await ItemsLoaded();
      }
    }
    internal override void RegisterChildControl(object control)
    {
      if (control.GetType() == typeof(SemSelectListItem))
      {
        if (_itemsSet)
        {
          throw new Exception("ListItems cannot be set via SemSelectListItem. Items are already set via Items or DataMethod parameter.");
        }
        if (Items == null) Items = new List<TItem>();
        ((List<ListItem>)Items).Add(new ListItem() { Text = ((SemSelectListItem)control).Text, Value = ((SemSelectListItem)control).Value });
        StateHasChanged();
      }
    }
    public void SetLoadingState(bool isLoading)
    {
      Loading = isLoading;
      StateHasChanged();
    }
    protected virtual async Task ItemsLoaded()
    {
      await Task.CompletedTask;
    }

    protected virtual string GetItemText(TItem item) => throw new NotImplementedException();
    protected virtual string GetItemKey(TItem item) => throw new NotImplementedException();
    protected TItem GetItem(object value)
    {
      return Items.FirstOrDefault(i => GetItemKey(i) == value.ToString());
    }
  }
}