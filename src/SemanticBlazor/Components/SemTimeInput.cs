using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.DateTimeInput;

namespace SemanticBlazor.Components
{
  public class SemTimeInput<ValueType> : SemDateTimeInputBase<ValueType>
  {
    public bool AmPm { get; set; } = false;
    [Parameter] public bool MinutesEnabled { get; set; } = true;

    protected override List<Type> restrictedClasses
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
    //protected override void OnInitialized()
    //{
    //  if (typeof(ValueType) != typeof(TimeSpan) && typeof(ValueType) != typeof(TimeSpan?))
    //  {
    //    throw new ArgumentException("Only TimeSpan and TimeSpan? are supported as ValueType");
    //  }
    //  base.OnInitialized();
    //}
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender)
      {
        await JsFunc.DateTimeInput.InitTimeCalendar(js, Id, MinutesEnabled, AmPm);
      }
    }
    protected override string stringValue
    {
      get
      {
        return lastValidValue != null ? ((TimeSpan)(object)lastValidValue).ToString(@"h\:mm") : "";
      }
    }
  }
}