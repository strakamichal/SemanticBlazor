using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components.SelectControlsBase
{
  public class SemDropdownMultiSelectionBase<ValueType, ItemType> : SemDropdownSelectionBase<List<ValueType>, ItemType>
  {
    public virtual Func<ItemType, ValueType> ValueSelector { get; set; }
    [Parameter] public int? MaxSelections { get; set; }
    [Parameter] public bool UseLabels { get; set; } = true;

    protected ItemType GetItemFromValue(ValueType value) => SemDataSelectControlHelper<ValueType, ItemType>.GetItemFromValue(value, Items, ValueSelector);
    protected override string GetItemText(ItemType item) => SemDataSelectControlHelper<ValueType, ItemType>.GetItemText(item, ItemText);
    protected override string GetItemKey(ItemType item) => SemDataSelectControlHelper<ValueType, ItemType>.GetItemKey(item, Items, ItemKey);

    public SemDropdownMultiSelectionBase()
    {
      ClassMapper
        .Add("multiple");
    }

    protected override Dictionary<string, object> initSettings
    {
      get
      {
        var retval = base.initSettings;
        retval.Add("useLabels", !UseLabels || IsButton ? false : true);
        if (MaxSelections != null) retval.Add("maxSelections", MaxSelections);
        return retval;
      }
    }
    protected override string stringValue
    {
      get
      {
        if (Value != null)
        {
          return String.Join(",", Value.Select(i => GetItemKey(GetItemFromValue(i))));
        }
        else
        {
          return "";
        }
      }
    }
    protected override object ConvertValue(object newValue)
    {
      List<ItemType> selectedItems = new List<ItemType>();
      var vals = newValue.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      selectedItems.AddRange(Items.Where(i => vals.Any(v => v == GetItemKey(i))));

      return vals.ToList().Select(value => (ValueType)SemDataSelectControlHelper<ValueType, ItemType>.ConvertValue(value, Items, ItemKey, ValueSelector)).ToList();
    }
    protected override async Task SetComboboxValue()
    {
      if (Value != null)
      {
        await SemanticBlazor.JsFunc.DropDown.SetExactlyValue(js, Id, stringValue);
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
