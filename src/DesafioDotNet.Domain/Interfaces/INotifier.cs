using DesafioDotNet.Domain.Notifications;

namespace DesafioDotNet.Domain.Interfaces;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
