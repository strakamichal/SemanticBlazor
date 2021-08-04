using System;
using System.Collections.Generic;
using System.Text;

namespace SemanticBlazor.Models
{
  public class DataMethodParams
  {
    public int StartRowIndex { get; set; }
    public int MaximumRows { get; set; }
    public string SortExpression { get; set; }
    public string SortDirection { get; set; }
  }
}
