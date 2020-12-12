using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticBlazor.Components.SelectControlsBase
{
  public class SemDataSelectControlHelper<ValueType, ItemType>
  {
    //public ValueType ConvertValue(object newValue, IEnumerable<ItemType> items, Func<ItemType, ValueType> valueSelector, Func<ItemType, object> itemKey)
    //{
    //  var selectedItem = items.FirstOrDefault(i => GetItemKey(i, items, itemKey) == newValue.ToString());
    //  if (valueSelector == null)
    //  {
    //    try
    //    {
    //      return (ValueType)Convert.ChangeType(selectedItem, typeof(ValueType));
    //    }
    //    catch (Exception err)
    //    {
    //      throw new Exception("Cannot convert selected item to defined ValueType, please specify ValueSelector.", err);
    //    }
    //  }
    //  else
    //  {
    //    return valueSelector.Invoke(selectedItem);
    //  }
    //}
    public ItemType GetItemFromValue(ValueType value, IEnumerable<ItemType> items, Func<ItemType, ValueType> valueSelector)
    {
      if (items != null && value != null)
      {
        if (valueSelector != null)
        {
          return items.FirstOrDefault(i => valueSelector.Invoke(i).Equals(value));
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return items.FirstOrDefault(i => i.ToString() == value.ToString());
        }
        else
        {
          try
          {
            return (ItemType)Convert.ChangeType(value, typeof(ItemType));
          }
          catch (Exception err)
          {
            throw new Exception("Cannot convert value to ItemType, please specify ValueSelector.", err);
          }
        }
      }
      else
      {
        return default(ItemType);
      }
    }
    public string GetItemText(ItemType item, Func<ItemType, string> itemText)
    {
      if (item != null)
      {
        if (itemText == null)
        {
          return item.ToString();
        }
        else
        {
          return itemText?.Invoke(item);
        }
      }
      else
      {
        return null;
      }
    }
    public string GetItemKey(ItemType item, IEnumerable<ItemType> items, Func<ItemType, object> itemKey)
    {
      if (item != null && items != null)
      {
        if (itemKey != null)
        {
          return itemKey?.Invoke(item).ToString();
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return item.ToString();
        }
        else
        {
          return items.ToList().IndexOf(item).ToString();
        }
      }
      else
      {
        return null;
      }
    }
  }
}
