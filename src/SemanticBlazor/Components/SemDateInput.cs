using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components
{
  public class SemDateInput<ValueType> : Base.SemDateTimeInputBase<ValueType>
  {
    protected override List<Type> restrictedClasses
    {
      get
      {
        return new List<Type>()
        {
          typeof(DateTime),
          typeof(DateTime?)
        };
      }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender)
      {
        await JsFunc.DateTimeInput.InitDateCalendar(js, Id);
      }
    }
    protected override string stringValue
    {
      get
      {
        return lastValidValue != null ? ((DateTime)(object)lastValidValue).ToString("dd.MM.yyyy") : "";
      }
    }
  }
}