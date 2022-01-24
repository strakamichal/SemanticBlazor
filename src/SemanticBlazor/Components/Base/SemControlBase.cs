using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticBlazor.Components.Base
{
  public class SemControlBase : ComponentBase
  {
    [Inject] public IJSRuntime jsRuntime { get; set; }

    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string Class { get; set; }
    [Parameter] public string Style { get; set; }
    [Parameter] public bool Visible { get; set; } = true;
    [Parameter] public bool Enabled { get; set; } = true;
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> Attributes { get; set; }
    protected IJSRuntime js => jsRuntime;
    protected bool Rendered { get; set; } = false;
    protected ClassMapper ClassMapper { get; set; } = new ClassMapper();

    protected SemControlBase()
    {
      ClassMapper.Get(() => this.Class)
                 .If("disabled", () => !this.Enabled);
    }
    protected Dictionary<string, object> disabledAttribute
    {
      get
      {
        var retval = new Dictionary<string, object>();
        if (!Enabled) retval.Add("disabled", "disabled");
        return retval;
      }
    }
    internal virtual void RegisterChildControl(object control) { }
    public void InvokeStateHasChanged()
    {
      StateHasChanged();
    }
    protected override void OnAfterRender(bool firstRender)
    {
      if (firstRender)
      {
        Rendered = true;
      }
    }
  }
}
