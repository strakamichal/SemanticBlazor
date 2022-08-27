using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.DateTimeInput;

namespace SemanticBlazor.Components
{
  public class SemTimeInput<TValue> : SemDateTimeInputBase<TValue>
  {
    public bool AmPm { get; set; } = false;
    [Parameter] public bool MinutesEnabled { get; set; } = true;

    protected override List<Type> RestrictedClasses
    {
      get
      {
        return new List<Type>()
        {
          typeof(TimeSpan),
          typeof(TimeSpan?)
        };
      }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender)
      {
        await JsFunc.DateTimeInput.InitTimeCalendar(JsRuntime, Id, MinutesEnabled, AmPm);
      }
    }
    protected override string StringValue => LastValidValue != null ? ((TimeSpan)(object)LastValidValue).ToString(@"h\:mm") : "";
  }
}