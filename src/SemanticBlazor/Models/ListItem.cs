using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticBlazor.Models
{
  public class ListItem
  {
    public string Value { get; set; }
    public string Text { get; set; }
    public object Model { get; set; }

    public override string ToString()
    {
      return !string.IsNullOrEmpty(this.Value) ? this.Value : this.Text;
    }
  }
}
