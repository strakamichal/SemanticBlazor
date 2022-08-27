using System;
using System.Linq;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.Common;

namespace SemanticBlazor.Components.Base.Dropdown
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
      if (Value != null)
      /*if (typeof(ValueType) != typeof(Int32) && Value != null || typeof(ValueType) == typeof(Int32))*/
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
      if (Value != null)
      {
        SelectedItem = GetItemFromValue(Value);
      }
      if (Items != null)
      {
        if (Items.Any(i => GetItemKey(i) == GetItemKey(GetItemFromValue(Value))))
        {
          lastStringValue = ""; // Pokud se položky změnili, tak se hodnota zřejmě nastavila špatně - vynutíme nastavení nové
          guiValueChangeInprogress = false; // Pokud právě probíhá nastvení položek v GUI tak na to kašleme a stejně nastavíme znovu
          //await SetComboboxValue(); Tohle volat nemusíme, zavolá se samo při OnParametersSetAsync
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
