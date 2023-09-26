using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.DateTimeInput;

namespace SemanticBlazor.Components
{
  public class SemDateInput<TValue> : SemDateTimeInputBase<TValue>
  {
    [Parameter] public string StartDateInputId { get; set; }
    [Parameter] public string EndDateInputId { get; set; }

    protected override List<Type> RestrictedClasses =>
      new List<Type>()
      {
        typeof(DateTime),
        typeof(DateTime?)
      };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender)
      {
        if (StartDateInputId == null && EndDateInputId == null)
        {
          await JsFunc.DateTimeInput.InitDateCalendar(JsRuntime, Id, Culture);
        }
        else
        {
          await JsFunc.DateTimeInput.InitDateCalendar(JsRuntime, Id, Culture, null, StartDateInputId, EndDateInputId);
          //await JsFunc.DateTimeInput.SetDate(JsRuntime, Id, LastValidValue);
        }
      }
    }
    protected override string StringValue => LastValidValue != null ? ((DateTime)(object)LastValidValue).ToString(DateFormat) : "";
  }
}