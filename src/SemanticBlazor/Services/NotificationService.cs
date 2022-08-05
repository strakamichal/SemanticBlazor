using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SemanticBlazor.Services
{
  public class NotificationService
  {
    public event Action<NotificationModel> OnShow;

    [Obsolete]
    public void ShowNotification(string message, string title = "", string color = "")
    {
      var notification = new Services.NotificationModel()
      {
        Message = message,
        Color = color,
        Title = title,
        Duration = 5
      };
      OnShow?.Invoke(notification);
    }
    
    public void ShowNotification(string message, string title = "", int duration = 5, Color? color = null, Icon? icon = null)
    {
      var notification = new Services.NotificationModel()
      {
        Message = message,
        Color = color?.ToString().ToLower(),
        Icon = icon,
        Duration = duration,
        Title = title
      };
      OnShow?.Invoke(notification);
    }
  }

  public class NotificationModel
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Message { get; set; }
    public string Color { get; set; }
    public Icon? Icon { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Duration { get; set; }
    public DateTime Expiration => CreatedAt.AddSeconds(Duration);
  }
}