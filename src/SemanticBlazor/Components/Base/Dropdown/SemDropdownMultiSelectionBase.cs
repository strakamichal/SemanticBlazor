using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base.Common;
using SemanticBlazor.Mappers;

namespace SemanticBlazor.Components.Base.Dropdown
{
  public class SemDropdownMultiSelectionBase<ItemType, ValueType> : SemDropdownSelectionBase<ItemType, List<ValueType>>
  {
    public virtual Func<ItemType, ValueType> ValueSelector { get; set; }
    [Parameter] public int? MaxSelections { get; set; }
    [Parameter] public bool UseLabels { get; set; } = true;

    protected ItemType GetItemFromValue(ValueType value) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemFromValue(value, Items, ValueSelector);
    protected override string GetItemText(ItemType item) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemText(item, ItemText);
    protected override string GetItemKey(ItemType item) => SemDataSelectControlHelper<ItemType, ValueType>.GetItemKey(item, Items, ItemKey);

    public SemDropdownMultiSelectionBase()
    {
      ClassMapper
        .Add("multiple");
    }
    protected override async Task OnParametersSetAsync()
    {
      if (Value != null)
      {
        SelectedItems = Value.Select(v => GetItemFromValue(v)).ToList();
      }
      else
      {
        SelectedItems = null;
      }
      await base.OnParametersSetAsync();
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

      return vals.ToList().Select(value => (ValueType)SemDataSelectControlHelper<ItemType, ValueType>.ConvertValue(value, Items, ItemKey, ValueSelector)).ToList();
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
    protected override async Task ItemsLoaded()
    {
      await SemanticBlazor.JsFunc.DropDown.Init(js, Id, initSettings);
      if (Value != null)
      {
        SelectedItems = Value.Select(v => GetItemFromValue(v)).ToList();
      }
      if (Items != null)
      {
        var validKeys = Value?.Where(v => Items.Any(i => GetItemKey(i) == GetItemKey(GetItemFromValue(v)))).Select(v => GetItemKey(GetItemFromValue(v))).ToList();
        if (validKeys != null && validKeys.Count > 0)
        {
          lastStringValue = ""; // Pokud se položky změnili, tak se hodnota zřejmě nastavila špatně - vynutíme nastavení nové
          guiValueChangeInprogress = false; // Pokud právě probíhá nastvení položek v GUI tak na to kašleme a stejně nastavíme znovu
          Value = (List<ValueType>)ConvertValue(string.Join(",", validKeys));
          await NotifyChanged();
          //await SetComboboxValue(); Tohle volat nemusíme, zavolá se samo při OnParametersSetAsync
        }
        else if (Value != null)
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
