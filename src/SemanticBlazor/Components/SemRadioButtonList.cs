using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.SelectControlsBase;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticBlazor.Components
{
  public class SemRadioButtonList<ValueType> : SemRadioButtonListBase<ListItem, ValueType>
  {
    #region ListItems
    [Obsolete]
    [Parameter] public override IEnumerable<ListItem> Items { get; set; }
    [Parameter] public override RenderFragment<object> ItemTemplate { get; set; }
    [Parameter] public override RenderFragment ListItems { get; set; }
    #endregion

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}
