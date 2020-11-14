using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Services
{
  public class NotificationService
  {
    public event Action<string, string, string> OnShow;

    public void ShowNotification(string message, string title = "", string color = "")
    {
      OnShow.Invoke(message, title, color);
    }
  }

  public class NotificationModel
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Message { get; set; }
    public string Color { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}
