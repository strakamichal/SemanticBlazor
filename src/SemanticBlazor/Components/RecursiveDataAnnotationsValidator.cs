using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace SemanticBlazor.Components
{
  public class RecursiveDataAnnotationsValidator : ComponentBase
  {
    private static readonly object ValidationContextValidatorKey = new object();
    private ValidationMessageStore _messages;
    [Parameter] public IJSRuntime JsRuntime { get; set; }
    [CascadingParameter] public EditContext EditContext { get; set; }

    protected override void OnInitialized()
    {
      _messages = new ValidationMessageStore(EditContext);

      // Perform object-level validation (starting from the root model) on request
      EditContext.OnValidationRequested += (sender, eventArgs) =>
      {
        _messages.Clear();
        ValidateObject(EditContext.Model);
        EditContext.NotifyValidationStateChanged();
      };

      // Perform per-field validation on each field edit
      EditContext.OnFieldChanged += (sender, eventArgs) => ValidateField(EditContext, _messages, eventArgs.FieldIdentifier);
      //EditContext.OnValidationStateChanged += async (sender, eventArgs) => await ValidationStateChanged();
    }
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //  //if (firstRender)
    //  //{
    //  //  await JsFunc.Validation.RefreshFieldsValidity(jSRuntime);
    //  //}
    //}
    //private async Task ValidationStateChanged()
    //{
    //  //await JsFunc.Validation.RefreshFieldsValidity(jSRuntime);
    //}
    private void ValidateObject(object value)
    {
      if (value is IEnumerable<object> enumerable)
      {
        foreach (var item in enumerable)
        {
          ValidateObject(item);
        }

        return;
      }

      var validationResults = new List<ValidationResult>();
      ValidateObject(value, validationResults);

      // Transfer results to the ValidationMessageStore
      foreach (var validationResult in validationResults)
      {
        foreach (var memberName in validationResult.MemberNames)
        {
          var fieldIdentifier = new FieldIdentifier(value, memberName);
          //var errorMessage = Translate(validationResult.ErrorMessage);
          _messages.Add(fieldIdentifier, validationResult.ErrorMessage);
        }
      }
    }
    private void ValidateObject(object value, List<ValidationResult> validationResults)
    {
      var validationContext = new ValidationContext(value);
      validationContext.Items.Add(ValidationContextValidatorKey, this);
      Validator.TryValidateObject(value, validationContext, validationResults, validateAllProperties: true);
    }
    internal static void TryValidateRecursive(object value, ValidationContext validationContext)
    {
      if (validationContext.Items.TryGetValue(ValidationContextValidatorKey, out var validator))
      {
        ((RecursiveDataAnnotationsValidator)validator).ValidateObject(value);
      }
    }
    private static void ValidateField(EditContext editContext, ValidationMessageStore messages, in FieldIdentifier fieldIdentifier)
    {
      // DataAnnotations only validates public properties, so that's all we'll look for
      var propertyInfo = fieldIdentifier.Model.GetType().GetProperty(fieldIdentifier.FieldName);
      if (propertyInfo != null)
      {
        var propertyValue = propertyInfo.GetValue(fieldIdentifier.Model);
        var validationContext = new ValidationContext(fieldIdentifier.Model)
        {
          MemberName = propertyInfo.Name
        };
        var results = new List<ValidationResult>();

        Validator.TryValidateProperty(propertyValue, validationContext, results);
        messages.Clear(fieldIdentifier);
        messages.Add(fieldIdentifier, results.Select(result => result.ErrorMessage));

        // We have to notify even if there were no messages before and are still no messages now,
        // because the "state" that changed might be the completion of some async validation task
        editContext.NotifyValidationStateChanged();
      }
    }
    //private string Translate(string expr)
    //{
    //  if (expr.Contains("is required"))
    //  {
    //    return "Pole je povinné.";
    //  }
    //  else
    //  {
    //    return expr;
    //  }
    //}
  }
}