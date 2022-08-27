using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.CheckBoxList;

namespace SemanticBlazor.Components
{
  public class SemDataCheckboxList<TItem, TValue> : SemCheckboxListBase<TItem, TValue>
  {
    [Parameter] public override IEnumerable<TItem> Items { get; set; } = new List<TItem>();
    [Parameter] public override Func<TItem, TValue> ValueSelector { get; set; }
    [Parameter] public override Func<TItem, object> ItemKey { get; set; }
    [Parameter] public override Func<TItem, string> ItemText { get; set; }
    [Parameter] public override Func<Task<IEnumerable<TItem>>> DataMethod { get; set; }
  }
}
