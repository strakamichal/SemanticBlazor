using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.SelectControlsBase;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components
{
  public class SemDropdownMultiSelection<ValueType> : SemDataDropdownMultiSelection<ValueType, ListItem>
  {
    #region ListItems
    [Parameter] public override IEnumerable<ListItem> Items { get; set; }
    [Parameter] public override RenderFragment ListItems { get; set; }
    #endregion

    protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
    {
      base.BuildRenderTree(__builder);
    }
  }
}
