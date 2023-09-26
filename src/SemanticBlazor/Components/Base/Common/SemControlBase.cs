using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SemanticBlazor.Mappers;

namespace SemanticBlazor.Components.Base.Common
{
  public class SemControlBase : ComponentBase
  {
    [Inject] public IJSRuntime JsRuntimeService { get; set; }

    [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Parameter] public string Class { get; set; }
    [Parameter] public string Style { get; set; }
    [Parameter] public bool Visible { get; set; } = true;
    [Parameter] public bool Enabled { get; set; } = true;
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> Attributes { get; set; }
    protected IJSRuntime JsRuntime => JsRuntimeService;
    protected bool Rendered { get; private set; }
    protected ClassMapper ClassMapper { get; } = new ClassMapper();

    protected SemControlBase()
    {
      ClassMapper.Get(() => Class)
                 .If("disabled", () => !Enabled);
    }
    protected Dictionary<string, object> DisabledAttribute
    {
      get
      {
        var retval = new Dictionary<string, object>();
        if (!Enabled) retval.Add("disabled", "disabled");
        return retval;
      }
    }
    internal virtual void RegisterChildControl(object control) { }

    protected override void OnAfterRender(bool firstRender)
    {
      if (firstRender)
      {
        Rendered = true;
      }
    }
  }
}
