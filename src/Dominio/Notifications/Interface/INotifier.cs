using Domain.Notifications;
using System.Collections.Generic;

namespace Domain.Notifications.Interface
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotification();
        void Handle(Notification notification);
    }
}
