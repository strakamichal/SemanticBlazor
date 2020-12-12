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
  public class SemSelectControlBase<ValueType, ItemType> : SemInputControlBase<ValueType>
  {
    [Parameter] public virtual RenderFragment<object> ItemTemplate { get; set; }
    public virtual IEnumerable<ItemType> Items { get; set; } = new List<ItemType>();
    public virtual Func<ItemType, object> ItemKey { get; set; }
    public virtual Func<ItemType, string> ItemText { get; set; }
    public virtual Func<Task<List<ItemType>>> DataMethod { get; set; }
    public virtual RenderFragment ListItems { get; set; }
    protected bool itemsSet { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
      if (DataMethod != null)
      {
        Items = await DataMethod.Invoke();
      }
      itemsSet = Items != null && Items.Any();
      await base.OnInitializedAsync();
    }
    public async Task RefreshItems()
    {
      if (DataMethod != null)
      {
        Items = await DataMethod.Invoke();
      }
    }
    internal override void RegistedChildControl(object control)
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

    protected virtual string GetItemText(ItemType item) => throw new NotImplementedException();
    protected virtual string GetItemKey(ItemType item) => throw new NotImplementedException();
    protected ItemType GetItem(object value)
    {
      return Items.FirstOrDefault(i => GetItemKey(i) == value.ToString());
    }
  }
}