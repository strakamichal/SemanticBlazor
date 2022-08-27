using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SemanticBlazor.Components.Base.Dropdown;

namespace SemanticBlazor
{
  public static class JsFunc
  {
    public static class Lists
    {
      public static async Task ScrollTop(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticLists.ScrollTop", id);
      }
    }

    public static class DropDown
    {
      public static async Task Init(IJSRuntime jsRuntime, string id, Dictionary<string, object> settings)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdown.Init", id, settings);
      }
      public static async Task Init(IJSRuntime jsRuntime, string id, object objRef, Dictionary<string, object> settings)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdown.InitRef", id, objRef, settings);
      }
      public static async ValueTask<object> GetValue(IJSRuntime jsRuntime, string id)
      {
        return await jsRuntime.InvokeAsync<object>("SemanticDropdown.GetValue", id);
      }
      public static async Task SetValue(IJSRuntime jsRuntime, string id, string value)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdown.SetValue", id, value);
      }
      public static async Task SetExactlyValue(IJSRuntime jsRuntime, string id, string value)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdown.SetExactlyValue", id, value);
      }
      public static async Task Clear(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdown.Clear", id);
      }
    }

    public static class DropDownMenu
    {
      public static async Task Init(IJSRuntime jsRuntime, string id, string on = "click", string action = "hide")
      {
        await jsRuntime.InvokeAsync<object>("SemanticDropdownMenu.Init", id, on, action);
      }
    }

    public static class Accordion
    {
      public static async Task Init(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticAccordion.Init", id);
      }
    }

    public static class TabularMenu
    {
      public static async Task Init(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticTabularMenu.Init", id);
      }
    }

    public static class Modal
    {
      public static async Task Show(IJSRuntime jsRuntime, string id, bool allowMultiple = false, bool closable = true)
      {
        await jsRuntime.InvokeAsync<object>("SemanticModal.Show", id, allowMultiple, closable);
      }
      public static async Task Hide(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticModal.Hide", id);
      }
      public static async Task SubmitForm(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticModal.SubmitForm", id);
      }
    }

    public static class Form
    {
      public static async Task Submit(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("SemanticForm.Submit", id);
      }
    }

    public static class NotifcationPanel
    {
      public static async Task HideNotificaion(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("NotifcationPanel.HideNotificaion", id);
      }
      public static async Task SetHidingTimeout(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<object>("NotifcationPanel.SetHidingTimeout", id);
      }
    }

    public static class DateTimeInput
    {
      public static async Task InitDateCalendar(IJSRuntime jsRuntime, string id, string locale = null, string todayText = null, string startCalId = null, string endCalId = null)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDateTimeInput.InitDateCalendar", id, locale, todayText, startCalId, endCalId);
      }
      public static async Task InitTimeCalendar(IJSRuntime jsRuntime, string id, bool minutesEnabled, bool ampm)
      {
        await jsRuntime.InvokeAsync<object>("SemanticDateTimeInput.InitTimeCalendar", id, minutesEnabled, ampm);
      }
      public static async Task GetValue(IJSRuntime jsRuntime, string id)
      {
        await jsRuntime.InvokeAsync<string>("SemanticDateTimeInput.GetValue", id);
      }
      public static async Task SetDate(IJSRuntime jsRuntime, string id, string date)
      {
        await jsRuntime.InvokeAsync<string>("SemanticDateTimeInput.SetDate", id, date);
      }
    }

    public static class Validation
    {
      public static async Task RefreshFieldsValidity(IJSRuntime jsRuntime)
      {
        await jsRuntime.InvokeAsync<object>("Validation.RefreshFieldsValidity");
      }
    }
    
    public static class Logging
    {
      public static async Task ConsoleLog(IJSRuntime jsRuntime, string message)
      {
        #if DEBUG
        await jsRuntime.InvokeAsync<object>("console.log", message);
        #endif
      }
    }
  }
}
