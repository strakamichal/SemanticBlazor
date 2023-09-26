using Microsoft.AspNetCore.Components;
using SemanticBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SemanticBlazor.Components.Base.RadioButton;

namespace SemanticBlazor.Components
{
  public class SemRadioButtonList<TValue> : SemRadioButtonListBase<ListItem, TValue>
  {
    #region ListItems
    [Obsolete]
    [Parameter] public override IEnumerable<ListItem> Items { get; set; }
    [Parameter] public override RenderFragment<object> ItemTemplate { get; set; }
    [Parameter] public override RenderFragment ListItems { get; set; }
    #endregion
  }
}
