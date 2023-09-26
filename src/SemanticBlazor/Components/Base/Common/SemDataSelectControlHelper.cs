using System;
using System.Collections.Generic;
using System.Linq;
using SemanticBlazor.Models;

namespace SemanticBlazor.Components.Base.Common
{
  internal static class SemDataSelectControlHelper<TItem, TValue>
  {
    public static TItem GetItemFromValue(TValue value, IEnumerable<TItem> items, Func<TItem, TValue> valueSelector)
    {
      TItem retval = default(TItem);
      if (items != null && value != null)
      {
        if (valueSelector != null)
        {
          retval = items.FirstOrDefault(i => valueSelector.Invoke(i).Equals(value));
        }
        else if (typeof(TItem) == typeof(ListItem))
        {
          retval = items.FirstOrDefault(i => i.ToString() == value.ToString());
        }
        else
        {
          try
          {
            return (TItem)Convert.ChangeType(value, typeof(TItem));
          }
          catch (Exception err)
          {
            throw new Exception("Cannot convert value to TItem, please specify ValueSelector.", err);
          }
        }
      }
      return retval;
    }
    public static string GetItemText(TItem item, Func<TItem, string> itemText)
    {
      if (item != null)
      {
        if (itemText != null)
        {
          return itemText(item);
        }
        if (typeof(TItem) == typeof(ListItem))
        {
          ListItem liItem = ((ListItem)Convert.ChangeType(item, typeof(ListItem)));
          return liItem.Text ?? liItem.Value;
        }
        return item.ToString();
      }
      return null;
    }
    public static string GetItemKey(TItem item, IEnumerable<TItem> items, Func<TItem, object> itemKey)
    {
      string retval = null;
      if (item == null || items == null) return null;
      if (itemKey != null)
      {
        retval = itemKey(item).ToString();
      }
      else if (typeof(TItem) == typeof(ListItem))
      {
        retval = item.ToString();
      }
      else if (typeof(TItem) == typeof(string) || typeof(TItem) == typeof(int))
      {
        return item.ToString();
      }
      retval ??= item.GetHashCode().ToString();
      return retval;
    }
    public static object ConvertValue(object newValue, IEnumerable<TItem> items, Func<TItem, object> itemKey, Func<TItem, TValue> valueSelector)
    {
      var itemsList = items.ToList();
      var item = itemsList.FirstOrDefault(i => GetItemKey(i, itemsList, itemKey) == newValue.ToString());
      if (valueSelector != null)
      {
        return valueSelector.Invoke(item);
      }
      return typeof(TItem) == typeof(ListItem) ? TryChangeTypeOfList(newValue) : TryChangeType(item);
    }
    private static object TryChangeType(TItem item)
    {
      try
      {
        return (TValue) Convert.ChangeType(item, typeof(TValue));
      }
      catch (Exception err)
      {
        throw new Exception("Cannot convert selected item to defined TValue, please specify ValueSelector.", err);
      }
    }
    private static object TryChangeTypeOfList(object newValue)
    {
      if (typeof(TValue) == typeof(int?))
      {
        return string.IsNullOrEmpty(newValue.ToString()) ? (TValue) (object) null : (TValue) Convert.ChangeType(newValue, typeof(int));
      }
      if (typeof(TValue).BaseType != null && typeof(TValue).BaseType == typeof(Enum))
      {
        return (TValue) Enum.Parse(typeof(TValue), newValue.ToString());
      }
      return (TValue) Convert.ChangeType(newValue, typeof(TValue));
    }
  }
}
