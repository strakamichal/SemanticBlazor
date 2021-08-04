using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.SelectControlsBase;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;

namespace SemanticBlazor.Components
{
  public class SemDropdownSelection<ValueType> : SemDropdownSingleSelectionBase<ListItem, ValueType>
  {
    #region ListItems
    [Obsolete]
    [Parameter] public override IEnumerable<ListItem> Items { get; set; }
    [Parameter] public override RenderFragment ListItems { get; set; }
    #endregion

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}