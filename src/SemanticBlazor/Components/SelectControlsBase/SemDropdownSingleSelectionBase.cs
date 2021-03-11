using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components.SelectControlsBase
{
  public class SemDropdownSingleSelectionBase<ItemType, ValueType> : SemDropdownSelectionBase<ItemType, ValueType>
  {
    public virtual Func<ItemType, ValueType> ValueSelector { get; set; }

    protected ItemType GetItemFromValue(ValueType value) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemFromValue(value, Items, ValueSelector);
    protected override object ConvertValue(object newValue) => SemDataSelectControlHelper<ItemType, ValueType>.ConvertValue(newValue, Items, ItemKey, ValueSelector);
    protected override string GetItemText(ItemType item) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemText(item, ItemText);
    protected override string GetItemKey(ItemType item) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemKey(item, Items, ItemKey);

    protected override async Task OnParametersSetAsync()
    {
      if (Value != null)
      {
        SelectedItem = GetItemFromValue(Value);
      }
      else
      {
        SelectedItem = default(ItemType);
      }
      await base.OnParametersSetAsync();
    }

    protected override string stringValue
    {
      get
      {
        return Value != null ? GetItemKey(GetItemFromValue(Value)) : "";
      }
    }
    protected override async Task SetComboboxValue()
    {
      if ((typeof(ValueType) != typeof(Int32) && Value != null) || (typeof(ValueType) == typeof(Int32) && Value.ToString() != "0"))
      {
        await SemanticBlazor.JsFunc.DropDown.SetValue(js, Id, GetItemKey(GetItemFromValue(Value)));
      }
      else
      {
        await SemanticBlazor.JsFunc.DropDown.Clear(js, Id);
      }
    }
    protected override async Task ItemsLoaded()
    {
      await SemanticBlazor.JsFunc.DropDown.Init(js, Id, initSettings);
      if (Items != null)
      {
        if (Items.Any(i => GetItemKey(i) == GetItemKey(SelectedItem)))
        {
          await SetComboboxValue();
        }
        else if (Value != null && !Value.Equals(default(ValueType)))
        {
          await ClearValue();
        }
      }
    }
    public override async Task ClearValue()
    {
      await SemanticBlazor.JsFunc.DropDown.Clear(js, Id);
      await base.ClearValue();
    }

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}
