using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticBlazor.Components.SelectControlsBase
{
  public class SemDataSelectControlHelper<ValueType, ItemType>
  {
    public virtual IEnumerable<ItemType> Items { get; set; } = new List<ItemType>();
    public virtual Func<ItemType, object> ItemKey { get; set; }
    public virtual Func<ItemType, string> ItemText { get; set; }
    public virtual Func<ItemType, ValueType> ValueSelector { get; set; }

    public SemDataSelectControlHelper() { }
    public SemDataSelectControlHelper(IEnumerable<ItemType> items, Func<ItemType, object> itemKey, Func<ItemType, string> itemText, Func<ItemType, ValueType> valueSelector)
    {
      this.Items = items;
      this.ItemKey = itemKey;
      this.ItemText = itemText;
      this.ValueSelector = valueSelector;
    }

    public ItemType GetItemFromValue(ValueType value)
    {
      if (Items != null && value != null)
      {
        if (ValueSelector != null)
        {
          return Items.FirstOrDefault(i => ValueSelector.Invoke(i).Equals(value));
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return Items.FirstOrDefault(i => i.ToString() == value.ToString());
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
    public string GetItemText(ItemType item)
    {
      if (item != null)
      {
        if (ItemText != null)
        {
          return ItemText?.Invoke(item);
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return ((ListItem)Convert.ChangeType(item, typeof(ListItem))).Text;
        }
        else
        {
          return item.ToString();
        }
      }
      else
      {
        return null;
      }
    }
    public string GetItemKey(ItemType item)
    {
      if (item != null && Items != null)
      {
        if (ItemKey != null)
        {
          return ItemKey?.Invoke(item).ToString();
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return item.ToString();
        }
        else
        {
          return Items.ToList().IndexOf(item).ToString();
        }
      }
      else
      {
        return null;
      }
    }
    public object ConvertValue(object newValue)
    {
      var item = Items.FirstOrDefault(i => GetItemKey(i) == newValue.ToString());
      if (ValueSelector != null)
      {
        return ValueSelector.Invoke(item);
      }
      else
      {
        if (typeof(ItemType) == typeof(ListItem))
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
            return (ValueType)Convert.ChangeType(item, typeof(ValueType));
          }
          catch (Exception err)
          {
            throw new Exception("Cannot convert selected item to defined ValueType, please specify ValueSelector.", err);
          }
        }
      }
    }

    public static ItemType GetItemFromValue(ValueType value, IEnumerable<ItemType> items, Func<ItemType, ValueType> valueSelector)
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
    public static string GetItemText(ItemType item, Func<ItemType, string> itemText)
    {
      if (item != null)
      {
        if (itemText != null)
        {
          return itemText?.Invoke(item);
        }
        else if (typeof(ItemType) == typeof(ListItem))
        {
          return ((ListItem)Convert.ChangeType(item, typeof(ListItem))).Text;
        }
        else
        {
          return item.ToString();
        }
      }
      else
      {
        return null;
      }
    }
    public static string GetItemKey(ItemType item, IEnumerable<ItemType> items, Func<ItemType, object> itemKey)
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
    public static object ConvertValue(object newValue, IEnumerable<ItemType> items, Func<ItemType, object> itemKey, Func<ItemType, ValueType> valueSelector)
    {
      var item = items.FirstOrDefault(i => GetItemKey(i, items, itemKey) == newValue.ToString());
      if (valueSelector != null)
      {
        return valueSelector.Invoke(item);
      }
      else
      {
        if (typeof(ItemType) == typeof(ListItem))
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
            return (ValueType)Convert.ChangeType(item, typeof(ValueType));
          }
          catch (Exception err)
          {
            throw new Exception("Cannot convert selected item to defined ValueType, please specify ValueSelector.", err);
          }
        }
      }
    }
  }
}
