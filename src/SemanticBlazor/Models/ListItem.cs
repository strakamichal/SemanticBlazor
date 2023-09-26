using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticBlazor.Models
{
  public class ListItem : IEquatable<ListItem>
  {
    public string Value { get; set; }
    public string Text { get; set; }
    public object Model { get; set; }

    public override string ToString()
    {
      return !string.IsNullOrEmpty(Value) ? Value : Text;
    }

    public bool Equals(ListItem other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Value == other.Value && Text == other.Text && Equals(Model, other.Model);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ListItem) obj);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Value, Text, Model);
    }
  }
}
