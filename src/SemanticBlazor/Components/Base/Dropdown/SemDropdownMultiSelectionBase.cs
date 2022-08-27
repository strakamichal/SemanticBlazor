using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base.Common;
using SemanticBlazor.Mappers;

namespace SemanticBlazor.Components.Base.Dropdown
{
  public class SemDropdownMultiSelectionBase<TItem, TValue> : SemDropdownSelectionBase<TItem, List<TValue>>
  {
    public virtual Func<TItem, TValue> ValueSelector { get; set; }
    [Parameter] public int? MaxSelections { get; set; }
    [Parameter] public bool UseLabels { get; set; } = true;

    private TItem GetItemFromValue(TValue value) => SemDataSelectControlHelper<TItem, TValue>.GetItemFromValue(value, Items, ValueSelector);
    protected override string GetItemText(TItem item) => SemDataSelectControlHelper<TItem, TValue>.GetItemText(item, ItemText);
    protected override string GetItemKey(TItem item) => SemDataSelectControlHelper<TItem, TValue>.GetItemKey(item, Items, ItemKey);
    protected override Dictionary<string, object> InitSettings
    {
      get
      {
        var retval = base.InitSettings;
        retval.Add("useLabels", UseLabels && !IsButton);
        if (MaxSelections != null) retval.Add("maxSelections", MaxSelections);
        return retval;
      }
    }
    protected override string StringValue
    {
      get { return Value != null ? string.Join(",", Value.Select(i => GetItemKey(GetItemFromValue(i)))) : ""; }
    }

    public SemDropdownMultiSelectionBase()
    {
      ClassMapper
        .Add("multiple");
    }

    protected override async Task OnParametersSetAsync()
    {
      SelectedItems = Value?.Select(GetItemFromValue).ToList();
      await base.OnParametersSetAsync();
    }

    protected override object ConvertValue(object newValue)
    {
      var vals = newValue.ToString().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
      return vals.ToList().Select(value => (TValue) SemDataSelectControlHelper<TItem, TValue>.ConvertValue(value, Items, ItemKey, ValueSelector)).ToList();
    }

    protected override async Task SetComboboxValue()
    {
      await JsFunc.Logging.ConsoleLog(JsRuntime, $"SetComboboxValue - {StringValue}");
      if (Value != null)
      {
        await JsFunc.DropDown.SetExactlyValue(JsRuntime, Id, StringValue);
      }
      else
      {
        await JsFunc.DropDown.Clear(JsRuntime, Id);
      }
    }

    protected override async Task ItemsLoaded()
    {
      await Init(InitSettings);
      if (Value != null)
      {
        SelectedItems = Value.Select(GetItemFromValue).ToList();
      }
      if (Items != null)
      {
        if (AllowAdditionsProtected)
        {
          TryAddMissingItems(StringValue);
        }
        var validKeys = Value?.Where(v => Items.Any(i => GetItemKey(i) == GetItemKey(GetItemFromValue(v)))).Select(v => GetItemKey(GetItemFromValue(v))).ToList();
        if (validKeys != null && validKeys.Count > 0)
        {
          LastStringValue = ""; // Pokud se položky změnili, tak se hodnota zřejmě nastavila špatně - vynutíme nastavení nové
          GuiValueChangeInprogress = false; // Pokud právě probíhá nastvení položek v GUI tak na to kašleme a stejně nastavíme znovu
          Value = (List<TValue>) ConvertValue(string.Join(",", validKeys));
          await NotifyChanged();
        }
        else if (Value != null)
        {
          await ClearValue();
        }
      }
    }

    protected override void TryAddMissingItems(string newValue)
    {
      var newValues = newValue.Split(","); 
      var items = Items.ToList();
      //Smazat dříve přidané položku
      items.RemoveAll(i => UserAddedItems.Any(ai => ai.Equals(i)));
      UserAddedItems.Clear();
      
      foreach (var key in newValues)
      {
        var item = (TItem) Convert.ChangeType(key, typeof(TItem));
        if (!items.Contains(item))
        {
          items.Add(item);
          UserAddedItems.Add(item);
        }
      }
      
      Items = items;
      StateHasChanged();
    }

    public override async Task ClearValue()
    {
      await JsFunc.DropDown.Clear(JsRuntime, Id);
      await base.ClearValue();
    }
  }
}