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
    public Func<ItemType, ValueType> ValueSelector { get; set; }
    [Parameter] public int? MaxSelections { get; set; }
    [Parameter] public bool UseLabels { get; set; } = true;

    protected SemDataSelectControlHelper<ValueType, ItemType> selectControlHelper = new SemDataSelectControlHelper<ValueType, ItemType>();
    protected ItemType GetItemFromValue(ValueType value) => selectControlHelper.GetItemFromValue(value, Items, ValueSelector);
    protected override string GetItemText(ItemType item) => selectControlHelper.GetItemText(item, ItemText);
    protected override string GetItemKey(ItemType item) => selectControlHelper.GetItemKey(item, Items, ItemKey);

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
          return String.Join(",", Value.Select(i => selectControlHelper.GetItemKey(selectControlHelper.GetItemFromValue(i, Items, ValueSelector), Items, ItemKey)));
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

      if (ValueSelector != null)
      {
        var retval = new List<ValueType>();
        selectedItems.ForEach(i =>
        {
          retval.Add(ValueSelector.Invoke(i));
        });
        return retval;
      }
      else if (typeof(ItemType) == typeof(ListItem))
      {
        if (typeof(ValueType).BaseType != null && typeof(ValueType).BaseType == typeof(Enum))
        {
          return vals.Select(e => (ValueType)Enum.Parse(typeof(ValueType), e)).ToList();
        }
        else
        {
          return vals.Select(e => (ValueType)Convert.ChangeType(e, typeof(ValueType))).ToList();
        }
      }
      else
      {

        try
        {
          return (List<ValueType>)Convert.ChangeType(selectedItems, typeof(List<ValueType>));
        }
        catch (Exception err)
        {
          throw new Exception("Cannot convert selected item to defined ValueType, please specify ValueSelector.", err);
        }
      }
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
