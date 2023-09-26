using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace SemanticBlazor.Components.Base.Common
{
  public class SemInputControlBase<TValue> : SemControlBase
  {
    [CascadingParameter] protected Microsoft.AspNetCore.Components.Forms.EditContext EditContext { get; set; }
    [CascadingParameter] protected System.Linq.Expressions.Expression<Func<TValue>> ForCasc { get; set; }
    [Parameter] public System.Linq.Expressions.Expression<Func<TValue>> For { get; set; }
    [Parameter] public virtual TValue Value { get; set; }
    [Parameter] public virtual EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public virtual EventCallback<TValue> Changed { get; set; }

    protected virtual List<Type> RestrictedClasses { get; set; } = new List<Type>();
    public SemInputControlBase()
    {
      if (RestrictedClasses.Any() && RestrictedClasses.All(t => t != typeof(TValue)))
      {
        throw new Exception($"{typeof(TValue).Name} is not supported TValue for {GetType().Name}.");
      }
    }
    protected virtual async Task NotifyChanged()
    {
      await ValueChanged.InvokeAsync(Value);
      await Changed.InvokeAsync(Value);
      if (EditContext != null && (For ?? ForCasc) != null)
      {
        EditContext.NotifyValidationStateChanged();
        EditContext.NotifyFieldChanged(new Microsoft.AspNetCore.Components.Forms.FieldIdentifier(EditContext.Model, Annotations.GetPropertyNameFor(For ?? ForCasc)));
      }
    }
    public virtual async Task ClearValue()
    {
      Value = default(TValue);
      await NotifyChanged();
    }
  }
}