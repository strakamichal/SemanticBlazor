using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace SemanticBlazor
{
  public class Annotations
  {
    public static string GetNameFor<ValueType>(System.Linq.Expressions.Expression<Func<ValueType>> forExpr)
    {
      string retval = "";
      if (forExpr != null)
      {
        var expression = forExpr.Body as MemberExpression ?? ((UnaryExpression)forExpr.Body).Operand as MemberExpression;
        var propertyInfo = (PropertyInfo)expression.Member;
        var attribute = propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute));
        if (attribute != null)
        {
          retval = ((System.ComponentModel.DataAnnotations.DisplayAttribute)attribute).Name;
        }
      }
      return retval;
    }

    public static string GetDescriptionFor<ValueType>(System.Linq.Expressions.Expression<Func<ValueType>> forExpr)
    {
      string retval = "";
      if (forExpr != null)
      {
        var expression = forExpr.Body as MemberExpression ?? ((UnaryExpression)forExpr.Body).Operand as MemberExpression;
        var propertyInfo = (PropertyInfo)expression.Member;
        var attribute = propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute));
        if (attribute != null)
        {
          retval = ((System.ComponentModel.DataAnnotations.DisplayAttribute)attribute).Description;
        }
      }
      return retval;
    }

    public static bool GetRequiredFor<ValueType>(System.Linq.Expressions.Expression<Func<ValueType>> forExpr)
    {
      bool retval = false;
      if (forExpr != null)
      {
        var expression = forExpr.Body as MemberExpression ?? ((UnaryExpression)forExpr.Body).Operand as MemberExpression;
        var propertyInfo = (PropertyInfo)expression.Member;
        var attribute = propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute));
        if (attribute != null)
        {
          retval = true;
        }
      }
      return retval;
    }

    public static string GetPropertyNameFor<ValueType>(System.Linq.Expressions.Expression<Func<ValueType>> forExpr)
    {
      if (forExpr != null)
      {
        var expression = forExpr.Body as MemberExpression ?? ((UnaryExpression)forExpr.Body).Operand as MemberExpression;
        var propertyInfo = (PropertyInfo)expression.Member;
        return propertyInfo.Name;
      }
      else
      {
        return "";
      }
    }

    //public static string GetPropertyName<ValueType>(System.Linq.Expressions.Expression<Func<ValueType>> forExpr)
    //{
    //  var expression = forExpr.Body as MemberExpression ?? ((UnaryExpression)forExpr.Body).Operand as MemberExpression;
    //  var propertyInfo = (PropertyInfo)expression.Member;
    //  return propertyInfo.Name;
    //}
  }
}
