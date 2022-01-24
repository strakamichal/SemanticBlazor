using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components.SelectControlsBase
{
  // Used for data-binded Select controls
  public class SemSelectControlBase<ItemType, ValueType> : SemInputControlBase<ValueType>
  {
    [Parameter] public virtual RenderFragment<object> ItemTemplate { get; set; }
    public virtual IEnumerable<ItemType> Items { get; set; } = new List<ItemType>();
    IEnumerable<ItemType> latestItems { get; set; } = new List<ItemType>();
    public virtual ItemType SelectedItem { get; set; }
    public virtual List<ItemType> SelectedItems { get; set; }
    public virtual Func<ItemType, object> ItemKey { get; set; }
    public virtual Func<ItemType, string> ItemText { get; set; }
    public virtual Func<Task<IEnumerable<ItemType>>> DataMethod { get; set; }
    public virtual RenderFragment ListItems { get; set; }
    protected bool itemsSet { get; set; } = false;
    protected bool loading { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await RefreshItems();
      itemsSet = Items != null && Items.Any();
      latestItems = Items;
      await base.OnInitializedAsync();

    }
    protected override async Task OnParametersSetAsync()
    {
      if (latestItems != Items && (latestItems == null || (!latestItems.SequenceEqual(Items ?? new List<ItemType>()))))
      {
        latestItems = Items;
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
        if (itemsSet)
        {
          throw new Exception("ListItems cannot be set via SemSelectListItem. Items are already set via Items or DataMethod parameter.");
        }
        if (Items == null) Items = new List<ItemType>();
        ((List<ListItem>)Items).Add(new ListItem() { Text = ((SemSelectListItem)control).Text, Value = ((SemSelectListItem)control).Value });
        StateHasChanged();
      }
    }
    public void SetLoadingState(bool isLoading)
    {
      this.loading = isLoading;
      StateHasChanged();
    }
    protected virtual async Task ItemsLoaded()
    {
      await Task.CompletedTask;
    }

    protected virtual string GetItemText(ItemType item) => throw new NotImplementedException();
    protected virtual string GetItemKey(ItemType item) => throw new NotImplementedException();
    protected ItemType GetItem(object value)
    {
      return Items.FirstOrDefault(i => GetItemKey(i) == value.ToString());
    }
  }
}