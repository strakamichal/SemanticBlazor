using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.ButtonSwitch;

namespace SemanticBlazor.Components
{
  public class SemDataButtonSwitch<ItemType, ValueType> : SemButtonSwitchBase<ItemType, ValueType>
  {
    [Parameter] public override IEnumerable<ItemType> Items { get; set; } = new List<ItemType>();
    [Parameter] public override Func<ItemType, ValueType> ValueSelector { get; set; }
    [Parameter] public override Func<ItemType, object> ItemKey { get; set; }
    [Parameter] public override Func<ItemType, string> ItemText { get; set; }
    [Parameter] public override Func<Task<IEnumerable<ItemType>>> DataMethod { get; set; }

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}
