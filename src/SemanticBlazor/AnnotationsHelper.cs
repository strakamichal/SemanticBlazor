using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace SemanticBlazor
{
  public static class Annotations
  {
    public static string GetNameFor<TValue>(Expression<Func<TValue>> forExpr)
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

    public static string GetDescriptionFor<TValue>(Expression<Func<TValue>> forExpr)
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

    public static bool GetRequiredFor<TValue>(Expression<Func<TValue>> forExpr)
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

    public static string GetPropertyNameFor<TValue>(Expression<Func<TValue>> forExpr)
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
  }
}
