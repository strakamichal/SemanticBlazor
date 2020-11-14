using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SemanticBlazor.Services
{
  public class PackageInformationService
  {
    public string GetVersion()
    {
      Assembly a = Assembly.GetExecutingAssembly();
      Assembly b = typeof(SemanticBlazor.Services.PackageInformationService).Assembly;

      return null;
    }
  }
}
