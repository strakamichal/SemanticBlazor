using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using SemanticBlazor.Components.Base.Common;

namespace SemanticBlazor.Components.Base.Dropdown
{
  public class SemDropdownSingleSelectionBase<TItem, TValue> : SemDropdownSelectionBase<TItem, TValue>
  {
    public virtual Func<TItem, TValue> ValueSelector { get; set; }

    private TItem GetItemFromValue(TValue value) => SemDataSelectControlHelper<TItem, TValue>.GetItemFromValue(value, Items, ValueSelector);
    protected override object ConvertValue(object newValue) => SemDataSelectControlHelper<TItem, TValue>.ConvertValue(newValue, Items, ItemKey, ValueSelector);
    protected override string GetItemText(TItem item) => SemDataSelectControlHelper<TItem, TValue>.GetItemText(item, ItemText);
    protected override string GetItemKey(TItem item) => SemDataSelectControlHelper<TItem, TValue>.GetItemKey(item, Items, ItemKey);

    protected override async Task OnParametersSetAsync()
    {
      SelectedItem = Value != null ? GetItemFromValue(Value) : default(TItem);
      await base.OnParametersSetAsync();
    }

    protected override string StringValue => Value != null ? GetItemKey(GetItemFromValue(Value)) : "";

    protected override async Task SetComboboxValue()
    {
      if (Rendered)
      {
        if (Value != null)
        {
          await JsFunc.DropDown.SetValue(JsRuntime, Id, GetItemKey(GetItemFromValue(Value)));
        }
        else
        {
          await JsFunc.DropDown.Clear(JsRuntime, Id);
        }
      }
    }

    protected override async Task ItemsLoaded()
    {
      await Init(InitSettings);
      if (Value != null)
      {
        SelectedItem = GetItemFromValue(Value);
      }
      if (Items != null)
      {
        if (AllowAdditionsProtected) TryAddMissingItems(StringValue);
        if (Items.Any(i => GetItemKey(i) == GetItemKey(GetItemFromValue(Value))))
        {
          LastStringValue = ""; // Pokud se položky změnili, tak se hodnota zřejmě nastavila špatně - vynutíme nastavení nové
          GuiValueChangeInprogress = false; // Pokud právě probíhá nastvení položek v GUI tak na to kašleme a stejně nastavíme znovu
          //await SetComboboxValue(); Tohle volat nemusíme, zavolá se samo při OnParametersSetAsync
        }
        else if (Value != null && !Value.Equals(default(TValue)))
        {
          await ClearValue();
        }
      }
    }

    protected override void TryAddMissingItems(string newValue)
    {
      var items = Items.ToList();
      //Smazat dříve přidanou položku
      items.RemoveAll(i => UserAddedItems.Any(ai => ai.Equals(i)));
      UserAddedItems.Clear();
      if (Items.All(i => i.ToString() != newValue))
      {
        var item = (TItem) Convert.ChangeType(newValue, typeof(TItem));
        items.Add(item);
        UserAddedItems.Add(item);
      }
      Items = items;
      StateHasChanged();
    }

    public override async Task ClearValue()
    {
      if (Rendered)
      {
        await JsFunc.DropDown.Clear(JsRuntime, Id);
      }
      await base.ClearValue();
    }
  }
}