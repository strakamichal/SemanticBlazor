using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components
{
  public class SemDropdownMultiSelection<TValue> : SemDataDropdownMultiSelection<ListItem, TValue>
  {
    #region ListItems
    [Obsolete]
    [Parameter] public override IEnumerable<ListItem> Items { get; set; }
    [Parameter] public override RenderFragment ListItems { get; set; }
    #endregion
  }
}
