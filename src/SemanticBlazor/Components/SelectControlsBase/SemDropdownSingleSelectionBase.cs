using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components.SelectControlsBase
{
  public class SemDropdownSingleSelectionBase<ValueType, ItemType> : SemDropdownSelectionBase<ValueType, ItemType>
  {
    public Func<ItemType, ValueType> ValueSelector { get; set; }
 
    protected SemDataSelectControlHelper<ValueType, ItemType> selectControlHelper = new SemDataSelectControlHelper<ValueType, ItemType>();
    protected ItemType GetItemFromValue(ValueType value) => selectControlHelper.GetItemFromValue(value, Items, ValueSelector);
    protected override string GetItemText(ItemType item) => selectControlHelper.GetItemText(item, ItemText);
    protected override string GetItemKey(ItemType item) => selectControlHelper.GetItemKey(item, Items, ItemKey);

    protected override string stringValue
    {
      get
      {
        return GetItemKey(GetItemFromValue(Value));
      }
    }
    protected override object ConvertValue(object newValue)
    {
      var selectedItem = Items.FirstOrDefault(i => GetItemKey(i) == newValue.ToString());
      if (ValueSelector != null)
      {
        return ValueSelector.Invoke(selectedItem);
      }
      else if (typeof(ItemType) == typeof(ListItem))
      {
        if (typeof(ValueType) == typeof(Nullable<int>))
        {
          return string.IsNullOrEmpty(newValue.ToString()) ? (ValueType)(object)null : (ValueType)Convert.ChangeType(newValue, typeof(int));
        }
        else if (typeof(ValueType).BaseType != null && typeof(ValueType).BaseType == typeof(Enum))
        {
          return (ValueType)Enum.Parse(typeof(ValueType), newValue.ToString());
        }
        else
        {
          return (ValueType)Convert.ChangeType(newValue, typeof(ValueType));
        }
      }
      else
      {
        try
        {
          return (ValueType)Convert.ChangeType(selectedItem, typeof(ValueType));
        }
        catch (Exception err)
        {
          throw new Exception("Cannot convert selected item to defined ValueType, please specify ValueSelector.", err);
        }
      }
    }
    protected override async Task SetComboboxValue()
    {
      if ((typeof(ValueType) != typeof(Int32) && Value != null) || (typeof(ValueType) == typeof(Int32) && Value.ToString() != "0"))
      {
        await SemanticBlazor.JsFunc.DropDown.SetValue(js, Id, Value.ToString());
      }
      else
      {
        await SemanticBlazor.JsFunc.DropDown.Clear(js, Id);
      }
    }

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}
