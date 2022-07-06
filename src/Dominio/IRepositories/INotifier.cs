using Domain.Notifications;
using System.Collections.Generic;

namespace Domain.IRepositories
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotification();
        void Handle(Notification notification);
    }
}
