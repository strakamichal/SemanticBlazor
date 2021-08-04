using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components
{
  public class SemDateInput<ValueType> : Base.SemDateTimeInputBase<ValueType>
  {
    //[Parameter] public override string DateFormat { get; set; } = "dd.MM.yyyy";
    [Parameter] public string StartDateInputId { get; set; }
    [Parameter] public string EndDateInputId { get; set; }

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
        if (StartDateInputId == null && EndDateInputId == null)
        {
          await JsFunc.DateTimeInput.InitDateCalendar(js, Id);
        }
        else
        {
          await JsFunc.DateTimeInput.InitDateCalendar(js, Id, null, null, StartDateInputId, EndDateInputId);
        }
      }
    }
    protected override string stringValue
    {
      get
      {
        return lastValidValue != null ? ((DateTime)(object)lastValidValue).ToString(DateFormat) : "";
      }
    }
  }
}