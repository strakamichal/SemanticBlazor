using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.Dropdown;

namespace SemanticBlazor.Components
{
  public class SemDataDropdownMultiSelection<TItem, TValue> : SemDropdownMultiSelectionBase<TItem, TValue>
  {
    [Parameter] public override IEnumerable<TItem> Items { get; set; } = new List<TItem>();
    [Parameter] public override Func<TItem, TValue> ValueSelector { get; set; }
    [Parameter] public override Func<TItem, object> ItemKey { get; set; }
    [Parameter] public override Func<TItem, string> ItemText { get; set; }
    [Parameter] public override Func<Task<IEnumerable<TItem>>> DataMethod { get; set; }
  }
}
