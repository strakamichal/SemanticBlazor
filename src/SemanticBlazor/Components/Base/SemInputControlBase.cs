using Microsoft.AspNetCore.Components;
using SemanticBlazor.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Components.Base
{
  public class SemInputControlBase<ValueType> : SemControlBase
  {
    [CascadingParameter] protected Microsoft.AspNetCore.Components.Forms.EditContext EditContext { get; set; }
    [CascadingParameter] protected System.Linq.Expressions.Expression<Func<ValueType>> ForCasc { get; set; }
    [Parameter] public System.Linq.Expressions.Expression<Func<ValueType>> For { get; set; }
    [Parameter] public virtual ValueType Value { get; set; }
    [Parameter] public virtual EventCallback<ValueType> ValueChanged { get; set; }
    [Parameter] public virtual EventCallback<ValueType> Changed { get; set; }

    protected virtual List<Type> restrictedClasses { get; set; }
    public SemInputControlBase()
    {
      if (restrictedClasses?.Count > 0 && !restrictedClasses.Any(t => t == typeof(ValueType)))
      {
        throw new Exception($"{typeof(ValueType).Name} is not supported ValueType for {this.GetType().Name}.");
      }
    }
    protected virtual async Task NotifyChanged()
    {
      await ValueChanged.InvokeAsync(Value);
      await Changed.InvokeAsync(Value);
      if (EditContext != null && (For ?? ForCasc) != null)
      {
        EditContext.NotifyValidationStateChanged();
        EditContext.NotifyFieldChanged(new Microsoft.AspNetCore.Components.Forms.FieldIdentifier(EditContext.Model, SemanticBlazor.Annotations.GetPropertyNameFor(For ?? ForCasc)));
      }
    }
    public virtual async Task ClearValue()
    {
      Value = default(ValueType);
      await NotifyChanged();
    }
  }
}